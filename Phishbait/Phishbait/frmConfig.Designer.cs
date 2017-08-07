namespace Phishbait
{
    partial class frmIgnore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.txtUpdateId = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUpdateValue = new System.Windows.Forms.TextBox();
            this.txtUpdateParameter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Parameter,
            this.Value});
            this.grdMain.Location = new System.Drawing.Point(12, 51);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.RowHeadersVisible = false;
            this.grdMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMain.Size = new System.Drawing.Size(515, 190);
            this.grdMain.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Parameter
            // 
            this.Parameter.HeaderText = "Parameter";
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Width = 250;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 250;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(166, 105);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtParameter
            // 
            this.txtParameter.Location = new System.Drawing.Point(82, 30);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(175, 20);
            this.txtParameter.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(82, 68);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(175, 20);
            this.txtValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParameter);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Location = new System.Drawing.Point(533, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 146);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Configuration";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(13, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(13, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(452, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.btnCancel);
            this.grpUpdate.Controls.Add(this.txtUpdateParameter);
            this.grpUpdate.Controls.Add(this.label4);
            this.grpUpdate.Controls.Add(this.txtUpdateId);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Controls.Add(this.label3);
            this.grpUpdate.Controls.Add(this.txtUpdateValue);
            this.grpUpdate.Location = new System.Drawing.Point(533, 164);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(270, 139);
            this.grpUpdate.TabIndex = 10;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Update Configuration";
            this.grpUpdate.Visible = false;
            // 
            // txtUpdateId
            // 
            this.txtUpdateId.Location = new System.Drawing.Point(126, 105);
            this.txtUpdateId.Name = "txtUpdateId";
            this.txtUpdateId.Size = new System.Drawing.Size(34, 20);
            this.txtUpdateId.TabIndex = 6;
            this.txtUpdateId.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(166, 100);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 29);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value:";
            // 
            // txtUpdateValue
            // 
            this.txtUpdateValue.Location = new System.Drawing.Point(82, 64);
            this.txtUpdateValue.Name = "txtUpdateValue";
            this.txtUpdateValue.Size = new System.Drawing.Size(175, 20);
            this.txtUpdateValue.TabIndex = 3;
            // 
            // txtUpdateParameter
            // 
            this.txtUpdateParameter.Location = new System.Drawing.Point(82, 29);
            this.txtUpdateParameter.Name = "txtUpdateParameter";
            this.txtUpdateParameter.ReadOnly = true;
            this.txtUpdateParameter.Size = new System.Drawing.Size(175, 20);
            this.txtUpdateParameter.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parameter:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(21, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 309);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdMain);
            this.Name = "frmConfig";
            this.Text = "Delete";
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUpdateValue;
        private System.Windows.Forms.TextBox txtUpdateId;
        private System.Windows.Forms.TextBox txtUpdateParameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
    }
}