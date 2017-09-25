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

        Dictionary<char, double> TrustedDict;
        Dictionary<char, double> PhishingDict;

        List<string> TrustedSites;
        List<string> PhishingSites;

        public frmUrlChars()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            TrustedDict = new Dictionary<char, double>();
            PhishingDict = new Dictionary<char, double>();

            TrustedSites = Repository
                            .Find<Resource>(r => r.ItemType == PhishDataType.Positive)
                            .OrderBy(x => x.UID)
                            .Select(u => u.Url)
                            //.Take(50)
                            .ToList();

            lblTrusted.Text = "Trusted Sites: " + TrustedSites.Count.ToString();

            PhishingSites = Repository
                            .Find<Resource>(r => r.ItemType == PhishDataType.Negative)
                            .OrderBy(x => x.UID)
                            .Select(u => u.Url)
                            .Skip(3 * TrustedSites.Count)
                            .Take(TrustedSites.Count)
                            //.Take(50)
                            .ToList();

            lblPhishing.Text = "Phishing Sites: " + PhishingSites.Count.ToString();
        }

        public void ComputeTrusted()
        {
            foreach (string site in TrustedSites)
            {
                string filtered = Regex.Replace(site, @"[A-Za-z]", "");

                filtered = Regex.Replace(filtered, @"[\d-]", "");

                foreach (var chara in filtered)
                {
                    if (chara == '\0')
                        return;

                    if (!TrustedDict.ContainsKey(chara))
                    {
                        TrustedDict.Add(chara, 1);
                    }
                    else
                    {
                        TrustedDict[chara] = TrustedDict[chara] + 1;
                    }
                }
            }

            dataGridView1.Rows.Clear();

            foreach (var g in TrustedDict)
            {
                double x1 = Math.Round(g.Value / TrustedSites.Count, 2);

                dataGridView1.Rows.Add(g.Key, x1);
            }

            foreach (var g in TrustedDict.ToList())
            {
                double x1 = Math.Round(g.Value / TrustedSites.Count, 2);

                TrustedDict[g.Key] = x1;
            }

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        public void ComputePhishing()
        {
            foreach (string site in PhishingSites)
            {
                string filtered = Regex.Replace(site, @"[A-Za-z]", "");

                filtered = Regex.Replace(filtered, @"[\d-]", "");

                foreach (var chara in filtered)
                {
                    if (chara == '\0')
                        return;

                    if (!PhishingDict.ContainsKey(chara))
                    {
                        PhishingDict.Add(chara, 1);
                    }
                    else
                    {
                        PhishingDict[chara] = PhishingDict[chara] + 1;
                    }
                }
            }

            dataGridView2.Rows.Clear();

            foreach (var g in PhishingDict)
            {
                double x1 = Math.Round(g.Value / PhishingSites.Count, 2);

                dataGridView2.Rows.Add(g.Key, x1);
            }

            foreach (var g in PhishingDict.ToList())
            {
                double x1 = Math.Round(g.Value / PhishingSites.Count, 2);

                PhishingDict[g.Key] = x1;
            }

            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputeTrusted();
            ComputePhishing();

            ComputeCombined();
        }

        public void ComputeCombined()
        {
            dataGridView3.Rows.Clear();

            foreach (var x in TrustedDict)
            {
                if (PhishingDict.ContainsKey(x.Key))
                {
                    double Diff = Math.Round(PhishingDict[x.Key] - x.Value, 2);

                    if (Math.Abs(Diff) > 0.3)
                    {
                        dataGridView3.Rows.Add(x.Key, Diff, "Yes");
                    }
                    else
                    {
                        dataGridView3.Rows.Add(x.Key, Diff, "No");
                    }
                }
            }

            dataGridView3.Sort(dataGridView3.Columns[1], ListSortDirection.Descending);
        }
    }
}
