using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using static DIP.BmpTranser;

namespace DIP
{
        public partial class Rotate : Form
        {
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void rotate_process(int* f, int w_in, int h_in, ref int w_out, ref int h_out, int* g, int D, int degree);
                public Rotate(Bitmap bitmap)
                {
                        input_bitmap=bitmap;
                        InitializeComponent();
                }
                private void ChangeImage(PictureBox pictureBox, Bitmap bitmap)
                {
                        pictureBox.Image = bitmap;
                        pictureBox.Width = bitmap.Width;
                        pictureBox.Height = bitmap.Height;
                }
                Bitmap input_bitmap = null;
                private void textBox1_TextChanged(object sender, EventArgs e)
                {
                        double degree = 0;
                        if (Double.TryParse(textBox1.Text, out degree))
                        {
                                int[] f;
                                int[] g;
                                int PB_Width = 0;
                                int PB_Height = 0;
                                int ByteDepth = 0;
                                PixelFormat pixelFormat = new PixelFormat();
                                ColorPalette palette = null;
                                f = dyn_bmp2array((Bitmap)inputPictureBox.Image, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                int scaled_Width = (int)(PB_Width * 1.5);//(略大於理論最大值 使用ref傳入參考取得實際大小)
                                int scaled_Height = (int)(PB_Height * 1.5);
                                g = new int[scaled_Width * scaled_Height * ByteDepth];
                                unsafe
                                {
                                        fixed (int* f0 = f) fixed (int* g0 = g)
                                        {
                                                rotate_process(f0, PB_Width, PB_Height,ref scaled_Width, ref scaled_Height, g0, ByteDepth, (int)degree);
                                        }
                                }
                               Bitmap preview_bitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, scaled_Height, scaled_Width);
                                ChangeImage(outputPictureBox, preview_bitmap);
                        }
                }

                private void Rotate_Load(object sender, EventArgs e)
                {
                        ChangeImage(inputPictureBox, input_bitmap);
                        ChangeImage(outputPictureBox, input_bitmap);
                }




                private void label1_Click(object sender, EventArgs e)
                {

                }
        }
}
