namespace Phishbait
{
    partial class frmProcess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdLStudy = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Analysis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpComp = new System.Windows.Forms.GroupBox();
            this.grdComp = new System.Windows.Forms.DataGridView();
            this.btnCompute = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLStudy)).BeginInit();
            this.grpComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdLStudy);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Literature Study Results";
            // 
            // grdLStudy
            // 
            this.grdLStudy.AllowUserToAddRows = false;
            this.grdLStudy.AllowUserToDeleteRows = false;
            this.grdLStudy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLStudy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.SystemParameter,
            this.Analysis});
            this.grdLStudy.Location = new System.Drawing.Point(6, 19);
            this.grdLStudy.Name = "grdLStudy";
            this.grdLStudy.ReadOnly = true;
            this.grdLStudy.RowHeadersVisible = false;
            this.grdLStudy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLStudy.Size = new System.Drawing.Size(453, 204);
            this.grdLStudy.TabIndex = 8;
            // 
            // ParamName
            // 
            this.ParamName.HeaderText = "Criteria";
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            this.ParamName.Width = 250;
            // 
            // SystemParameter
            // 
            this.SystemParameter.HeaderText = "Value";
            this.SystemParameter.Name = "SystemParameter";
            this.SystemParameter.ReadOnly = true;
            // 
            // Analysis
            // 
            this.Analysis.HeaderText = "Weight (Assumed)";
            this.Analysis.Name = "Analysis";
            this.Analysis.ReadOnly = true;
            // 
            // grpComp
            // 
            this.grpComp.Controls.Add(this.grdComp);
            this.grpComp.Location = new System.Drawing.Point(490, 70);
            this.grpComp.Name = "grpComp";
            this.grpComp.Size = new System.Drawing.Size(472, 238);
            this.grpComp.TabIndex = 1;
            this.grpComp.TabStop = false;
            this.grpComp.Text = "Literature Study Results";
            // 
            // grdComp
            // 
            this.grdComp.AllowUserToAddRows = false;
            this.grdComp.AllowUserToDeleteRows = false;
            this.grdComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdComp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.grdComp.Location = new System.Drawing.Point(6, 19);
            this.grdComp.Name = "grdComp";
            this.grdComp.ReadOnly = true;
            this.grdComp.RowHeadersVisible = false;
            this.grdComp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdComp.Size = new System.Drawing.Size(453, 204);
            this.grdComp.TabIndex = 8;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(513, 30);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 2;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Criteria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 445);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.grpComp);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProcess";
            this.Text = "Process";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLStudy)).EndInit();
            this.grpComp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdLStudy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Analysis;
        private System.Windows.Forms.GroupBox grpComp;
        private System.Windows.Forms.DataGridView grdComp;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}