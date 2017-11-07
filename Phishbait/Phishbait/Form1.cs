using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class Form1 : Form
    {
        UrlStatistic CombinedStats;
        PhishModel db;
        EFRepository Repository;
        Algorithms AlgorithmClass;
        Dictionary<string, string> ConfigItems;

        public Form1()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);
            AlgorithmClass = new Algorithms();

            txtUrl.Text = "www.google.com";

            CombinedStats = Repository.Find<UrlStatistic>(s => s.Type == StatisticType.Overall).FirstOrDefault();

            ConfigItems = Repository
                        .GetAll<Configuration>()
                        .ToDictionary(s => s.Parameter, z => z.Value);
                                
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Layer1.Visible = false;
            Layer2.Visible = false;
            Layer3.Visible = false;
            Layer4.Visible = false;
            Layer5.Visible = false;

            string Url = txtUrl.Text;

            bool IsNewResource = false;

            Resource Resource = Repository
                                .Find<Resource>(s => s.Url == Url)
                                .FirstOrDefault();

            if (Resource == null)
            {
                IsNewResource = true;
                Resource = new Resource(Url);
            }

            //TO DO remove test environment
            cPhishbait Class = new cPhishbait(Resource, Url, ConfigItems, true, true, false, false, false, true, 0);

            grpMain.Visible = true;

            Layer1.Visible = true;

            if (Class.LayerDetected != 1)
            {
                txtLayer1.Text = "The requested URL was not found in the whitelist (Layer 1)";
                txtLayer1.BackColor = System.Drawing.Color.Green;
                txtLayer1.ForeColor = System.Drawing.Color.White;
            }
            
            if (Class.LayerDetected == 1)
            {
                txtLayer1.Text = "The requested URL was detected as phishing by the whitelist (Layer 1)";
                txtLayer1.BackColor = System.Drawing.Color.Red;
                txtLayer1.ForeColor = System.Drawing.Color.White;
                return;
            }

            Layer2.Visible = true;

            if (Class.LayerDetected != 2)
            {
                txtLayer2.Text = "The requested URL was not found in the blacklist (Layer 2)";
                txtLayer2.BackColor = System.Drawing.Color.Green;
                txtLayer2.ForeColor = System.Drawing.Color.White;
            }

            if (Class.LayerDetected == 2)
            {
                txtLayer2.Text = "The requested URL was detected as phishing by the blacklist (Layer 2)";
                txtLayer2.BackColor = System.Drawing.Color.Red;
                txtLayer2.ForeColor = System.Drawing.Color.White;
                return;
            }

            Resource = Class.Resource;

            Resource.LayerDetected = Class.LayerDetected;

            if (IsNewResource)
                Repository.Add(Resource);
            else
                Repository.Update(Resource);

            //string htmlCode;

            //SimulateQueries();

            //Get Source code of URL
            //using (WebClient client = new WebClient())
            //{
            //    string EditedUrl = Url;

            //    //Add http://
            //    if (Url.Substring(0, 4) != "http")
            //    {
            //        EditedUrl = "http://" + Url;
            //    }

            //    htmlCode = client.DownloadString(EditedUrl);

            //    var y = 1;
            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImport ImportForm = new frmImport();
            ImportForm.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIgnore Configs = new frmIgnore();
            Configs.Show();
        }

        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResource Form = new frmResource();
            Form.Show();
        }

        private void crawlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrawler Form = new frmCrawler();
            Form.Show();
        }

        private void uRLCharsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUrlChars Form = new frmUrlChars();
            Form.Show();
        }

        private void simulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStats Form = new frmStats();
            Form.Show();
        }
    }
}
