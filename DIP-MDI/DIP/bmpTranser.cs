using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace DIP
{
        public class BmpTranser
        {
                public static int[] dyn_bmp2array(Bitmap myBitmap, ref int ByteDepth, ref PixelFormat pixelFormat, ref ColorPalette palette, ref int Width, ref int Height)
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




                public static Bitmap dyn_array2bmp(int[] ImgData, int ByteDepth, PixelFormat pixelFormat, ColorPalette palette, int width, int height)
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






             
        }
}
