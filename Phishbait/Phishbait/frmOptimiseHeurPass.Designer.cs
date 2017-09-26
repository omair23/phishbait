namespace Phishbait
{
    partial class frmOptimiseHeurPass
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.btnCompute = new System.Windows.Forms.Button();
            this.chtMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.True_Positives = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.False_Positives = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.False_Negatives = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.True_Negatives = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Score,
            this.True_Positives,
            this.False_Positives,
            this.False_Negatives,
            this.True_Negatives});
            this.grdMain.Location = new System.Drawing.Point(12, 31);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowHeadersVisible = false;
            this.grdMain.Size = new System.Drawing.Size(505, 383);
            this.grdMain.TabIndex = 0;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(544, 31);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 1;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // chtMain
            // 
            chartArea1.Name = "ChartArea1";
            this.chtMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtMain.Legends.Add(legend1);
            this.chtMain.Location = new System.Drawing.Point(544, 76);
            this.chtMain.Name = "chtMain";
            this.chtMain.Size = new System.Drawing.Size(527, 338);
            this.chtMain.TabIndex = 2;
            this.chtMain.Text = "chart1";
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // True_Positives
            // 
            this.True_Positives.HeaderText = "True Positives %";
            this.True_Positives.Name = "True_Positives";
            // 
            // False_Positives
            // 
            this.False_Positives.HeaderText = "False Positives (Inverted) %";
            this.False_Positives.Name = "False_Positives";
            // 
            // False_Negatives
            // 
            this.False_Negatives.HeaderText = "False Negatives (Inverted) %";
            this.False_Negatives.Name = "False_Negatives";
            // 
            // True_Negatives
            // 
            this.True_Negatives.HeaderText = "True Negatives %";
            this.True_Negatives.Name = "True_Negatives";
            // 
            // frmOptimiseHeurPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 426);
            this.Controls.Add(this.chtMain);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.grdMain);
            this.Name = "frmOptimiseHeurPass";
            this.Text = "Optimise Heuristic Pass Score";
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn True_Positives;
        private System.Windows.Forms.DataGridViewTextBoxColumn False_Positives;
        private System.Windows.Forms.DataGridViewTextBoxColumn False_Negatives;
        private System.Windows.Forms.DataGridViewTextBoxColumn True_Negatives;
    }
}