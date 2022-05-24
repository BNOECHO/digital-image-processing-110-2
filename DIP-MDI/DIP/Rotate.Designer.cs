
namespace DIP
{
        partial class Rotate
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
                        this.inputPictureBox = new System.Windows.Forms.PictureBox();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.panel2 = new System.Windows.Forms.Panel();
                        this.outputPictureBox = new System.Windows.Forms.PictureBox();
                        this.label1 = new System.Windows.Forms.Label();
                        this.textBox1 = new System.Windows.Forms.TextBox();
                        this.button1 = new System.Windows.Forms.Button();
                        this.groupBox1.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).BeginInit();
                        this.groupBox2.SuspendLayout();
                        this.panel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Controls.Add(this.panel1);
                        this.groupBox1.Location = new System.Drawing.Point(12, 12);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(500, 500);
                        this.groupBox1.TabIndex = 0;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "輸入";
                        // 
                        // panel1
                        // 
                        this.panel1.AutoScroll = true;
                        this.panel1.Controls.Add(this.inputPictureBox);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel1.Location = new System.Drawing.Point(3, 25);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(494, 472);
                        this.panel1.TabIndex = 0;
                        // 
                        // inputPictureBox
                        // 
                        this.inputPictureBox.Location = new System.Drawing.Point(3, 3);
                        this.inputPictureBox.Name = "inputPictureBox";
                        this.inputPictureBox.Size = new System.Drawing.Size(297, 353);
                        this.inputPictureBox.TabIndex = 0;
                        this.inputPictureBox.TabStop = false;
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Controls.Add(this.panel2);
                        this.groupBox2.Location = new System.Drawing.Point(518, 12);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(500, 500);
                        this.groupBox2.TabIndex = 1;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "輸出";
                        // 
                        // panel2
                        // 
                        this.panel2.AutoScroll = true;
                        this.panel2.Controls.Add(this.outputPictureBox);
                        this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.panel2.Location = new System.Drawing.Point(3, 25);
                        this.panel2.Name = "panel2";
                        this.panel2.Size = new System.Drawing.Size(494, 472);
                        this.panel2.TabIndex = 0;
                        // 
                        // outputPictureBox
                        // 
                        this.outputPictureBox.Location = new System.Drawing.Point(3, 3);
                        this.outputPictureBox.Name = "outputPictureBox";
                        this.outputPictureBox.Size = new System.Drawing.Size(297, 353);
                        this.outputPictureBox.TabIndex = 0;
                        this.outputPictureBox.TabStop = false;
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(287, 529);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(85, 18);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "旋轉角度:";
                        this.label1.Click += new System.EventHandler(this.label1_Click);
                        // 
                        // textBox1
                        // 
                        this.textBox1.Location = new System.Drawing.Point(378, 524);
                        this.textBox1.Name = "textBox1";
                        this.textBox1.Size = new System.Drawing.Size(134, 29);
                        this.textBox1.TabIndex = 3;
                        this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                        // 
                        // button1
                        // 
                        this.button1.Location = new System.Drawing.Point(521, 523);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(111, 30);
                        this.button1.TabIndex = 4;
                        this.button1.Text = "生成";
                        this.button1.UseVisualStyleBackColor = true;
                        // 
                        // Rotate
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(1022, 565);
                        this.Controls.Add(this.button1);
                        this.Controls.Add(this.textBox1);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.groupBox2);
                        this.Controls.Add(this.groupBox1);
                        this.Name = "Rotate";
                        this.Text = "Rotate";
                        this.Load += new System.EventHandler(this.Rotate_Load);
                        this.groupBox1.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).EndInit();
                        this.groupBox2.ResumeLayout(false);
                        this.panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.Panel panel1;
                private System.Windows.Forms.PictureBox inputPictureBox;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.Panel panel2;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.TextBox textBox1;
                internal System.Windows.Forms.Button button1;
                internal System.Windows.Forms.PictureBox outputPictureBox;
        }
}