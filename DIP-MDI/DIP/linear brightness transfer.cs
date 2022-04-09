using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace DIP
{
        public partial class linear_brightness_transfer : Form
        {
                internal Bitmap res_Bitmap=null;
                Bitmap input_bitmap=null;
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void linear_brightness_transfer_process(int* f, int w, int h, int* g, int D, float P1X, float P1Y, float P2X, float P2Y);
                public linear_brightness_transfer(Bitmap bitmap)
                {
                        InitializeComponent();
                        input_bitmap = bitmap;
                }
                private void numUD_P1X_ValueChanged(object sender, EventArgs e)
                {
                        if (numUD_P1X.Value > numUD_P2X.Value) numUD_P2X.Value = numUD_P1X.Value;
                        renew_graphic();
                }

                private void numUD_P2X_ValueChanged(object sender, EventArgs e)
                {
                        if (numUD_P1X.Value > numUD_P2X.Value) numUD_P1X.Value = numUD_P2X.Value;
                        renew_graphic();
                }
                private void renew_graphic()
                {
                        Bitmap bitmap = new Bitmap(255, 255);
                        Graphics G = Graphics.FromImage(bitmap);
                        SolidBrush solid = new SolidBrush(Color.White);
                        Pen pen = new Pen(Color.Black);
                        float P1X=(float)numUD_P1X.Value, P1Y= 255-(float)numUD_P1Y.Value, P2X= (float)numUD_P2X.Value, P2Y= 255-(float)numUD_P2Y.Value;
                        G.FillRectangle(solid,0, 0, 255, 255);
                        G.DrawLine(pen, 0, 255 ,P1X,P1Y);
                        G.DrawLine(pen,  P1X,P1Y,P2X,P2Y);
                        G.DrawLine(pen, P2X,P2Y,255,0);
                        G.DrawEllipse(pen, P1X- 4, P1Y - 4, 8,8);
                        G.DrawEllipse(pen, P2X - 4, P2Y- 4, 8, 8);
                        linear_function_graphic.Image = bitmap;

                        //=====================================================
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        int ByteDepth = 0;
                        PixelFormat pixelFormat = new PixelFormat();
                        ColorPalette palette = null;
                                        f = dyn_bmp2array(input_bitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[PB_Width * PB_Height * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        linear_brightness_transfer_process(f0, PB_Width, PB_Height, g0, ByteDepth,(int)numUD_P1X.Value, (int)numUD_P1Y.Value, (int)numUD_P2X.Value, (int)numUD_P2Y.Value);
                                                }
                                        }
                                        Bitmap preview_bitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Height, PB_Width);
                        pictureBox1.Image = preview_bitmap;
                        res_Bitmap = preview_bitmap;//test 觸發順序


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
                                                        ImgData[(x + byteArray.Height * y) * ByteDepth + c] = (int)*(imgPtr);
                                                        imgPtr += (int)(byteArray.Stride / myBitmap.Width) / ByteDepth;
                                                }
                                        }
                                        imgPtr += ByteOfSkip;
                                }
                        }
                        myBitmap.UnlockBits(byteArray);
                        return ImgData;
                }


                private void linear_brightness_transfer_Load(object sender, EventArgs e)
                {
                        renew_graphic();
                        pictureBox1.Image = input_bitmap;
                }

                private void numUD_P1Y_ValueChanged(object sender, EventArgs e)
                {
                        renew_graphic();
                }

                private void numUD_P2Y_ValueChanged(object sender, EventArgs e)
                {
                        renew_graphic();
                }

                private void button2_Click(object sender, EventArgs e)
                {
                        this.Close();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        this.Close();
                }
        }
}
