using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmStats : Form
    {
        PhishModel db;
        EFRepository Repository;
        Dictionary<string, string> ConfigItems;

        public frmStats()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            ConfigItems = Repository
                        .GetAll<Configuration>()
                        .ToDictionary(s => s.Parameter, z => z.Value);

            CalcSystemStats();
        }

        public void CalcSystemStats()
        {
            List<Resource> AllSites = Repository.GetAll<Resource>().ToList();

            List<Resource> PhishingSites = AllSites.Where(s => s.ItemType == PhishDataType.Negative).ToList();

            List<Resource> TrustedSites = AllSites.Where(s => s.ItemType == PhishDataType.Positive).ToList();

            grdMain.Rows.Add("Total Sites", AllSites.Count.ToString());
            grdMain.Rows.Add("Phishing Sites", PhishingSites.Count.ToString());
            grdMain.Rows.Add("Trusted Sites", TrustedSites.Count.ToString());
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            PhishingSites();

            TrustedSites();

            Cursor.Current = Cursors.Default;
        }

        public void TrustedSites()
        {
            List<Resource> TrustedSites = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Positive)
                            .Take(50) //TO DO Remove Limit
                            .ToList();

            int FPCount = 0;
            int TNCount = 0;

            foreach (var item in TrustedSites)
            {
                cPhishbait Class = new cPhishbait(item, item.Url, ConfigItems, true, true, false, false, false, 0, 0, false);

                if (Class.LayerDetected == 0)
                    TNCount += 1;
                else
                    FPCount += 1;
            }
            double FalsePositive = Math.Round((double)FPCount / TrustedSites.Count * 100, 4); 
            double TrueNegative = Math.Round((double)TNCount / TrustedSites.Count * 100, 4);

            grdTrusted.Rows.Add("Total Records", TrustedSites.Count.ToString());
            grdTrusted.Rows.Add("True Negatives", TrueNegative.ToString());
            grdTrusted.Rows.Add("False Positives", FalsePositive.ToString());

        }

        public void PhishingSites()
        {
            List<Resource> PhishingSites = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                            .Take(50) //TO DO Remove Limit
                            .ToList();

            int TPCount = 0;
            int FNCount = 0;

            foreach (var item in PhishingSites)
            {
                cPhishbait Class = new cPhishbait(item, item.Url, ConfigItems, true, true, false, false, false, 0, 0, false);

                if (Class.LayerDetected == 0)
                    FNCount += 1;
                else
                    TPCount += 1;
            }
            double TruePositive = Math.Round((double)TPCount / PhishingSites.Count * 100, 4);
            double FalseNegative = Math.Round((double)FNCount / PhishingSites.Count * 100, 4);

            grdPhishing.Rows.Add("Total Records", PhishingSites.Count.ToString());
            grdPhishing.Rows.Add("True Positives", TruePositive.ToString());
            grdPhishing.Rows.Add("False Negatives", FalseNegative.ToString());

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            dlgText.ShowDialog();
        }

        private void dlgText_FileOk(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            List<Resource> Resources = new List<Resource>();

            var lines = File.ReadLines(dlgText.FileName);

            foreach (var line in lines)
            {
                Resources.Add(new Resource(line));
            }

            int TPCount = 0;
            int FNCount = 0;

            foreach (var item in Resources)
            {
                cPhishbait Class = new cPhishbait(item, item.Url, ConfigItems, true, true, false, false, false, 0, 0, false);

                if (Class.LayerDetected == 0)
                    FNCount += 1;
                else
                    TPCount += 1;
            }
            double TruePositive = Math.Round((double)TPCount / Resources.Count * 100, 4);
            double FalseNegative = Math.Round((double)FNCount / Resources.Count * 100, 4);

            grdNewSites.Rows.Add("Total Records", Resources.Count.ToString());
            grdNewSites.Rows.Add("True Positives", TruePositive.ToString());
            grdNewSites.Rows.Add("False Negatives", FalseNegative.ToString());

            Cursor.Current = Cursors.Default;
        }
    }
}
