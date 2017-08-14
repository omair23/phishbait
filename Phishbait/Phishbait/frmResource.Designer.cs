namespace Phishbait
{
    partial class frmResource
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
            this.btnClose = new System.Windows.Forms.Button();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlAnalysisPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlFrequentPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverallRiskPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(744, 325);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 29);
            this.btnClose.TabIndex = 18;
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
            this.Url,
            this.UrlAnalysisPercentage,
            this.UrlFrequentPercentage,
            this.OverallRiskPercentage,
            this.ResourceType});
            this.grdMain.Location = new System.Drawing.Point(12, 12);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.RowHeadersVisible = false;
            this.grdMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdMain.Size = new System.Drawing.Size(823, 307);
            this.grdMain.TabIndex = 17;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 250;
            // 
            // UrlAnalysisPercentage
            // 
            this.UrlAnalysisPercentage.HeaderText = "Url Analysis Percentage";
            this.UrlAnalysisPercentage.Name = "UrlAnalysisPercentage";
            this.UrlAnalysisPercentage.ReadOnly = true;
            // 
            // UrlFrequentPercentage
            // 
            this.UrlFrequentPercentage.HeaderText = "UrlFrequentPercentage";
            this.UrlFrequentPercentage.Name = "UrlFrequentPercentage";
            this.UrlFrequentPercentage.ReadOnly = true;
            // 
            // OverallRiskPercentage
            // 
            this.OverallRiskPercentage.HeaderText = "OverallRiskPercentage";
            this.OverallRiskPercentage.Name = "OverallRiskPercentage";
            this.OverallRiskPercentage.ReadOnly = true;
            // 
            // ResourceType
            // 
            this.ResourceType.HeaderText = "Type";
            this.ResourceType.Name = "ResourceType";
            this.ResourceType.ReadOnly = true;
            this.ResourceType.Width = 250;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 325);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(91, 29);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 366);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdMain);
            this.Name = "frmResource";
            this.Text = "Resources";
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlAnalysisPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlFrequentPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverallRiskPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourceType;
        private System.Windows.Forms.Button btnExport;
    }
}