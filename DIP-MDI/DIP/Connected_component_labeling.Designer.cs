
namespace DIP
{
        partial class Connected_component_labeling
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
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.button1 = new System.Windows.Forms.Button();
                        this.label1 = new System.Windows.Forms.Label();
                        this.groupBox1.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.groupBox2.SuspendLayout();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.panel1);
                        this.groupBox1.Location = new System.Drawing.Point(12, 12);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(600, 600);
                        this.groupBox1.TabIndex = 0;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "輸入圖片";
                        // 
                        // panel1
                        // 
                        this.panel1.AutoScroll = true;
                        this.panel1.Controls.Add(this.pictureBox1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(3, 25);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(594, 572);
                        this.panel1.TabIndex = 0;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Location = new System.Drawing.Point(3, 3);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(466, 460);
                        this.pictureBox1.TabIndex = 0;
                        this.pictureBox1.TabStop = false;
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.panel2);
                        this.groupBox2.Location = new System.Drawing.Point(618, 12);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(600, 600);
                        this.groupBox2.TabIndex = 1;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "輸出圖片";
                        // 
                        // panel2
                        // 
                        this.panel2.AutoScroll = true;
                        this.panel2.Controls.Add(this.pictureBox2);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel2.Location = new System.Drawing.Point(3, 25);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(594, 572);
                        this.panel2.TabIndex = 0;
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Location = new System.Drawing.Point(3, 3);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(466, 460);
                        this.pictureBox2.TabIndex = 0;
                        this.pictureBox2.TabStop = false;
                        // 
                        // button1
                        // 
                        this.button1.Location = new System.Drawing.Point(547, 618);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(147, 34);
                        this.button1.TabIndex = 2;
                        this.button1.Text = "生成";
                        this.button1.UseVisualStyleBackColor = true;
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Font = new System.Drawing.Font("新細明體", 9F);
                        this.label1.Location = new System.Drawing.Point(14, 628);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(103, 18);
                        this.label1.TabIndex = 3;
                        this.label1.Text = "總物件個數:";
                        // 
                        // Connected_component_labeling
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1233, 669);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.button1);
                        this.Controls.Add(this.groupBox2);
                        this.Controls.Add(this.groupBox1);
                        this.Name = "Connected_component_labeling";
                        this.Text = "Connected_component_labeling";
                        this.Load += new System.EventHandler(this.Connected_component_labeling_Load);
                        this.groupBox1.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.groupBox2.ResumeLayout(false);
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.PictureBox pictureBox1;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.Panel panel2;
                internal System.Windows.Forms.Button button1;
                internal System.Windows.Forms.PictureBox pictureBox2;
                private System.Windows.Forms.Label label1;
        }
}