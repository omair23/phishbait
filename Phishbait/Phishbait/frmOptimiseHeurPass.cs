using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmOptimiseHeurPass : Form
    {
        PhishModel db;
        EFRepository Repository;
        Dictionary<string, string> ConfigItems;
        List<Resource> PhishingSites;
        List<Resource> TrustedSites;

        public frmOptimiseHeurPass()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            ConfigItems = Repository
                        .GetAll<Configuration>()
                        .ToDictionary(s => s.Parameter, z => z.Value);
        }

        private void btnCompute_Click(object sender, System.EventArgs e)
        {
            PhishingSites = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                            .Take(1000) //TO DO Remove Limit
                            .ToList();

            TrustedSites = Repository
                            .Find<Resource>(s => s.ItemType == PhishDataType.Positive)
                            .Take(1000) //TO DO Remove Limit
                            .ToList();

            chtMain.Series.Add("True Positives");
            chtMain.Series[0].Name = "True Positives";
            chtMain.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chtMain.Series.Add("False Positives");
            chtMain.Series[1].Name = "False Positives (Inverted)";
            chtMain.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chtMain.Series.Add("False Negatives");
            chtMain.Series[2].Name = "False Negatives (Inverted)";
            chtMain.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chtMain.Series.Add("True Negatives");
            chtMain.Series[3].Name = "True Negatives";
            chtMain.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //chtMain.ChartAreas[0].AxisX.Minimum = 0;

            for (int i = 1; i <=15; i++)
            {
                ComputeScore(i);
            }

            FindOptimalScore();

            ExportToExcel();
        }

        public void FindOptimalScore()
        {
            double HighestValue = 0;
            int Score = 1;

            foreach (DataGridViewRow row in grdMain.Rows)
            {
                if (Convert.ToDouble(row.Cells[1].Value) >= HighestValue)
                {
                    Score = Convert.ToInt32(row.Cells[0].Value);
                }
            }

            var Test = 1;
        }

        public void ComputeScore(int Score)
        {
            int TPCount = 0;
            int FNCount = 0;
            foreach(var item in PhishingSites)
            {
                cPhishbait Class = new cPhishbait(item.Url, ConfigItems, true, true, false, true, true, Score);

                if (Class.LayerDetected == 0)
                    FNCount += 1;
                else
                    TPCount += 1; 
            }
            double TruePositive = Math.Round((double)TPCount / PhishingSites.Count * 100, 4);
            double FalseNegative = Math.Round((double)FNCount / PhishingSites.Count * 100, 4); //Inverted

            int FPCount = 0;
            int TNCount = 0;
            foreach (var item in TrustedSites)
            {
                cPhishbait Class = new cPhishbait(item.Url, ConfigItems, true, true, false, true, true, Score);

                if (Class.LayerDetected == 0)
                    TNCount += 1; 
                else
                    FPCount += 1;
            }
            double FalsePositive = Math.Round((double)FPCount / TrustedSites.Count * 100, 4); //Inverted
            double TrueNegative = Math.Round((double)TNCount / TrustedSites.Count * 100, 4);


            grdMain.Rows.Add(Score.ToString(), 
                            TruePositive.ToString(), 
                            FalsePositive.ToString(),
                            FalseNegative.ToString(),
                            TrueNegative.ToString());


            //chtMain.Series[0].Points.AddXY(Score, TruePositive);
            //chtMain.Series[1].Points.AddXY(Score, FalsePositive);
            //chtMain.Series[2].Points.AddXY(Score, FalseNegative);
            //chtMain.Series[3].Points.AddXY(Score, TrueNegative);
        }


        private void ExportToExcel()
        {
            try
            {
                string Path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                byte[] file;

                string ExcelFileName = Path + @"\ExcelFile.xlsx";
                FileInfo fi = new FileInfo(ExcelFileName);

                List<object[]> testData = new List<object[]>();

                foreach (DataGridViewRow row in grdMain.Rows)
                {
                    testData.Add(new object[] {
                    row.Cells[0].Value,
                    row.Cells[1].Value,
                    row.Cells[2].Value,
                    row.Cells[3].Value,
                    row.Cells[4].Value});
                }

                using (var package = new ExcelPackage(fi))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    worksheet.Cells["A2"].LoadFromArrays(testData);

                    var stream = new MemoryStream(package.GetAsByteArray());
                    file = stream.ToArray();
                }

                File.WriteAllBytes(@"C:\Users\okazi\Desktop\HeuristicScore.xlsx", file);
                

                //SaveFileDialog save = new SaveFileDialog();
                //save.FileName = "Phishbait Analysis.xlsx";
                //save.Filter = "Excel File | *.xlsx";

                //if (save.ShowDialog() == DialogResult.OK)
                //{
                //    File.WriteAllBytes(save.FileName, file);
                //}

                MessageBox.Show("File successfully generated");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
