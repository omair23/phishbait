namespace Phishbait
{
    partial class frmImport
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
            this.radNeutral = new System.Windows.Forms.RadioButton();
            this.radTrusted = new System.Windows.Forms.RadioButton();
            this.radPhishing = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.btnFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTextFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgText = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNeutral);
            this.groupBox1.Controls.Add(this.radTrusted);
            this.groupBox1.Controls.Add(this.radPhishing);
            this.groupBox1.Location = new System.Drawing.Point(21, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Classification";
            // 
            // radNeutral
            // 
            this.radNeutral.AutoSize = true;
            this.radNeutral.Checked = true;
            this.radNeutral.Location = new System.Drawing.Point(7, 68);
            this.radNeutral.Name = "radNeutral";
            this.radNeutral.Size = new System.Drawing.Size(59, 17);
            this.radNeutral.TabIndex = 2;
            this.radNeutral.TabStop = true;
            this.radNeutral.Text = "Neutral";
            this.radNeutral.UseVisualStyleBackColor = true;
            // 
            // radTrusted
            // 
            this.radTrusted.AutoSize = true;
            this.radTrusted.Location = new System.Drawing.Point(7, 44);
            this.radTrusted.Name = "radTrusted";
            this.radTrusted.Size = new System.Drawing.Size(87, 17);
            this.radTrusted.TabIndex = 1;
            this.radTrusted.TabStop = true;
            this.radTrusted.Text = "Trusted Sites";
            this.radTrusted.UseVisualStyleBackColor = true;
            // 
            // radPhishing
            // 
            this.radPhishing.AutoSize = true;
            this.radPhishing.Location = new System.Drawing.Point(7, 20);
            this.radPhishing.Name = "radPhishing";
            this.radPhishing.Size = new System.Drawing.Size(91, 17);
            this.radPhishing.TabIndex = 0;
            this.radPhishing.TabStop = true;
            this.radPhishing.Text = "Phishing Sites";
            this.radPhishing.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(46, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(325, 133);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 26);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 59);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(79, 13);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "No File Chosen";
            // 
            // dlgFile
            // 
            this.dlgFile.Filter = "Excel Files|*.xlsx";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(11, 21);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "File..";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFile);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Location = new System.Drawing.Point(242, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Excel Files";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTextFile);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(353, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text Files";
            // 
            // btnTextFile
            // 
            this.btnTextFile.Location = new System.Drawing.Point(11, 21);
            this.btnTextFile.Name = "btnTextFile";
            this.btnTextFile.Size = new System.Drawing.Size(75, 23);
            this.btnTextFile.TabIndex = 4;
            this.btnTextFile.Text = "File..";
            this.btnTextFile.UseVisualStyleBackColor = true;
            this.btnTextFile.Click += new System.EventHandler(this.btnTextFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "No File Chosen";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 171);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImport";
            this.Text = "Import Excel File";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNeutral;
        private System.Windows.Forms.RadioButton radTrusted;
        private System.Windows.Forms.RadioButton radPhishing;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTextFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgText;
    }
}