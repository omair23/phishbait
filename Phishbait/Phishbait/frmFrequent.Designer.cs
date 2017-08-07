namespace Phishbait
{
    partial class frmFrequent
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.btnUndefined = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNegative = new System.Windows.Forms.Button();
            this.btnPositive = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(11, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 29);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Value,
            this.Frequency});
            this.grdMain.Location = new System.Drawing.Point(11, 99);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.RowHeadersVisible = false;
            this.grdMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMain.Size = new System.Drawing.Size(374, 225);
            this.grdMain.TabIndex = 14;
            // 
            // btnUndefined
            // 
            this.btnUndefined.Location = new System.Drawing.Point(88, 10);
            this.btnUndefined.Name = "btnUndefined";
            this.btnUndefined.Size = new System.Drawing.Size(95, 36);
            this.btnUndefined.TabIndex = 18;
            this.btnUndefined.Text = "Undefined";
            this.btnUndefined.UseVisualStyleBackColor = true;
            this.btnUndefined.Click += new System.EventHandler(this.btnUndefined_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter By:";
            // 
            // btnNegative
            // 
            this.btnNegative.Location = new System.Drawing.Point(189, 10);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(95, 36);
            this.btnNegative.TabIndex = 20;
            this.btnNegative.Text = "Negative";
            this.btnNegative.UseVisualStyleBackColor = true;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // btnPositive
            // 
            this.btnPositive.Location = new System.Drawing.Point(290, 10);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.Size = new System.Drawing.Size(95, 36);
            this.btnPositive.TabIndex = 21;
            this.btnPositive.Text = "Positive";
            this.btnPositive.UseVisualStyleBackColor = true;
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Value
            // 
            this.Value.HeaderText = "Term";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 250;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            // 
            // frmFrequent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 371);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.btnNegative);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUndefined);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdMain);
            this.Name = "frmFrequent";
            this.Text = "Frequent Items";
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.Button btnUndefined;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNegative;
        private System.Windows.Forms.Button btnPositive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
    }
}