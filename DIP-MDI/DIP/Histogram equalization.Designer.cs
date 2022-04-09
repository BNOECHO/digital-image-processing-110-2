
namespace DIP
{
        partial class Histogram_equalization
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
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.groupBox1 = new System.Windows.Forms.GroupBox();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.pictureBox3 = new System.Windows.Forms.PictureBox();
                        this.pictureBox4 = new System.Windows.Forms.PictureBox();
                        this.button1 = new System.Windows.Forms.Button();
                        this.button2 = new System.Windows.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.groupBox1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        this.groupBox2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Location = new System.Drawing.Point(6, 28);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(255, 255);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox1.TabIndex = 0;
                        this.pictureBox1.TabStop = false;
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.pictureBox2);
                        this.groupBox1.Controls.Add(this.pictureBox1);
                        this.groupBox1.Location = new System.Drawing.Point(12, 12);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(271, 553);
                        this.groupBox1.TabIndex = 2;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "轉換前";
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Location = new System.Drawing.Point(6, 289);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(255, 255);
                        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox2.TabIndex = 1;
                        this.pictureBox2.TabStop = false;
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.pictureBox3);
                        this.groupBox2.Controls.Add(this.pictureBox4);
                        this.groupBox2.Location = new System.Drawing.Point(289, 12);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(271, 553);
                        this.groupBox2.TabIndex = 3;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "轉換後";
                        // 
                        // pictureBox3
                        // 
                        this.pictureBox3.Location = new System.Drawing.Point(6, 289);
                        this.pictureBox3.Name = "pictureBox3";
                        this.pictureBox3.Size = new System.Drawing.Size(255, 255);
                        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox3.TabIndex = 1;
                        this.pictureBox3.TabStop = false;
                        // 
                        // pictureBox4
                        // 
                        this.pictureBox4.Location = new System.Drawing.Point(6, 28);
                        this.pictureBox4.Name = "pictureBox4";
                        this.pictureBox4.Size = new System.Drawing.Size(255, 255);
                        this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox4.TabIndex = 0;
                        this.pictureBox4.TabStop = false;
                        // 
                        // button1
                        // 
                        this.button1.Location = new System.Drawing.Point(12, 571);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(271, 37);
                        this.button1.TabIndex = 4;
                        this.button1.Text = "生成";
                        this.button1.UseVisualStyleBackColor = true;
                        this.button1.Click += new System.EventHandler(this.button1_Click);
                        // 
                        // button2
                        // 
                        this.button2.Location = new System.Drawing.Point(289, 571);
                        this.button2.Name = "button2";
                        this.button2.Size = new System.Drawing.Size(271, 37);
                        this.button2.TabIndex = 5;
                        this.button2.Text = "取消";
                        this.button2.UseVisualStyleBackColor = true;
                        this.button2.Click += new System.EventHandler(this.button2_Click);
                        // 
                        // Histogram_equalization
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(570, 643);
                        this.Controls.Add(this.button2);
                        this.Controls.Add(this.button1);
                        this.Controls.Add(this.groupBox2);
                        this.Controls.Add(this.groupBox1);
                        this.Name = "Histogram_equalization";
                        this.Text = "Histogram_equalization";
                        this.Load += new System.EventHandler(this.Histogram_equalization_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.groupBox1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        this.groupBox2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.PictureBox pictureBox1;
                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.PictureBox pictureBox2;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.PictureBox pictureBox3;
                private System.Windows.Forms.PictureBox pictureBox4;
                internal System.Windows.Forms.Button button1;
                private System.Windows.Forms.Button button2;
        }
}