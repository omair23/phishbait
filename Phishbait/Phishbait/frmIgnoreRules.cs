using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmIgnoreRules : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmIgnoreRules()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            LoadGrid();
        }

        public void LoadGrid()
        {
            List<IgnoreRule> Rules = Repository.GetAll<IgnoreRule>().ToList();

            grdMain.Rows.Clear();

            foreach (var item in Rules)
            {
                grdMain.Rows.Add(item.UID, item.Term);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IgnoreRule Rule = new IgnoreRule();
            Rule.Term = txtTerm.Text;
            Rule.Type = IgnoreType.FrequentItem;

            Repository.Add(Rule);

            txtTerm.Clear();

            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you would like to delete this rule?", "Delete Rule", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow Row = grdMain.Rows[grdMain.SelectedRows[0].Index];

                long UID = Convert.ToInt32(Row.Cells[0].Value);

                IgnoreRule Config = Repository.Find<IgnoreRule>
                                        (s => s.UID == UID)
                                        .FirstOrDefault();

                Repository.Delete(Config);

                LoadGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
