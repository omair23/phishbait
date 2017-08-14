using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmFrequent : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmFrequent()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            LoadGrid(PhishDataType.Undefined);
        }

        public void LoadGrid(PhishDataType Type)
        {
            List<FrequentItem> Items = Repository
                                        .Find<FrequentItem>(s => s.ItemType == Type)
                                        .OrderByDescending(s => s.Frequency)
                                        //TO DO Remove Limit on results!!
                                        .Take(40)
                                        .ToList();

            grdMain.Rows.Clear();

            foreach (var item in Items)
            {
                grdMain.Rows.Add(item.UID, 
                                item.Term, 
                                item.Frequency.ToString());
            }
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            LoadGrid(PhishDataType.Negative);
        }

        private void btnUndefined_Click(object sender, EventArgs e)
        {
            LoadGrid(PhishDataType.Undefined);
        }

        private void btnPositive_Click(object sender, EventArgs e)
        {
            LoadGrid(PhishDataType.Positive);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you would like to delete this frequent item?", "Delete Frequent Item", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow Row = grdMain.Rows[grdMain.SelectedRows[0].Index];

                long UID = Convert.ToInt32(Row.Cells[0].Value);

                FrequentItem FrequentItem = Repository.Find<FrequentItem>
                                        (s => s.UID == UID)
                                        .FirstOrDefault();

                Repository.Delete(FrequentItem);

                LoadGrid(PhishDataType.Undefined);
            }
        }
    }
}
