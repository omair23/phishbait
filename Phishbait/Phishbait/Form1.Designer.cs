namespace Phishbait
{
    partial class Form1
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblFishPercentage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpFrequent = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFreqPercentage = new System.Windows.Forms.Label();
            this.txtFreqM = new System.Windows.Forms.TextBox();
            this.grdFreq = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpUrl = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdUrlAnalysis = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Analysis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPhishingInd = new System.Windows.Forms.TextBox();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequentItemCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLAnalysisCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpFrequent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreq)).BeginInit();
            this.grpUrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUrlAnalysis)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(412, 11);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(147, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Verify";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(159, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(231, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(10, 16);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(143, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "Please enter a URL to verify:";
            // 
            // lblFishPercentage
            // 
            this.lblFishPercentage.AutoSize = true;
            this.lblFishPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFishPercentage.Location = new System.Drawing.Point(351, 44);
            this.lblFishPercentage.Name = "lblFishPercentage";
            this.lblFishPercentage.Size = new System.Drawing.Size(96, 42);
            this.lblFishPercentage.TabIndex = 4;
            this.lblFishPercentage.Text = "97%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.lblUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 44);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpFrequent);
            this.groupBox2.Controls.Add(this.grpUrl);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 368);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // grpFrequent
            // 
            this.grpFrequent.Controls.Add(this.label2);
            this.grpFrequent.Controls.Add(this.lblFreqPercentage);
            this.grpFrequent.Controls.Add(this.txtFreqM);
            this.grpFrequent.Controls.Add(this.grdFreq);
            this.grpFrequent.Location = new System.Drawing.Point(493, 27);
            this.grpFrequent.Name = "grpFrequent";
            this.grpFrequent.Size = new System.Drawing.Size(354, 334);
            this.grpFrequent.TabIndex = 8;
            this.grpFrequent.TabStop = false;
            this.grpFrequent.Text = "Frequent Items";
            this.grpFrequent.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Analysis Probability:";
            // 
            // lblFreqPercentage
            // 
            this.lblFreqPercentage.AutoSize = true;
            this.lblFreqPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqPercentage.Location = new System.Drawing.Point(237, 44);
            this.lblFreqPercentage.Name = "lblFreqPercentage";
            this.lblFreqPercentage.Size = new System.Drawing.Size(96, 42);
            this.lblFreqPercentage.TabIndex = 9;
            this.lblFreqPercentage.Text = "97%";
            // 
            // txtFreqM
            // 
            this.txtFreqM.Location = new System.Drawing.Point(6, 21);
            this.txtFreqM.Multiline = true;
            this.txtFreqM.Name = "txtFreqM";
            this.txtFreqM.Size = new System.Drawing.Size(217, 68);
            this.txtFreqM.TabIndex = 7;
            this.txtFreqM.Text = "www.google.com is possibly a phishing site";
            // 
            // grdFreq
            // 
            this.grdFreq.AllowUserToAddRows = false;
            this.grdFreq.AllowUserToDeleteRows = false;
            this.grdFreq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFreq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Frequency});
            this.grdFreq.Location = new System.Drawing.Point(6, 114);
            this.grdFreq.Name = "grdFreq";
            this.grdFreq.RowHeadersVisible = false;
            this.grdFreq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdFreq.Size = new System.Drawing.Size(217, 204);
            this.grdFreq.TabIndex = 0;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.Name = "Frequency";
            // 
            // grpUrl
            // 
            this.grpUrl.Controls.Add(this.label1);
            this.grpUrl.Controls.Add(this.grdUrlAnalysis);
            this.grpUrl.Controls.Add(this.lblPhishingInd);
            this.grpUrl.Controls.Add(this.lblFishPercentage);
            this.grpUrl.Location = new System.Drawing.Point(13, 27);
            this.grpUrl.Name = "grpUrl";
            this.grpUrl.Size = new System.Drawing.Size(468, 334);
            this.grpUrl.TabIndex = 6;
            this.grpUrl.TabStop = false;
            this.grpUrl.Text = "URL Analysis";
            this.grpUrl.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Analysis Probability:";
            // 
            // grdUrlAnalysis
            // 
            this.grdUrlAnalysis.AllowUserToAddRows = false;
            this.grdUrlAnalysis.AllowUserToDeleteRows = false;
            this.grdUrlAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUrlAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.SystemParameter,
            this.Analysis});
            this.grdUrlAnalysis.Location = new System.Drawing.Point(9, 114);
            this.grdUrlAnalysis.Name = "grdUrlAnalysis";
            this.grdUrlAnalysis.ReadOnly = true;
            this.grdUrlAnalysis.RowHeadersVisible = false;
            this.grdUrlAnalysis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUrlAnalysis.Size = new System.Drawing.Size(453, 204);
            this.grdUrlAnalysis.TabIndex = 7;
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
            this.SystemParameter.HeaderText = "System Average";
            this.SystemParameter.Name = "SystemParameter";
            this.SystemParameter.ReadOnly = true;
            // 
            // Analysis
            // 
            this.Analysis.HeaderText = "URL Analysis";
            this.Analysis.Name = "Analysis";
            this.Analysis.ReadOnly = true;
            // 
            // lblPhishingInd
            // 
            this.lblPhishingInd.Location = new System.Drawing.Point(9, 21);
            this.lblPhishingInd.Multiline = true;
            this.lblPhishingInd.Name = "lblPhishingInd";
            this.lblPhishingInd.Size = new System.Drawing.Size(306, 68);
            this.lblPhishingInd.TabIndex = 6;
            this.lblPhishingInd.Text = "www.google.com is possibly a phishing site";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.Location = new System.Drawing.Point(22, 512);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(54, 16);
            this.lblSystemStatus.TabIndex = 8;
            this.lblSystemStatus.Text = "Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.ignoreRulesToolStripMenuItem,
            this.frequentItemsToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.statsToolStripMenuItem,
            this.tasksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // ignoreRulesToolStripMenuItem
            // 
            this.ignoreRulesToolStripMenuItem.Name = "ignoreRulesToolStripMenuItem";
            this.ignoreRulesToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ignoreRulesToolStripMenuItem.Text = "Ignore Rules";
            this.ignoreRulesToolStripMenuItem.Click += new System.EventHandler(this.ignoreRulesToolStripMenuItem_Click);
            // 
            // frequentItemsToolStripMenuItem
            // 
            this.frequentItemsToolStripMenuItem.Name = "frequentItemsToolStripMenuItem";
            this.frequentItemsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.frequentItemsToolStripMenuItem.Text = "Frequent Items";
            this.frequentItemsToolStripMenuItem.Click += new System.EventHandler(this.frequentItemsToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.statsToolStripMenuItem.Text = "Stats";
            this.statsToolStripMenuItem.Click += new System.EventHandler(this.statsToolStripMenuItem_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frequentItemCalculatorToolStripMenuItem,
            this.uRLAnalysisCalculatorToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // frequentItemCalculatorToolStripMenuItem
            // 
            this.frequentItemCalculatorToolStripMenuItem.Name = "frequentItemCalculatorToolStripMenuItem";
            this.frequentItemCalculatorToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.frequentItemCalculatorToolStripMenuItem.Text = "Frequent Item Calculator";
            this.frequentItemCalculatorToolStripMenuItem.Click += new System.EventHandler(this.frequentItemCalculatorToolStripMenuItem_Click);
            // 
            // uRLAnalysisCalculatorToolStripMenuItem
            // 
            this.uRLAnalysisCalculatorToolStripMenuItem.Name = "uRLAnalysisCalculatorToolStripMenuItem";
            this.uRLAnalysisCalculatorToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.uRLAnalysisCalculatorToolStripMenuItem.Text = "URL Analysis Calculator";
            this.uRLAnalysisCalculatorToolStripMenuItem.Click += new System.EventHandler(this.uRLAnalysisCalculatorToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 537);
            this.Controls.Add(this.lblSystemStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Phishbait";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpFrequent.ResumeLayout(false);
            this.grpFrequent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreq)).EndInit();
            this.grpUrl.ResumeLayout(false);
            this.grpUrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUrlAnalysis)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblFishPercentage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpUrl;
        private System.Windows.Forms.TextBox lblPhishingInd;
        private System.Windows.Forms.DataGridView grdUrlAnalysis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Analysis;
        private System.Windows.Forms.GroupBox grpFrequent;
        private System.Windows.Forms.DataGridView grdFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFreqPercentage;
        private System.Windows.Forms.TextBox txtFreqM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequentItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequentItemCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLAnalysisCalculatorToolStripMenuItem;
    }
}

