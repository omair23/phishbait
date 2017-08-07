using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmImport : Form
    {
        EFRepository Repository;
        PhishModel db;

        public frmImport()
        {
            InitializeComponent();
            db = new PhishModel();
            Repository = new EFRepository(db);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            dlgFile.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(dlgFile.FileName))
            {
                Stream Stream = dlgFile.OpenFile();
                ExcelDataImport(Stream);
            }
            else if (!String.IsNullOrEmpty(dlgText.FileName))
            {
                MessageBox.Show("File successfully submitted for processing");
                ImportTextFile();
                Close();
            }
            else
            {
                MessageBox.Show("Please open a file first");
            }
        }

        public bool ExcelDataImport(Stream Stream)
        {
            bool IsPhishing = false;
            bool IsTrusted = false;

            if (radPhishing.Checked)
                IsPhishing = true;
            if (radTrusted.Checked)
                IsTrusted = true;

            //var package = new ExcelPackage(Stream);
            //ExcelWorksheet Sheet = package.Workbook.Worksheets[1];

            //List<Resource> Resources = new List<Resource>();

            //for (int i = 2; i <= Sheet.Dimension.End.Row; i++)
            //{
            //    try
            //    {
            //        Resource Res = new Resource();
            //        Res.Url = Sheet.Cells[i, 1].Value.ToString();

            //        Resources.Add(Res);
            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }
            //}

            //package.Dispose();
            return true;
        }

        private void btnTextFile_Click(object sender, EventArgs e)
        {
            dlgText.ShowDialog();
        }

        public void ImportTextFile()
        {
            PhishDataType Type = PhishDataType.Undefined;

            if (radPhishing.Checked)
                Type = PhishDataType.Negative;
            if (radTrusted.Checked)
                Type = PhishDataType.Positive;

            List<Resource> Resources = new List<Resource>();

            var lines = File.ReadLines(dlgText.FileName);
            
            foreach (var line in lines)
            {
                Resource res = new Resource(line);
                res.ItemType = Type;
                Resources.Add(res);
            }

            Repository.AddMultiple(Resources);
        }
    }
}
