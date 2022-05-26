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
        public partial class Zoom : Form
        {
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void zoom_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                private void ChangeImage(PictureBox pictureBox,Bitmap bitmap)
                {
                        pictureBox.Image = bitmap;
                        pictureBox.Width = bitmap.Width;
                        pictureBox.Height = bitmap.Height;
                }
                Bitmap input_bitmap = null;
                public Zoom(Bitmap bitmap)
                {
                        input_bitmap = bitmap;
                        InitializeComponent();
                }
                private void Zoom_Load(object sender, EventArgs e)
                {
                        ChangeImage(inputPictureBox, input_bitmap);
                        ChangeImage(outputPictureBox, input_bitmap);
                }

                private void textBox1_TextChanged(object sender, EventArgs e)
                {
                        double scale = 0;
                        if (Double.TryParse(textBox1.Text, out scale)&&scale>0)
                        {
                                int[] f;
                                int[] g;
                                int PB_Width = 0;
                                int PB_Height = 0;
                                int ByteDepth = 0;
                                PixelFormat pixelFormat = new PixelFormat();
                                ColorPalette palette = null;
                                f = dyn_bmp2array((Bitmap)inputPictureBox.Image, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                int scaled_Width= (int)(PB_Width*scale);
                                int scaled_Height = (int)(PB_Height * scale);
                                g = new int[scaled_Width * scaled_Height * ByteDepth];
                                unsafe
                                {
                                        fixed (int* f0 = f) fixed (int* g0 = g)
                                        {
                                                zoom_process(f0, PB_Width, PB_Height, scaled_Width, scaled_Height, g0, ByteDepth);
                                        }
                                }
                                Bitmap preview_bitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, scaled_Width,scaled_Height);
                               
                                ChangeImage(outputPictureBox, preview_bitmap);
                        }

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

        }
}
