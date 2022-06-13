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
        public partial class Canny : Form
        {
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void canny_process(int* f, int w_in, int h_in, int* g);
                public Canny(Bitmap bitmap)
                {
                        inputBitmap = bitmap;
                        InitializeComponent();
                }
                Bitmap inputBitmap = null;
                private void Canny_Load(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        int ByteDepth = 0;

                        PixelFormat pixelFormat = new PixelFormat();
                        ColorPalette palette = null;
                        f = dyn_bmp2array(inputBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                        if (ByteDepth != 1)
                        {
                                MessageBox.Show("影像色彩通道數必須為1");
                                return;
                        }
                        g = new int[(PB_Width-6) * (PB_Height-6)];
                        unsafe
                        {
                                fixed (int* f0 = f) fixed (int* g0 = g)
                                {
                                        canny_process(f0, PB_Width, PB_Height, g0);
                                }
                        }
                       

                        Bitmap preview_bitmap = dyn_array2bmp(g, 1, pixelFormat, palette, PB_Width-6, PB_Height-6);



                        ChangeImage(pictureBox1, inputBitmap);
                        ChangeImage(pictureBox2, preview_bitmap);
                }

                private void ChangeImage(PictureBox pictureBox, Bitmap bitmap)
                {
                        pictureBox.Image = bitmap;
                        pictureBox.Width = bitmap.Width;
                        pictureBox.Height = bitmap.Height;
                }
        }
}
