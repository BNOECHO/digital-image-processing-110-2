
namespace DIP
{
        partial class linear_brightness_transfer
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
                        this.button1 = new System.Windows.Forms.Button();
                        this.button2 = new System.Windows.Forms.Button();
                        this.linear_function_graphic = new System.Windows.Forms.PictureBox();
                        this.label1 = new System.Windows.Forms.Label();
                        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
                        this.numUD_P1X = new System.Windows.Forms.NumericUpDown();
                        this.label2 = new System.Windows.Forms.Label();
                        this.numUD_P1Y = new System.Windows.Forms.NumericUpDown();
                        this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
                        this.label3 = new System.Windows.Forms.Label();
                        this.numUD_P2X = new System.Windows.Forms.NumericUpDown();
                        this.label4 = new System.Windows.Forms.Label();
                        this.numUD_P2Y = new System.Windows.Forms.NumericUpDown();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.linear_function_graphic)).BeginInit();
                        this.flowLayoutPanel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P1X)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P1Y)).BeginInit();
                        this.flowLayoutPanel2.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P2X)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P2Y)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Location = new System.Drawing.Point(12, 12);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(289, 289);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.pictureBox1.TabIndex = 0;
                        this.pictureBox1.TabStop = false;
                        // 
                        // button1
                        // 
                        this.button1.Location = new System.Drawing.Point(12, 306);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(145, 38);
                        this.button1.TabIndex = 1;
                        this.button1.Text = "生成";
                        this.button1.UseVisualStyleBackColor = true;
                        this.button1.Click += new System.EventHandler(this.button1_Click);
                        // 
                        // button2
                        // 
                        this.button2.Location = new System.Drawing.Point(163, 307);
                        this.button2.Name = "button2";
                        this.button2.Size = new System.Drawing.Size(138, 38);
                        this.button2.TabIndex = 2;
                        this.button2.Text = "取消";
                        this.button2.UseVisualStyleBackColor = true;
                        this.button2.Click += new System.EventHandler(this.button2_Click);
                        // 
                        // linear_function_graphic
                        // 
                        this.linear_function_graphic.Location = new System.Drawing.Point(307, 12);
                        this.linear_function_graphic.Margin = new System.Windows.Forms.Padding(0);
                        this.linear_function_graphic.Name = "linear_function_graphic";
                        this.linear_function_graphic.Size = new System.Drawing.Size(251, 251);
                        this.linear_function_graphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        this.linear_function_graphic.TabIndex = 3;
                        this.linear_function_graphic.TabStop = false;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(3, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(59, 32);
                        this.label1.TabIndex = 4;
                        this.label1.Text = "P1 X:";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // flowLayoutPanel1
                        // 
                        this.flowLayoutPanel1.Controls.Add(this.label1);
                        this.flowLayoutPanel1.Controls.Add(this.numUD_P1X);
                        this.flowLayoutPanel1.Controls.Add(this.label2);
                        this.flowLayoutPanel1.Controls.Add(this.numUD_P1Y);
                        this.flowLayoutPanel1.Location = new System.Drawing.Point(307, 269);
                        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
                        this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 37);
                        this.flowLayoutPanel1.TabIndex = 5;
                        // 
                        // numUD_P1X
                        // 
                        this.numUD_P1X.Location = new System.Drawing.Point(68, 3);
                        this.numUD_P1X.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P1X.Name = "numUD_P1X";
                        this.numUD_P1X.Size = new System.Drawing.Size(61, 29);
                        this.numUD_P1X.TabIndex = 5;
                        this.numUD_P1X.ValueChanged += new System.EventHandler(this.numUD_P1X_ValueChanged);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(135, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(34, 32);
                        this.label2.TabIndex = 6;
                        this.label2.Text = "Y:";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // numUD_P1Y
                        // 
                        this.numUD_P1Y.Location = new System.Drawing.Point(175, 3);
                        this.numUD_P1Y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P1Y.Name = "numUD_P1Y";
                        this.numUD_P1Y.Size = new System.Drawing.Size(61, 29);
                        this.numUD_P1Y.TabIndex = 7;
                        this.numUD_P1Y.ValueChanged += new System.EventHandler(this.numUD_P1Y_ValueChanged);
                        // 
                        // flowLayoutPanel2
                        // 
                        this.flowLayoutPanel2.Controls.Add(this.label3);
                        this.flowLayoutPanel2.Controls.Add(this.numUD_P2X);
                        this.flowLayoutPanel2.Controls.Add(this.label4);
                        this.flowLayoutPanel2.Controls.Add(this.numUD_P2Y);
                        this.flowLayoutPanel2.Location = new System.Drawing.Point(307, 312);
                        this.flowLayoutPanel2.Name = "flowLayoutPanel2";
                        this.flowLayoutPanel2.Size = new System.Drawing.Size(251, 37);
                        this.flowLayoutPanel2.TabIndex = 8;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(3, 0);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(59, 32);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "P2 X:";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // numUD_P2X
                        // 
                        this.numUD_P2X.Location = new System.Drawing.Point(68, 3);
                        this.numUD_P2X.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P2X.Name = "numUD_P2X";
                        this.numUD_P2X.Size = new System.Drawing.Size(61, 29);
                        this.numUD_P2X.TabIndex = 5;
                        this.numUD_P2X.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P2X.ValueChanged += new System.EventHandler(this.numUD_P2X_ValueChanged);
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(135, 0);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(34, 32);
                        this.label4.TabIndex = 6;
                        this.label4.Text = "Y:";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // numUD_P2Y
                        // 
                        this.numUD_P2Y.Location = new System.Drawing.Point(175, 3);
                        this.numUD_P2Y.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P2Y.Name = "numUD_P2Y";
                        this.numUD_P2Y.Size = new System.Drawing.Size(61, 29);
                        this.numUD_P2Y.TabIndex = 7;
                        this.numUD_P2Y.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
                        this.numUD_P2Y.ValueChanged += new System.EventHandler(this.numUD_P2Y_ValueChanged);
                        // 
                        // linear_brightness_transfer
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(567, 356);
                        this.Controls.Add(this.flowLayoutPanel1);
                        this.Controls.Add(this.linear_function_graphic);
                        this.Controls.Add(this.button2);
                        this.Controls.Add(this.button1);
                        this.Controls.Add(this.flowLayoutPanel2);
                        this.Controls.Add(this.pictureBox1);
                        this.Name = "linear_brightness_transfer";
                        this.Text = "線性亮度轉換";
                        this.Load += new System.EventHandler(this.linear_brightness_transfer_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.linear_function_graphic)).EndInit();
                        this.flowLayoutPanel1.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P1X)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P1Y)).EndInit();
                        this.flowLayoutPanel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P2X)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.numUD_P2Y)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.PictureBox pictureBox1;
                internal System.Windows.Forms.Button button1;
                private System.Windows.Forms.Button button2;
                private System.Windows.Forms.PictureBox linear_function_graphic;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
                private System.Windows.Forms.NumericUpDown numUD_P1X;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.NumericUpDown numUD_P1Y;
                private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.NumericUpDown numUD_P2X;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.NumericUpDown numUD_P2Y;
        }
}