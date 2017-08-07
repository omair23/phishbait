using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phishbait
{
    public partial class frmIgnore : Form
    {
        PhishModel db;
        EFRepository Repository;

        public frmIgnore()
        {
            InitializeComponent();

            db = new PhishModel();
            Repository = new EFRepository(db);

            LoadGrid();
        }

        public void LoadGrid()
        {
            List<Configuration> Configs = Repository.GetAll<Configuration>().ToList();

            grdMain.Rows.Clear();

            foreach (var item in Configs)
            {
                grdMain.Rows.Add(item.UID, item.Parameter, item.Value);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = grdMain.Rows[grdMain.SelectedRows[0].Index];

            txtUpdateId.Text = Row.Cells[0].Value.ToString();
            txtUpdateParameter.Text = Row.Cells[1].Value.ToString();
            txtUpdateValue.Text = Row.Cells[2].Value.ToString();

            grpUpdate.Visible = true;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpUpdate.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Configuration Config = new Configuration();
            Config.Parameter = txtParameter.Text;
            Config.Value = txtValue.Text;

            Repository.Add(Config);
            LoadGrid();

            txtParameter.Clear();
            txtValue.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            long UID = Convert.ToInt32(txtUpdateId.Text);

            Configuration Config = Repository.Find<Configuration>
                                    (s => s.UID == UID)
                                    .FirstOrDefault();

            //Config.Parameter = txtParameter.Text;
            Config.Value = txtUpdateValue.Text;

            Repository.Update(Config);
            LoadGrid();
            grpUpdate.Visible = false;

            txtUpdateId.Clear();
            txtUpdateValue.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that you would like to delete this configuration item?", "Delete Configuration", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow Row = grdMain.Rows[grdMain.SelectedRows[0].Index];

                long UID = Convert.ToInt32(Row.Cells[0].Value);

                Configuration Config = Repository.Find<Configuration>
                                        (s => s.UID == UID)
                                        .FirstOrDefault();

                Repository.Delete(Config);

                LoadGrid();
                grpUpdate.Visible = false;
            }
        }
    }
}
