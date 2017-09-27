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

            //Cold start Database
            //AlgorithmClass.ColdStartDb();

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

            cPhishbait Class = new cPhishbait(Url, ConfigItems, false, false, false, false, false, 50);

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

            Layer3.Visible = true;

            Resource Resource = Class.Resource;

            grdUrlAnalysis.Rows.Clear();

            grdUrlAnalysis.Rows.Add("Number of Full Stops", ConfigItems["FullStops"].ToString(), ConfigItems["FullStopsW"].ToString() + " %", Resource.NumberOfFullStops.ToString());
            grdUrlAnalysis.Rows.Add("Number of @ Symbols", ConfigItems["AtSymbols"].ToString(), ConfigItems["AtSymbolsW"].ToString() + " %", Resource.NumberOfAtSymbols.ToString());
            grdUrlAnalysis.Rows.Add("Number of Double Forward Slashes", ConfigItems["ForwardSlashes"].ToString(), ConfigItems["ForwardSlashesW"].ToString() + " %", Resource.NumberOfForwardSlashes.ToString());
            grdUrlAnalysis.Rows.Add("Number of Multiple Forward Slashes", ConfigItems["MultipleForwardSlashes"].ToString(), ConfigItems["MultipleForwardSlashesW"].ToString() + " %", Resource.NumberOfForwardSlashes.ToString());

            grdUrlAnalysis.Rows.Add("Contains IP Address", ConfigItems["IPAddress"].ToString(), ConfigItems["IPAddressW"].ToString() + " %", Resource.HasIPAddress.ToString());
            grdUrlAnalysis.Rows.Add("Contains Port Number", ConfigItems["PortNumbers"].ToString(), ConfigItems["PortNumbersW"].ToString() + " %", Resource.HasPortNumber.ToString());
            grdUrlAnalysis.Rows.Add("Invalid HTTPS", ConfigItems["InvalidHttps"].ToString(), ConfigItems["InvalidHttpsW"].ToString() + " %", Resource.IsBadHttps.ToString());

            if (Class.LayerDetected != 3)
            {
                txtLayer3.Text = "The requested URL does not possess common elements found in phishing sites";
                txtLayer3.BackColor = System.Drawing.Color.Green;
                txtLayer3.ForeColor = System.Drawing.Color.White;
            }

            if (Class.LayerDetected == 3)
            {
                txtLayer3.Text = "The requested URL possesses common elements found in phishing sites";
                txtLayer3.BackColor = System.Drawing.Color.Red;
                txtLayer3.ForeColor = System.Drawing.Color.White;
                return;
            }

            Layer4.Visible = true;

            grdFreq.Rows.Clear();
            foreach (var item in Class.grdFreq)
            {
                grdFreq.Rows.Add(item.Key, Convert.ToString(item.Value));
            }

            if (Class.LayerDetected != 4)
            {
                txtLayer4.Text = "The requested URL does not contain sufficient frequent items found in phishing sites";
                txtLayer4.BackColor = System.Drawing.Color.Green;
                txtLayer4.ForeColor = System.Drawing.Color.White;
            }

            if (Class.LayerDetected == 4)
            {
                txtLayer4.Text = "The requested URL contains the following frequent items found in phishing sites";
                txtLayer4.BackColor = System.Drawing.Color.Red;
                txtLayer4.ForeColor = System.Drawing.Color.White;
                return;
            }

            Layer5.Visible = true;

            if (Class.LayerDetected != 5)
            {
                txtLayer5.Text = "According to Bayesian Theorem of classification, using the system's data, the requested URL is not a phishing site";
                txtLayer5.BackColor = System.Drawing.Color.Green;
                txtLayer5.ForeColor = System.Drawing.Color.White;
            }

            if (Class.LayerDetected == 5)
            {
                txtLayer5.Text = "According to Bayesian Theorem of classification, using the system's data, the requested URL is a phishing site";
                txtLayer5.BackColor = System.Drawing.Color.Red;
                txtLayer5.ForeColor = System.Drawing.Color.White;
            }

            BayesTrusted.Text = Math.Round(Class.BayesScore["Phishing"], 3).ToString();

            BayesPhishing.Text = Math.Round(Class.BayesScore["Non Phishing"], 3).ToString();

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

        public void SimulateQueries()
        {
            List<Resource> Resources = Repository.GetAll<Resource>().Take(1000).ToList();

            foreach(var item in Resources)
            {
                //DetectUrl(item.Url);
            }
        }


        public void FrequentItemCounter()
        {
            AlgorithmClass.FrequentItemCounter(PhishDataType.Negative, 
                                                3, 
                                                3);

            AlgorithmClass.FrequentItemCounter(PhishDataType.Positive,
                                                3,
                                                3);

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

        private void ignoreRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIgnoreRules Form = new frmIgnoreRules();
            Form.Show();
        }

        private void frequentItemCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblSystemStatus.Text = "Processing frequent items, please wait";
            lblSystemStatus.ForeColor = System.Drawing.Color.Red;

            FrequentItemCounter();

            lblSystemStatus.Text = "Frequent items processed - Ready";
            lblSystemStatus.ForeColor = System.Drawing.Color.Black;
        }

        private void uRLAnalysisCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblSystemStatus.Text = "Processing URL analysis, please wait";
            lblSystemStatus.ForeColor = System.Drawing.Color.Red;

            AlgorithmClass.UrlStatsCalc();

            lblSystemStatus.Text = "URL Analysis processed - Ready";
            lblSystemStatus.ForeColor = System.Drawing.Color.Black;
        }

        private void frequentItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFrequent Form = new frmFrequent();
            Form.Show();
        }

        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResource Form = new frmResource();
            Form.Show();
        }

        private void simulateURLAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulateQueries();
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

        private void heuristicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptimiseHeur Form = new frmOptimiseHeur();
            Form.Show();
        }

        private void heuristicPassScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptimiseHeurPass Form = new frmOptimiseHeurPass();
            Form.Show();
        }

        private void frequentIPassScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptimiseFrequentPass Form = new frmOptimiseFrequentPass();
            Form.Show();
        }
    }
}
