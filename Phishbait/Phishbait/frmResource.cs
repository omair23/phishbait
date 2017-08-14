using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            foreach (var item in Items)
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
            //try
            //{
            //    byte[] file;

            //    FileInfo fi = new FileInfo("wwwroot/assets/fulcrum/apps/Tax180/docs/OutputEligibleTemplate.xlsx");
            //    var testData = _tax180Service.GetEligibleSnapshotsForExcel(AssessmentId);
            //    using (var package = new ExcelPackage(fi))
            //    {
            //        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            //        worksheet.InsertRow(5, testData.Count() - 1);
            //        worksheet.Cells["A5"].LoadFromArrays(testData);
            //        worksheet.Cells["C2"].Value = assessment.EndDate;
            //        worksheet.Cells["F2"].Value = clientinfo.RegisteredName;
            //        worksheet.Cells["I2"].Value = assessment.DateOfReport;

            //        worksheet.Cells[testData.Count() + 5, 20].Formula = "SUM(T5:T" + (testData.Count() + 4).ToString() + ")";
            //        worksheet.Cells[testData.Count() + 5, 21].Formula = "SUM(U5:U" + (testData.Count() + 4).ToString() + ")";
            //        worksheet.Cells[testData.Count() + 5, 22].Formula = "SUM(V5:V" + (testData.Count() + 4).ToString() + ")";

            //        var stream = new MemoryStream(package.GetAsByteArray());
            //        file = stream.ToArray();
            //    }

            //    string filename = assessment.Name + "_Eligible.xlsx";
            //    return File(file, "application/octet-stream", filename);
            //}
            //catch (Exception ex)
            //{
                
            //}
        }
    }
}
