using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmStats : Form
    {
        PhishModel db;
        EFRepository Repository;
        double PassValue;

        public frmStats()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            Dictionary<string, string> Configs = Repository
                                                .GetAll<Configuration>()
                                                .ToDictionary(s => s.Parameter, z => z.Value);

            PassValue = Convert.ToDouble(Configs["PassValue"]);

            Stats();
        }

        public void Stats()
        {
            grdMain.Rows.Clear();

            List<Resource> Resources = Repository.GetAll<Resource>().ToList();

            grdMain.Rows.Add("Number of resources:", Resources.Count());

            grdMain.Rows.Add("Number of Frequent Items:", Repository.GetAll<FrequentItem>().Count());

            grdMain.Rows.Add("Number of Ignored Rules:", Repository.GetAll<IgnoreRule>().Count());

            //Correctly Identified

            int URLCorrect = Resources
                            .Where(s => (s.UrlAnalysisPercentage >= PassValue
                                        && s.ItemType == PhishDataType.Negative)
                                        || (s.UrlAnalysisPercentage < PassValue
                                        && s.ItemType == PhishDataType.Positive))
                            .Count();

            int FrequentCorrect = Resources
                                    .Where(s => (s.UrlFrequentPercentage >= PassValue
                                                && s.ItemType == PhishDataType.Negative)
                                                || (s.UrlFrequentPercentage < PassValue
                                                && s.ItemType == PhishDataType.Positive))
                                    .Count();

            int OverallCorrect = Resources
                                    .Where(s => (s.OverallRiskPercentage >= PassValue
                                                && s.ItemType == PhishDataType.Negative)
                                                || (s.OverallRiskPercentage < PassValue
                                                && s.ItemType == PhishDataType.Positive))
                                    .Count();

            grdCorrect.Rows.Add("URL Analysis:", URLCorrect);

            grdCorrect.Rows.Add("Frequent Item Analysis:", FrequentCorrect);

            grdCorrect.Rows.Add("Overall Analysis:", OverallCorrect);

            //Incorrectly Identified
            int URLIncorrect = Resources
                            .Where(s => (s.UrlAnalysisPercentage < PassValue
                                        && s.ItemType == PhishDataType.Negative)
                                        || (s.UrlAnalysisPercentage >= PassValue
                                        && s.ItemType == PhishDataType.Positive))
                            .Count();

            int FrequentIncorrect = Resources
                                    .Where(s => (s.UrlFrequentPercentage < PassValue
                                                && s.ItemType == PhishDataType.Negative)
                                                || (s.UrlFrequentPercentage >= PassValue
                                                && s.ItemType == PhishDataType.Positive))
                                    .Count();

            int OverallIncorrect = Resources
                                    .Where(s => (s.OverallRiskPercentage < PassValue
                                                && s.ItemType == PhishDataType.Negative)
                                                || (s.OverallRiskPercentage >= PassValue
                                                && s.ItemType == PhishDataType.Positive))
                                    .Count();

            grdIncorrect.Rows.Add("URL Analysis:", URLIncorrect);

            grdIncorrect.Rows.Add("Frequent Item Analysis:", FrequentIncorrect);

            grdIncorrect.Rows.Add("Overall Analysis:", OverallIncorrect);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
