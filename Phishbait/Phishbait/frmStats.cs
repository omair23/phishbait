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
    public partial class frmStats : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmStats()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            Stats();
        }

        public void Stats()
        {
            grdMain.Rows.Clear();

            grdMain.Rows.Add("Number of resources:", Repository.GetAll<Resource>().Count());

            grdMain.Rows.Add("Number of Frequent Items:", Repository.GetAll<FrequentItem>().Count());

            grdMain.Rows.Add("Number of Ignored Rules:", Repository.GetAll<IgnoreRule>().Count());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
