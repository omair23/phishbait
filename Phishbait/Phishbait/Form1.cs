using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class Form1 : Form
    {
        int FrequentItems_MinimumLength;
        int FrequentItems_Confidence;
        double PassValue;
        double UrlAnalysisWeight;
        double UrlFqWeight;

        UrlStatistic CombinedStats;
        PhishModel db;
        EFRepository Repository;
        Algorithms AlgorithmClass;

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

            ConfigItemsGet();

            //ImportTrusted();

            //List<double> mine = new List<double>();
            //mine.Add(3.14);
            //mine.Add(3.69);
            //mine.Add(3.22);

            //double average = mine.Average();
            //double sumOfSquaresOfDifferences = mine.Select(val => (val - average) * (val - average)).Sum();
            //double sd = Math.Sqrt(sumOfSquaresOfDifferences / mine.Count);

            //var x = 1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Layer1.Visible = false;
            Layer2.Visible = false;
            Layer3.Visible = false;
            Layer4.Visible = false;
            Layer5.Visible = false;

            string Url = txtUrl.Text;

            cPhishbait Class = new cPhishbait(Url);

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

            grdUrlAnalysis.Rows.Add("Number of Full Stops", 2, Resource.NumberOfFullStops.ToString());
            grdUrlAnalysis.Rows.Add("Number of @ Symbols", 0, Resource.NumberOfAtSymbols.ToString());
            grdUrlAnalysis.Rows.Add("Number of Double Forward Slashes", 1, Resource.NumberOfForwardSlashes.ToString());
            grdUrlAnalysis.Rows.Add("Number of Multiple Forward Slashes", 0, Resource.NumberOfForwardSlashes.ToString());

            grdUrlAnalysis.Rows.Add("Contains IP Address", 0, Resource.HasIPAddress.ToString());
            grdUrlAnalysis.Rows.Add("Contains Port Number", 0, Resource.HasPortNumber.ToString());
            grdUrlAnalysis.Rows.Add("Invalid HTTPS", 0, Resource.IsBadHttps.ToString());

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

        //public void ImportTrusted()
        //{
        //    List<Resource> Resources = new List<Resource>();

        //    var lines = File.ReadLines(@"C:\Users\okazi\Desktop\bookmarks_8_15_17.html");

        //    foreach (var line in lines)
        //    {
        //        string match = GetStrBetweenTags(line, "HREF=", "ADD_DATE");
        //        Resource res = new Resource();

        //        res.Url = match.Trim();

        //        res.ItemType = PhishDataType.Positive;
        //        Resources.Add(res);
        //    }

        //    Repository.AddMultiple(Resources);
        //}

        public string GetStrBetweenTags(string value,
                                       string startTag,
                                       string endTag)
        {
            if (value.Contains(startTag) && value.Contains(endTag))
            {
                int index = value.IndexOf(startTag) + startTag.Length;
                return value.Substring(index, value.IndexOf(endTag) - index);
            }
            else
                return null;
        }

        public void SimulateQueries()
        {
            List<Resource> Resources = Repository.GetAll<Resource>().Take(1000).ToList();

            foreach(var item in Resources)
            {
                //DetectUrl(item.Url);
            }
        }

        public void ConfigItemsGet()
        {
            Dictionary<string, string> Configs = Repository
                                                .GetAll<Configuration>()
                                                .ToDictionary(s => s.Parameter, z => z.Value);

            try
            {
                FrequentItems_MinimumLength = Convert.ToInt32(Configs["FrequentItems_MinimumLength"]);

                FrequentItems_Confidence = Convert.ToInt32(Configs["FrequentItems_Confidence"]);

                UrlAnalysisWeight = Convert.ToDouble(Configs["UrlAnalysisWeight"]);

                UrlFqWeight = Convert.ToDouble(Configs["UrlFqWeight"]);

                PassValue = Convert.ToDouble(Configs["PassValue"]);
            }
            catch (Exception ex)
            {

            }


        }

        public void FrequentItemCounter()
        {
            AlgorithmClass.FrequentItemCounter(PhishDataType.Negative, 
                                                FrequentItems_MinimumLength, 
                                                FrequentItems_Confidence);

            AlgorithmClass.FrequentItemCounter(PhishDataType.Positive,
                                                FrequentItems_MinimumLength,
                                                FrequentItems_Confidence);

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

        private void optimiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptimise Form = new frmOptimise();
            Form.Show();
        }
    }
}
