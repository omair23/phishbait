using Phishbait.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmUrlChars : Form
    {
        PhishModel db;
        EFRepository Repository;
        TldList TList;

        Dictionary<char, double> TrustedDict;
        Dictionary<char, double> PhishingDict;

        List<Resource> TrustedSites;
        List<Resource> PhishingSites;

        public frmUrlChars()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            TList = new TldList();

            TrustedDict = new Dictionary<char, double>();
            PhishingDict = new Dictionary<char, double>();

            TrustedSites = Repository
                            .Find<Resource>(r => r.ItemType == PhishDataType.Positive)
                            //.Take(4000)
                            //.OrderBy(x => x.UID)
                            .ToList();

            lblTrusted.Text = "Trusted Sites: " + TrustedSites.Count.ToString();

            PhishingSites = Repository
                            .Find<Resource>(r => r.ItemType == PhishDataType.Negative)
                            //.OrderBy(x => x.UID)
                            .Take(TrustedSites.Count)
                            .ToList();

            lblPhishing.Text = "Phishing Sites: " + PhishingSites.Count.ToString();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputeCombined();
        }

        public void ComputeCombined()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            foreach (var item in TrustedSites)
            {
                item.SetDetectionVariables(TList);
            }

            foreach (var item in PhishingSites)
            {
                item.SetDetectionVariables(TList);
            }

            var PhishingDigitAverage = Math.Round(PhishingSites.Average(s => s.DigitCount), 2);
            var TrustedDigitAverage = Math.Round(TrustedSites.Average(s => s.DigitCount), 2);

            var PhishingURLAverage = Math.Round(PhishingSites.Average(s => s.URLLength), 2);
            var TrustedURLAverage = Math.Round(TrustedSites.Average(s => s.URLLength), 2);

            var PhishingTLDAverage = Math.Round(PhishingSites.Average(s => s.CommonTLD ? 1 : 0), 2) * 100;
            var TrustedTLDAverage = Math.Round(TrustedSites.Average(s => s.CommonTLD ? 1 : 0), 2) * 100;

            var PhishingSubdomainAverage = Math.Round(PhishingSites.Average(s => s.NumberOfSubDomains), 2);
            var TrustedSubdomainAverage = Math.Round(TrustedSites.Average(s => s.NumberOfSubDomains), 2);

            dataGridView1.Rows.Add("Digit Count", TrustedDigitAverage.ToString());
            dataGridView2.Rows.Add("Digit Count", PhishingDigitAverage.ToString());

            dataGridView1.Rows.Add("URL Length", TrustedURLAverage.ToString());
            dataGridView2.Rows.Add("URL Length", PhishingURLAverage.ToString());

            dataGridView1.Rows.Add("Common TLD", TrustedTLDAverage.ToString() + " %");
            dataGridView2.Rows.Add("Common TLD", PhishingTLDAverage.ToString() + " %");

            dataGridView1.Rows.Add("Number Of SubDomains", TrustedSubdomainAverage.ToString());
            dataGridView2.Rows.Add("Number Of SubDomains", PhishingSubdomainAverage.ToString());

            ComputeDiffs(PhishingURLAverage, TrustedURLAverage, "URL Length", 3, false);
            ComputeDiffs(PhishingDigitAverage, TrustedDigitAverage, "Digit Count", 3, false);
            ComputeDiffs(PhishingSubdomainAverage, TrustedSubdomainAverage, "Number Of SubDomains", 3, false);
            ComputeDiffs(PhishingTLDAverage, TrustedTLDAverage, "Common TLD", 10, true);

            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Descending);
        }

        public void ComputeDiffs(double A, double B, string C, double Limit, bool Percentage)
        {
            double Diff = Math.Round(A - B, 2);

            if (!Percentage)
                dataGridView3.Rows.Add(C, Diff, Math.Abs(Diff) > Limit ? "Yes" : "No");
            else
                dataGridView3.Rows.Add(C, Diff + " %", Math.Abs(Diff) > Limit ? "Yes" : "No");
        }
    }
}
