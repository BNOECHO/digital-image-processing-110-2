﻿namespace DIP
{
    partial class MSForm
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSForm));
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
                        this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(458, 434);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pictureBox1.TabIndex = 0;
                        this.pictureBox1.TabStop = false;
                        this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
                        // 
                        // MSForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(458, 434);
                        this.Controls.Add(this.pictureBox1);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Margin = new System.Windows.Forms.Padding(4);
                        this.MaximizeBox = false;
                        this.Name = "MSForm";
                        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
                        this.Text = "MSForm";
                        this.Load += new System.EventHandler(this.MSForm_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}