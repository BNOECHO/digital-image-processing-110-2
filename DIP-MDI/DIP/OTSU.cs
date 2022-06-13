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
        public partial class OTSU : Form
        {
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void OTSU_process(int* f, int w_in, int h_in, int D);
                private void ChangeImage(PictureBox pictureBox, Bitmap bitmap)
                {
                        pictureBox.Image = bitmap;
                        pictureBox.Width = bitmap.Width;
                        pictureBox.Height = bitmap.Height;
                }
                public OTSU(Bitmap bitmap)
                {
                        input_bitmap = bitmap;
                        InitializeComponent();
                }
                Bitmap input_bitmap = null;
                Bitmap output_bitmap = null;
                private void OTSU_Load(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        int ByteDepth = 0;
                        PixelFormat pixelFormat = new PixelFormat();
                        ColorPalette palette = null;
                        f = dyn_bmp2array((Bitmap)input_bitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                        g = new int[PB_Width * PB_Height * ByteDepth];
                        unsafe
                        {
                                fixed (int* f0 = f) fixed (int* g0 = g)
                                {
                                        OTSU_process(f0, PB_Width, PB_Height, ByteDepth);
                                }
                        }
                        output_bitmap = dyn_array2bmp(f, ByteDepth, pixelFormat, palette, PB_Width, PB_Height);
                        ChangeImage(pictureBox1, input_bitmap);
                        ChangeImage(pictureBox2, output_bitmap);

                }

        }
}
