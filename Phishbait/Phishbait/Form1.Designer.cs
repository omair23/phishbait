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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crawlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLCharsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.Layer5 = new System.Windows.Forms.GroupBox();
            this.Layer4 = new System.Windows.Forms.GroupBox();
            this.txtLayer4 = new System.Windows.Forms.TextBox();
            this.Layer3 = new System.Windows.Forms.GroupBox();
            this.txtLayer3 = new System.Windows.Forms.TextBox();
            this.Layer2 = new System.Windows.Forms.GroupBox();
            this.txtLayer2 = new System.Windows.Forms.TextBox();
            this.Layer1 = new System.Windows.Forms.GroupBox();
            this.txtLayer1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.Layer4.SuspendLayout();
            this.Layer3.SuspendLayout();
            this.Layer2.SuspendLayout();
            this.Layer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(594, 11);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(147, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Process";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(171, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(417, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(10, 16);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(155, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "Please enter a URL to process:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.lblUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 42);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.Location = new System.Drawing.Point(22, 394);
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
            this.configurationToolStripMenuItem,
            this.resourcesToolStripMenuItem,
            this.simulateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crawlerToolStripMenuItem,
            this.uRLCharsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // crawlerToolStripMenuItem
            // 
            this.crawlerToolStripMenuItem.Name = "crawlerToolStripMenuItem";
            this.crawlerToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.crawlerToolStripMenuItem.Text = "Crawler";
            this.crawlerToolStripMenuItem.Click += new System.EventHandler(this.crawlerToolStripMenuItem_Click);
            // 
            // uRLCharsToolStripMenuItem
            // 
            this.uRLCharsToolStripMenuItem.Name = "uRLCharsToolStripMenuItem";
            this.uRLCharsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.uRLCharsToolStripMenuItem.Text = "URL Chars.";
            this.uRLCharsToolStripMenuItem.Click += new System.EventHandler(this.uRLCharsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
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
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.resourcesToolStripMenuItem.Text = "Resources";
            this.resourcesToolStripMenuItem.Click += new System.EventHandler(this.resourcesToolStripMenuItem_Click);
            // 
            // simulateToolStripMenuItem
            // 
            this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
            this.simulateToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.simulateToolStripMenuItem.Text = "Statistics";
            this.simulateToolStripMenuItem.Click += new System.EventHandler(this.simulateToolStripMenuItem_Click);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.Layer5);
            this.grpMain.Controls.Add(this.Layer4);
            this.grpMain.Controls.Add(this.Layer3);
            this.grpMain.Controls.Add(this.Layer2);
            this.grpMain.Controls.Add(this.Layer1);
            this.grpMain.Location = new System.Drawing.Point(12, 75);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(824, 316);
            this.grpMain.TabIndex = 11;
            this.grpMain.TabStop = false;
            this.grpMain.Visible = false;
            // 
            // Layer5
            // 
            this.Layer5.Location = new System.Drawing.Point(520, 24);
            this.Layer5.Name = "Layer5";
            this.Layer5.Size = new System.Drawing.Size(288, 135);
            this.Layer5.TabIndex = 4;
            this.Layer5.TabStop = false;
            this.Layer5.Text = "Layer 5 - Page-Based Features";
            // 
            // Layer4
            // 
            this.Layer4.Controls.Add(this.txtLayer4);
            this.Layer4.Location = new System.Drawing.Point(269, 174);
            this.Layer4.Name = "Layer4";
            this.Layer4.Size = new System.Drawing.Size(245, 136);
            this.Layer4.TabIndex = 3;
            this.Layer4.TabStop = false;
            this.Layer4.Text = "Layer 4 - Domain-Based Features";
            // 
            // txtLayer4
            // 
            this.txtLayer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayer4.ForeColor = System.Drawing.Color.White;
            this.txtLayer4.Location = new System.Drawing.Point(5, 21);
            this.txtLayer4.Multiline = true;
            this.txtLayer4.Name = "txtLayer4";
            this.txtLayer4.ReadOnly = true;
            this.txtLayer4.Size = new System.Drawing.Size(235, 106);
            this.txtLayer4.TabIndex = 2;
            this.txtLayer4.Text = "Layer 4 Text";
            // 
            // Layer3
            // 
            this.Layer3.Controls.Add(this.txtLayer3);
            this.Layer3.Location = new System.Drawing.Point(6, 174);
            this.Layer3.Name = "Layer3";
            this.Layer3.Size = new System.Drawing.Size(253, 136);
            this.Layer3.TabIndex = 2;
            this.Layer3.TabStop = false;
            this.Layer3.Text = "Layer 3 - URL-Based Features";
            // 
            // txtLayer3
            // 
            this.txtLayer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayer3.ForeColor = System.Drawing.Color.White;
            this.txtLayer3.Location = new System.Drawing.Point(7, 23);
            this.txtLayer3.Multiline = true;
            this.txtLayer3.Name = "txtLayer3";
            this.txtLayer3.ReadOnly = true;
            this.txtLayer3.Size = new System.Drawing.Size(235, 106);
            this.txtLayer3.TabIndex = 1;
            this.txtLayer3.Text = "Layer 3 Text";
            // 
            // Layer2
            // 
            this.Layer2.Controls.Add(this.txtLayer2);
            this.Layer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Layer2.Location = new System.Drawing.Point(269, 24);
            this.Layer2.Name = "Layer2";
            this.Layer2.Size = new System.Drawing.Size(245, 135);
            this.Layer2.TabIndex = 1;
            this.Layer2.TabStop = false;
            this.Layer2.Text = "Layer 2 - Blacklist";
            this.Layer2.Visible = false;
            // 
            // txtLayer2
            // 
            this.txtLayer2.Location = new System.Drawing.Point(6, 21);
            this.txtLayer2.Multiline = true;
            this.txtLayer2.Name = "txtLayer2";
            this.txtLayer2.ReadOnly = true;
            this.txtLayer2.Size = new System.Drawing.Size(229, 105);
            this.txtLayer2.TabIndex = 0;
            this.txtLayer2.Text = "Layer 2 Text";
            // 
            // Layer1
            // 
            this.Layer1.Controls.Add(this.txtLayer1);
            this.Layer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Layer1.Location = new System.Drawing.Point(6, 24);
            this.Layer1.Name = "Layer1";
            this.Layer1.Size = new System.Drawing.Size(253, 135);
            this.Layer1.TabIndex = 0;
            this.Layer1.TabStop = false;
            this.Layer1.Text = "Layer 1 - Whitelist";
            this.Layer1.Visible = false;
            // 
            // txtLayer1
            // 
            this.txtLayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLayer1.ForeColor = System.Drawing.Color.White;
            this.txtLayer1.Location = new System.Drawing.Point(7, 23);
            this.txtLayer1.Multiline = true;
            this.txtLayer1.Name = "txtLayer1";
            this.txtLayer1.ReadOnly = true;
            this.txtLayer1.Size = new System.Drawing.Size(235, 106);
            this.txtLayer1.TabIndex = 0;
            this.txtLayer1.Text = "Layer 1 Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 417);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.lblSystemStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Phishbait";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.Layer4.ResumeLayout(false);
            this.Layer4.PerformLayout();
            this.Layer3.ResumeLayout(false);
            this.Layer3.PerformLayout();
            this.Layer2.ResumeLayout(false);
            this.Layer2.PerformLayout();
            this.Layer1.ResumeLayout(false);
            this.Layer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crawlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLCharsToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox Layer1;
        private System.Windows.Forms.GroupBox Layer2;
        private System.Windows.Forms.TextBox txtLayer1;
        private System.Windows.Forms.TextBox txtLayer2;
        private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
        private System.Windows.Forms.GroupBox Layer3;
        private System.Windows.Forms.GroupBox Layer4;
        private System.Windows.Forms.GroupBox Layer5;
        private System.Windows.Forms.TextBox txtLayer3;
        private System.Windows.Forms.TextBox txtLayer4;
    }
}

