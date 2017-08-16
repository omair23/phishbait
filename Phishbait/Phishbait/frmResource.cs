using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmResource : Form
    {
        PhishModel db;
        EFRepository Repository;
        List<Resource> Items;

        public frmResource()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            Items = Repository
                    .GetAll<Resource>()
                    .OrderBy(s => s.ItemType)
                    .ToList();

            grdMain.Rows.Clear();

            //TO DO Remove Take Limit
            foreach (var item in Items.Take(50))
            {
                grdMain.Rows.Add(item.UID,
                                item.Url,
                                item.UrlAnalysisPercentage.ToString(),
                                item.UrlFrequentPercentage.ToString(),
                                item.OverallRiskPercentage.ToString(),
                                item.ItemType.ToString()
                                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string Path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                byte[] file;

                string ExcelFileName = Path + @"\ExcelFile.xlsx";
                FileInfo fi = new FileInfo(ExcelFileName);

                List<object[]> testData = new List<object[]>();

                foreach (var item in Items)
                {
                    testData.Add(new object[] {
                    item.UID,
                    item.Url,
                    item.UrlAnalysisPercentage,
                    item.UrlFrequentPercentage,
                    item.OverallRiskPercentage,
                    item.ItemType.ToString()});
                }

                using (var package = new ExcelPackage(fi))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    worksheet.Cells["A2"].LoadFromArrays(testData);

                    ExcelWorksheet Analysis = package.Workbook.Worksheets[2];

                    var stream = new MemoryStream(package.GetAsByteArray());
                    file = stream.ToArray();
                }

                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Phishbait Analysis.xlsx";
                save.Filter = "Excel File | *.xlsx";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, file);
                }

                MessageBox.Show("File successfully generated");
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
