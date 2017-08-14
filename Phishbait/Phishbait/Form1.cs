using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        }

        public void SimulateQueries()
        {
            List<Resource> Resources = Repository.GetAll<Resource>().Take(1000).ToList();

            foreach(var item in Resources)
            {
                DetectUrl(item.Url);
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

        public void DetectUrl(string Url)
        {
            Resource Resource = Repository
                    .Find<Resource>(s => s.Url == Url)
                    .FirstOrDefault();

            bool IsNewRecord = false;

            if (Resource == null)
            {
                Resource = new Resource(Url);
                IsNewRecord = true;
            }

            Resource = URLDetection(Url, Resource);

            Resource = FrequentItemDetection(Url, Resource);

            Resource.OverallRiskPercentage = (Resource.UrlFrequentPercentage * UrlFqWeight / 100)
                                           + (Resource.UrlAnalysisPercentage * UrlAnalysisWeight / 100);

            Resource.OverallRiskPercentage = Math.Round(Resource.OverallRiskPercentage, 2);

            if (IsNewRecord)
                Repository.Add(Resource);
            else
                Repository.Update(Resource);

            txtWeights.Text = "Weightings:"
                                + Environment.NewLine
                                + "Url Frequent Items = "
                                + UrlFqWeight.ToString() + "%"
                                + Environment.NewLine
                                + "Url Text Analysis = "
                                + UrlAnalysisWeight.ToString() + "%";

            lblOverallAnalysis.Text = Resource.OverallRiskPercentage.ToString() + " %";

            if (Resource.OverallRiskPercentage >= PassValue)
                lblOverallAnalysis.ForeColor = System.Drawing.Color.Red;
            else
                lblOverallAnalysis.ForeColor = System.Drawing.Color.Green;

            grpOverall.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //SimulateQueries();

            string Url = txtUrl.Text;

            DetectUrl(Url);

            //string htmlCode;

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

        public Resource URLDetection(string Url, Resource Resource)
        {
            int ProbabilityCounter = 0;

            if (CombinedStats == null)
            {
                MessageBox.Show("Error: Cannot conduct analysis, baseline data not found");
                return Resource;
            }

            Resource.SetDetectionVariables();

            //if (Resource.NumberOfFullStops > CombinedStats.FullStopAverage)
            //    ProbabilityCounter += 1;

            //if (Resource.NumberOfAtSymbols > CombinedStats.AtSymbolsAverage)
            //    ProbabilityCounter += 1;

            //if (Resource.NumberOfForwardSlashes > CombinedStats.ForwardSlashAverage)
            //    ProbabilityCounter += 1;

            //if (Resource.NumberOfMultipleForwardSlashes > CombinedStats.MultipleForwardSlashAverage)
            //    ProbabilityCounter += 1;

            //if (CombinedStats.AverageIPAddress <= 0.5)
            //{
            //    if (Resource.HasIPAddress)
            //        ProbabilityCounter += 1;
            //}

            //if (CombinedStats.AveragePortNumbers <= 0.5)
            //{
            //    if (Resource.HasPortNumber)
            //        ProbabilityCounter += 1;
            //}

            //if (CombinedStats.AverageBadHttps <= 0.5)
            //{
            //    if (Resource.IsBadHttps)
            //        ProbabilityCounter += 1;
            //}

            //New Method
            double OverallUrl = 0;

            if (Resource.IsBadHttps)
                OverallUrl += CombinedStats.AverageBadHttps;

            if (Resource.HasPortNumber)
                OverallUrl += CombinedStats.AveragePortNumbers;

            if (Resource.HasIPAddress)
                OverallUrl += CombinedStats.AverageIPAddress;

            if (Resource.NumberOfFullStops > CombinedStats.FullStopAverage)
                OverallUrl += (Resource.NumberOfFullStops - CombinedStats.FullStopAverage);

            if (Resource.NumberOfAtSymbols > CombinedStats.AtSymbolsAverage)
                OverallUrl += (Resource.NumberOfAtSymbols - CombinedStats.AtSymbolsAverage);

            if (Resource.NumberOfForwardSlashes > CombinedStats.ForwardSlashAverage)
                OverallUrl += (Resource.NumberOfForwardSlashes - CombinedStats.ForwardSlashAverage);

            if (Resource.NumberOfMultipleForwardSlashes > CombinedStats.MultipleForwardSlashAverage)
                OverallUrl += (Resource.NumberOfMultipleForwardSlashes - CombinedStats.MultipleForwardSlashAverage);

            OverallUrl = OverallUrl * 100;
            //txtUrl.Text = OverallUrl.ToString();
            //End of new method

            double ProbabilityPercentage = ProbabilityCounter * 100 / 7;
            ProbabilityPercentage = OverallUrl;

            //if (ProbabilityCounter >= 3)
            if (OverallUrl > PassValue)
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

            if (ProbabilityPercentage > 100)
                ProbabilityPercentage = 100;

            Resource.UrlAnalysisPercentage = ProbabilityPercentage;

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

            return Resource;
        }

        #region FrequentItems

        public Resource FrequentItemDetection(string Url, Resource Resource)
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
                            //Perhaps reconsider
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
            if (ProbabilityCounter >= PassValue)
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

            Resource.UrlFrequentPercentage = ProbabilityCounter;

            grpFrequent.Visible = true;

            return Resource;
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

        private void resourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResource Form = new frmResource();
            Form.Show();
        }
    }
}
