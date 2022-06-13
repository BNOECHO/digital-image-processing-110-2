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
                unsafe public static extern void OTSU_process(int* f, int w_in, int h_in, int D,ref int Threshold);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void analyze_Histogram_process(int* f, int w, int h, int* count, int D);
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
                int Threshold = 0;
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
                                        OTSU_process(f0, PB_Width, PB_Height, ByteDepth,ref Threshold);
                                }
                        }
                        output_bitmap = dyn_array2bmp(f, ByteDepth, pixelFormat, palette, PB_Width, PB_Height);
                        ChangeImage(pictureBox1, input_bitmap);
                        ChangeImage(pictureBox2, output_bitmap);
                        ChangeImage(pictureBox3, analyze_Histogram(input_bitmap));
                }
                
                private Bitmap analyze_Histogram(Bitmap analyze_Bitmap)
                {
                        Bitmap bitmap = new Bitmap(255, 255);
                        Graphics G = Graphics.FromImage(bitmap);
                        SolidBrush solid = new SolidBrush(Color.White);
                        Pen pen = new Pen(Color.Black);
                        G.FillRectangle(solid, 0, 0, 255, 255);


                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        int ByteDepth = 0;
                        PixelFormat pixelFormat = new PixelFormat();
                        ColorPalette palette = null;
                        f = dyn_bmp2array(analyze_Bitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                        g = new int[256 * ByteDepth];
                        unsafe
                        {
                                fixed (int* f0 = f) fixed (int* g0 = g)
                                {
                                        analyze_Histogram_process(f0, PB_Width, PB_Height, g0, ByteDepth);
                                }
                        }
                        int gmax = g.Max();
                        if (ByteDepth == 1)
                        {
                                for (int i = 0; i < 256; i++) G.DrawLine(pen, i, 255, i, 255 - (g[i] * 256 / gmax));
                        }
                        if (ByteDepth == 3)
                        {
                                for (int i = 0; i < 256; i++) G.DrawLine(new Pen(Color.Red), i, 255, i, 255 - (g[i] * 256 / gmax));
                                for (int i = 256; i < 512; i++) G.DrawLine(new Pen(Color.Green), i - 256, 255, i - 256, 255 - (g[i] * 256 / gmax));
                                for (int i = 512; i < 768; i++) G.DrawLine(new Pen(Color.Blue), i - 512, 255, i - 512, 255 - (g[i] * 256 / gmax));
                        }
                        pen = new Pen(Color.Orange);
                        float[] dash = { 2, 2 };
                        pen.DashPattern = dash;
                        G.DrawLine(pen, Threshold, 255, Threshold, 0);

                        return bitmap;
                }

        }
}
