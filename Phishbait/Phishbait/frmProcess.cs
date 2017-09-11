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
    public partial class frmProcess : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmProcess()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            InitGrid();
        }

        public void InitGrid()
        {
            grdLStudy.Rows.Clear();

            grdLStudy.Rows.Add("Number of Full Stops", "2", "14 %");
            grdLStudy.Rows.Add("Number of @ Symbols", "0", "14 %");
            grdLStudy.Rows.Add("Number of Double Forward Slashes", "1", "14 %");
            grdLStudy.Rows.Add("Number of Multiple Forward Slashes", "0", "14 %");

            grdLStudy.Rows.Add("Contains IP Address", "0", "14 %");
            grdLStudy.Rows.Add("Contains Port Number", "0", "14 %");
            grdLStudy.Rows.Add("Invalid HTTPS", "0", "14 %");
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            grdComp.Rows.Clear();

            List<Resource> BadUrls = Repository
                                    .Find<Resource>(s => s.ItemType == PhishDataType.Negative)
                                    .ToList();

            //foreach(var Item in BadUrls)
            //{
            //    Item.SetDetectionVariables();
            //}

            int FullStops = Convert.ToInt32(Math.Round(BadUrls.Average(s => s.NumberOfFullStops)));

            double AtSymbols = Math.Round(BadUrls.Average(s => s.NumberOfAtSymbols));

            double ForwardSlashes = Math.Round(BadUrls.Average(s => s.NumberOfForwardSlashes));

            double MultipleForwardSlashes = Math.Round(BadUrls.Average(s => s.NumberOfMultipleForwardSlashes));

            double IPAddresses = Math.Round(BadUrls.Average(s => Convert.ToInt32(s.HasIPAddress)));

            double PortNumbers = Math.Round(BadUrls.Average(s => Convert.ToInt32(s.HasPortNumber)));

            double InvalidHttps = Math.Round(BadUrls.Average(s => Convert.ToInt32(s.IsBadHttps)));

            grdComp.Rows.Add("Number of Full Stops", FullStops.ToString(), "14 %");
            grdComp.Rows.Add("Number of @ Symbols", "0", "14 %");
            grdComp.Rows.Add("Number of Double Forward Slashes", "1", "14 %");
            grdComp.Rows.Add("Number of Multiple Forward Slashes", "0", "14 %");

            grdComp.Rows.Add("Contains IP Address", "0", "14 %");
            grdComp.Rows.Add("Contains Port Number", "0", "14 %");
            grdComp.Rows.Add("Invalid HTTPS", "0", "14 %");
        }
    }
}
