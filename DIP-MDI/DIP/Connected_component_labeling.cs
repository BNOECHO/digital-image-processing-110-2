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

namespace DIP
{
        public partial class Connected_component_labeling : Form
        {
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void connected_component_labeling_process(int* f, int w_in, int h_in, int* g, ref int count);
                Bitmap inputBitmap = null;
                public Connected_component_labeling(Bitmap bitmap)
                {
                        inputBitmap = bitmap;
                        InitializeComponent();
                }
                private void ChangeImage(PictureBox pictureBox, Bitmap bitmap)
                {
                        pictureBox.Image = bitmap;
                        pictureBox.Width = bitmap.Width;
                        pictureBox.Height = bitmap.Height;
                }
                public static Color ColorFromHSV(double hue, double saturation, double value)
                {
                        hue %= 360;
                        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                        double f = hue / 60 - Math.Floor(hue / 60);

                        value = value * 255;
                        int v = Convert.ToInt32(value);
                        int p = Convert.ToInt32(value * (1 - saturation));
                        int q = Convert.ToInt32(value * (1 - f * saturation));
                        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

                        if (hi == 0)
                                return Color.FromArgb(255, v, t, p);
                        else if (hi == 1)
                                return Color.FromArgb(255, q, v, p);
                        else if (hi == 2)
                                return Color.FromArgb(255, p, v, t);
                        else if (hi == 3)
                                return Color.FromArgb(255, p, q, v);
                        else if (hi == 4)
                                return Color.FromArgb(255, t, p, v);
                        else
                                return Color.FromArgb(255, v, p, q);
                }
                private void Connected_component_labeling_Load(object sender, EventArgs e)
                {

                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        int ByteDepth = 0;
                        int connect_count = 0;
                        PixelFormat pixelFormat = new PixelFormat();
                        ColorPalette palette = null;
                        f = dyn_bmp2array(inputBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                        if (ByteDepth != 1)
                        {
                                MessageBox.Show("影像色彩通道數必須為1");
                                return;
                        }
                        g = new int[PB_Width * PB_Height];
                        unsafe
                        {
                                fixed (int* f0 = f) fixed (int* g0 = g)
                                {
                                        connected_component_labeling_process(f0, PB_Width, PB_Height, g0,ref connect_count);
                                }
                        }
                        Bitmap temp = new Bitmap(100, 100, PixelFormat.Format8bppIndexed);
                        ColorPalette HUEPalette = temp.Palette;
                        if (connect_count > 0) for (int i = 1; i <= connect_count && i < 256; i++) HUEPalette.Entries[i] = ColorFromHSV((360/connect_count)*i, 1, 1);


                        Bitmap preview_bitmap = dyn_array2bmp(g, 1, PixelFormat.Format8bppIndexed, HUEPalette, PB_Width, PB_Height);

                       

                        ChangeImage(pictureBox1, inputBitmap);
                        ChangeImage(pictureBox2, preview_bitmap);







                }

                private static Bitmap dyn_array2bmp(int[] ImgData, int ByteDepth, PixelFormat pixelFormat, ColorPalette palette, int width, int height)
                {
                        int Width = width;
                        int Height = height;
                        Bitmap myBitmap = new Bitmap(Width, Height, pixelFormat);
                        BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, Width, Height),
                                                       ImageLockMode.WriteOnly,
                                                       pixelFormat);
                        try
                        {
                                myBitmap.Palette = palette;
                        }
                        catch
                        {

                        }
                        //Padding bytes的長度
                        int ByteOfSkip = byteArray.Stride - myBitmap.Width * ByteDepth;
                        unsafe
                        {                                   // 指標取出影像資料
                                byte* imgPtr = (byte*)byteArray.Scan0;
                                for (int y = 0; y < Height; y++)
                                {
                                        for (int x = 0; x < Width; x++)
                                        {
                                                for (int c = 0; c < ByteDepth; c++)
                                                {
                                                        *imgPtr = (byte)ImgData[(x + Width * y) * ByteDepth + c];       //B
                                                        imgPtr += 1;
                                                }
                                        }
                                        imgPtr += ByteOfSkip; // 跳過Padding bytes
                                }
                        }
                        myBitmap.UnlockBits(byteArray);
                        return myBitmap;
                }
                private int[] dyn_bmp2array(Bitmap myBitmap, ref int ByteDepth, ref PixelFormat pixelFormat, ref ColorPalette palette, ref int Width, ref int Height)
                {
                        Width = myBitmap.Width;
                        Height = myBitmap.Height;
                        BitmapData byteArray = myBitmap.LockBits(new Rectangle(0, 0, myBitmap.Width, myBitmap.Height),
                                                      ImageLockMode.ReadWrite,
                                                      myBitmap.PixelFormat);
                        pixelFormat = myBitmap.PixelFormat;
                        palette = myBitmap.Palette;
                        ByteDepth = (int)(byteArray.Stride / myBitmap.Width);
                        int[] ImgData = new int[myBitmap.Width * myBitmap.Height * ByteDepth];
                        int ByteOfSkip = byteArray.Stride - byteArray.Width * ByteDepth;
                        unsafe
                        {
                                byte* imgPtr = (byte*)(byteArray.Scan0);
                                for (int y = 0; y < byteArray.Height; y++)
                                {
                                        for (int x = 0; x < byteArray.Width; x++)
                                        {
                                                for (int c = 0; c < ByteDepth; c++)
                                                {
                                                        ImgData[(x + byteArray.Width * y) * ByteDepth + c] = (int)*(imgPtr);
                                                        imgPtr += (int)(byteArray.Stride / myBitmap.Width) / ByteDepth;
                                                }
                                        }
                                        imgPtr += ByteOfSkip;
                                }
                        }
                        myBitmap.UnlockBits(byteArray);
                        return ImgData;
                }


        }
}
