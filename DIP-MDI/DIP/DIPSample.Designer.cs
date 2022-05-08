namespace DIP
{
    partial class DIPSample
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DIPSample));
                        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                        this.stStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
                        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.rGBtoGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.horizontalFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.verticalFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.degreeFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.degreeFlipToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
                        this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.linearBrightnessTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.histogramEqualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
                        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                        this.statusStrip1.SuspendLayout();
                        this.menuStrip1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // statusStrip1
                        // 
                        this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
                        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStripLabel});
                        this.statusStrip1.Location = new System.Drawing.Point(0, 748);
                        this.statusStrip1.Name = "statusStrip1";
                        this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
                        this.statusStrip1.Size = new System.Drawing.Size(1287, 30);
                        this.statusStrip1.TabIndex = 0;
                        this.statusStrip1.Text = "statusStrip1";
                        // 
                        // stStripLabel
                        // 
                        this.stStripLabel.Name = "stStripLabel";
                        this.stStripLabel.Size = new System.Drawing.Size(192, 23);
                        this.stStripLabel.Text = "toolStripStatusLabel1";
                        // 
                        // menuStrip1
                        // 
                        this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
                        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.iPToolStripMenuItem,
            this.modifyToolStripMenuItem});
                        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                        this.menuStrip1.Name = "menuStrip1";
                        this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
                        this.menuStrip1.Size = new System.Drawing.Size(1287, 33);
                        this.menuStrip1.TabIndex = 1;
                        this.menuStrip1.Text = "menuStrip1";
                        // 
                        // fileToolStripMenuItem
                        // 
                        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
                        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
                        this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 27);
                        this.fileToolStripMenuItem.Text = "&File";
                        this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
                        // 
                        // openToolStripMenuItem
                        // 
                        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
                        this.openToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
                        this.openToolStripMenuItem.Text = "&Open";
                        this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
                        // 
                        // saveToolStripMenuItem
                        // 
                        this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
                        this.saveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
                        this.saveToolStripMenuItem.Text = "Save";
                        this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
                        // 
                        // iPToolStripMenuItem
                        // 
                        this.iPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBtoGrayToolStripMenuItem,
            this.horizontalFlipToolStripMenuItem,
            this.verticalFlipToolStripMenuItem,
            this.degreeFlipToolStripMenuItem,
            this.degreeFlipToolStripMenuItem1});
                        this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
                        this.iPToolStripMenuItem.Size = new System.Drawing.Size(42, 27);
                        this.iPToolStripMenuItem.Text = "&IP";
                        // 
                        // rGBtoGrayToolStripMenuItem
                        // 
                        this.rGBtoGrayToolStripMenuItem.Name = "rGBtoGrayToolStripMenuItem";
                        this.rGBtoGrayToolStripMenuItem.Size = new System.Drawing.Size(231, 34);
                        this.rGBtoGrayToolStripMenuItem.Text = "RGBtoGray";
                        this.rGBtoGrayToolStripMenuItem.Click += new System.EventHandler(this.rGBtoGrayToolStripMenuItem_Click);
                        // 
                        // horizontalFlipToolStripMenuItem
                        // 
                        this.horizontalFlipToolStripMenuItem.Name = "horizontalFlipToolStripMenuItem";
                        this.horizontalFlipToolStripMenuItem.Size = new System.Drawing.Size(231, 34);
                        this.horizontalFlipToolStripMenuItem.Text = "horizontal flip";
                        this.horizontalFlipToolStripMenuItem.Click += new System.EventHandler(this.horizontalFlipToolStripMenuItem_Click);
                        // 
                        // verticalFlipToolStripMenuItem
                        // 
                        this.verticalFlipToolStripMenuItem.Name = "verticalFlipToolStripMenuItem";
                        this.verticalFlipToolStripMenuItem.Size = new System.Drawing.Size(231, 34);
                        this.verticalFlipToolStripMenuItem.Text = "vertical flip";
                        this.verticalFlipToolStripMenuItem.Click += new System.EventHandler(this.verticalFlipToolStripMenuItem_Click);
                        // 
                        // degreeFlipToolStripMenuItem
                        // 
                        this.degreeFlipToolStripMenuItem.Name = "degreeFlipToolStripMenuItem";
                        this.degreeFlipToolStripMenuItem.Size = new System.Drawing.Size(231, 34);
                        this.degreeFlipToolStripMenuItem.Text = "90degree flip";
                        this.degreeFlipToolStripMenuItem.Click += new System.EventHandler(this._90degreeFlipToolStripMenuItem_Click);
                        // 
                        // degreeFlipToolStripMenuItem1
                        // 
                        this.degreeFlipToolStripMenuItem1.Name = "degreeFlipToolStripMenuItem1";
                        this.degreeFlipToolStripMenuItem1.Size = new System.Drawing.Size(231, 34);
                        this.degreeFlipToolStripMenuItem1.Text = "270degree flip";
                        this.degreeFlipToolStripMenuItem1.Click += new System.EventHandler(this._270degreeFlipToolStripMenuItem1_Click);
                        // 
                        // modifyToolStripMenuItem
                        // 
                        this.modifyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearBrightnessTransferToolStripMenuItem,
            this.histogramEqualizationToolStripMenuItem});
                        this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
                        this.modifyToolStripMenuItem.Size = new System.Drawing.Size(85, 27);
                        this.modifyToolStripMenuItem.Text = "modify";
                        // 
                        // linearBrightnessTransferToolStripMenuItem
                        // 
                        this.linearBrightnessTransferToolStripMenuItem.Name = "linearBrightnessTransferToolStripMenuItem";
                        this.linearBrightnessTransferToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
                        this.linearBrightnessTransferToolStripMenuItem.Text = "linear brightness transfer";
                        this.linearBrightnessTransferToolStripMenuItem.Click += new System.EventHandler(this.linearBrightnessTransferToolStripMenuItem_Click);
                        // 
                        // histogramEqualizationToolStripMenuItem
                        // 
                        this.histogramEqualizationToolStripMenuItem.Name = "histogramEqualizationToolStripMenuItem";
                        this.histogramEqualizationToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
                        this.histogramEqualizationToolStripMenuItem.Text = "Histogram equalization";
                        this.histogramEqualizationToolStripMenuItem.Click += new System.EventHandler(this.histogramEqualizationToolStripMenuItem_Click);
                        // 
                        // oFileDlg
                        // 
                        this.oFileDlg.FileName = "openFileDialog1";
                        // 
                        // DIPSample
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1287, 778);
                        this.Controls.Add(this.statusStrip1);
                        this.Controls.Add(this.menuStrip1);
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.MainMenuStrip = this.menuStrip1;
                        this.Margin = new System.Windows.Forms.Padding(4);
                        this.Name = "DIPSample";
                        this.Text = "一個機器人 一台不能用的狐狸電腦 和一隻哈士吉";
                        this.Load += new System.EventHandler(this.DIPSample_Load);
                        this.statusStrip1.ResumeLayout(false);
                        this.statusStrip1.PerformLayout();
                        this.menuStrip1.ResumeLayout(false);
                        this.menuStrip1.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stStripLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem rGBtoGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalFlipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalFlipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem degreeFlipToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem degreeFlipToolStripMenuItem1;
                private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem linearBrightnessTransferToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem histogramEqualizationToolStripMenuItem;
        }
}