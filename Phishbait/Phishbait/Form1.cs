using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class Form1 : Form
    {
        int FrequentItems_MinimumLength = 3;
        int FrequentItems_Confidence = 3;
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
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string Url = txtUrl.Text;

            string htmlCode;

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

            URLDetection(Url);

            FrequentItemDetection(Url);
        }

        public void URLDetection(string Url)
        {
            bool IsNewRecord = false;

            Resource Resource = Repository
                                .Find<Resource>(s => s.Url == Url)
                                .FirstOrDefault();

            if (Resource == null)
            {
                Resource = new Resource(Url);
                IsNewRecord = true;
            }

            int ProbabilityCounter = 0;

            if (CombinedStats == null)
            {
                MessageBox.Show("Error: Cannot conduct analysis, baseline data not found");
                return;
            }

            Resource.SetDetectionVariables();

            if (Resource.NumberOfFullStops > CombinedStats.FullStopAverage)
                ProbabilityCounter += 1;

            if (Resource.NumberOfAtSymbols > CombinedStats.AtSymbolsAverage)
                ProbabilityCounter += 1;

            if (Resource.NumberOfForwardSlashes > CombinedStats.ForwardSlashAverage)
                ProbabilityCounter += 1;

            if (Resource.NumberOfMultipleForwardSlashes > CombinedStats.MultipleForwardSlashAverage)
                ProbabilityCounter += 1;

            if (CombinedStats.AverageIPAddress <= 0.5)
            {
                if (Resource.HasIPAddress)
                    ProbabilityCounter += 1;
            }

            if (CombinedStats.AveragePortNumbers <= 0.5)
            {
                if (Resource.HasPortNumber)
                    ProbabilityCounter += 1;
            }

            if (CombinedStats.AverageBadHttps <= 0.5)
            {
                if (Resource.IsBadHttps)
                    ProbabilityCounter += 1;
            }

            if (ProbabilityCounter >= 3)
                Resource.IsPhishing = true;

            if (Resource.IsPhishing)
            {
                lblPhishingInd.Text = String.Format("Based on the testing performed, {0} is a phishing site according to the analysis shown below", Url);
                lblFishPercentage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPhishingInd.Text = String.Format("Based on the testing performed, {0} is not a phishing site according to the analysis shown below", Url);
                lblFishPercentage.ForeColor = System.Drawing.Color.Green;
            }

            double ProbabilityPercentage = ProbabilityCounter * 100 / 7;
            lblFishPercentage.Text = ProbabilityPercentage.ToString() + " %";

            grdUrlAnalysis.Rows.Clear();

            grdUrlAnalysis.Rows.Add("Number of Full Stops", CombinedStats.FullStopAverage.ToString(), Resource.NumberOfFullStops.ToString());
            grdUrlAnalysis.Rows.Add("Number of @ Symbols", CombinedStats.AtSymbolsAverage.ToString(), Resource.NumberOfAtSymbols.ToString());
            grdUrlAnalysis.Rows.Add("Number of Double Forward Slashes", CombinedStats.ForwardSlashAverage.ToString(), Resource.NumberOfForwardSlashes.ToString());
            grdUrlAnalysis.Rows.Add("Number of Multiple Forward Slashes", CombinedStats.MultipleForwardSlashAverage.ToString(), Resource.NumberOfForwardSlashes.ToString());

            grdUrlAnalysis.Rows.Add("Contains IP Address", CombinedStats.AverageIPAddress.ToString(), Resource.HasIPAddress.ToString());
            grdUrlAnalysis.Rows.Add("Contains Port Number", CombinedStats.AveragePortNumbers.ToString(), Resource.HasPortNumber.ToString());
            grdUrlAnalysis.Rows.Add("Invalid HTTPS", CombinedStats.AverageBadHttps.ToString(), Resource.IsBadHttps.ToString());

            grpUrl.Visible = true;

            if (IsNewRecord)
                Repository.Add(Resource);
            else
                Repository.Update(Resource);
        }

        #region FrequentItems

        public void FrequentItemDetection(string Url)
        {
            //Cleaning URL
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            String StrippedUrl = rgx.Replace(Url, " ");
            var SplitUrl = StrippedUrl.Split(null).ToList();
            SplitUrl.RemoveAll(item => String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item));

            List<FrequentItem> PositiveFrequentItems = Repository
                                                .Find<FrequentItem>(s => s.ItemType == PhishDataType.Positive)
                                                .ToList();

            List<FrequentItem> NegativeFrequentItems = Repository
                                                .Find<FrequentItem>(s => s.ItemType == PhishDataType.Negative)
                                                .ToList();


            List<IgnoreRule> IgnoreRules = Repository
                                            .Find<IgnoreRule>(s => s.Type == IgnoreType.FrequentItem)
                                            .ToList();

            List<string> PositiveNonUnion = PositiveFrequentItems
                            .Select(s => s.Term)
                            .Intersect(SplitUrl)
                            .Except(IgnoreRules.Select(x => x.Term))
                            .ToList();

            List<string> UnionItems = NegativeFrequentItems
                            .Select(s => s.Term)
                            .Intersect(SplitUrl)
                            .Except(IgnoreRules.Select(x => x.Term))
                            .Except(PositiveNonUnion)
                            .ToList();

            int TotalRecords = SplitUrl.Count - PositiveNonUnion.Count;
            int ProbabilityCounter = 0;
            bool IsPhishing = false;

            grdFreq.Rows.Clear();

            foreach (var item in UnionItems)
            {
                FrequentItem fitem = NegativeFrequentItems.Where(s => s.Term == item).FirstOrDefault();
                grdFreq.Rows.Add(item, Convert.ToString(fitem.Frequency));
                ProbabilityCounter += 1;// fitem.Frequency;
            }

            ProbabilityCounter = ProbabilityCounter * 100 / TotalRecords;

            // 50% probability
            if (ProbabilityCounter >= 50)
                IsPhishing = true;

            if (IsPhishing)
            {
                txtFreqM.Text = String.Format("Based on the testing performed, {0} is a phishing site according to the analysis shown below", Url);
                lblFreqPercentage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtFreqM.Text = String.Format("Based on the testing performed, {0} is not a phishing site according to the analysis shown below", Url);
                lblFreqPercentage.ForeColor = System.Drawing.Color.Green;
            }

            lblFreqPercentage.Text = ProbabilityCounter.ToString() + " %";

            grpFrequent.Visible = true;
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
        #endregion

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

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStats Form = new frmStats();
            Form.Show();
        }
    }
}
