using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DIP
{
        public partial class DIPSample : Form
        {
                public DIPSample()
                {
                        InitializeComponent();
                }

                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode(int* f0, int w, int h, int* g0);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_gray(int* f0, int w, int h, int* g0, int d);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_Hflip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_Vflip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_90flip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_270flip(int* f0, int w, int h, int* g0, int D);

                Bitmap NpBitmap;
                int[] f;
                int[] g;
                int w, h;

                private void DIPSample_Load(object sender, EventArgs e)
                {
                        this.IsMdiContainer = true;
                        this.WindowState = FormWindowState.Maximized;
                        this.stStripLabel.Text = "";
                }

                private void openToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        oFileDlg.CheckFileExists = true;
                        oFileDlg.CheckPathExists = true;
                        oFileDlg.Title = "Open File - DIP Sample";
                        oFileDlg.ValidateNames = true;
                        oFileDlg.Filter = "bmp files (*.bmp)|*.bmp";
                        oFileDlg.FileName = "";

                        if (oFileDlg.ShowDialog() == DialogResult.OK)
                        {
                                MSForm childForm = new MSForm();
                                childForm.MdiParent = this;
                                childForm.pf1 = stStripLabel;
                                childForm.Text = oFileDlg.SafeFileName;
                                NpBitmap = bmp_read(oFileDlg);
                                childForm.pBitmap = NpBitmap;
                                w = NpBitmap.Width;
                                h = NpBitmap.Height;
                                childForm.Show();
                        }
                }

                private Bitmap bmp_read(OpenFileDialog oFileDlg)
                {
                        Bitmap pBitmap;
                        string fileloc = oFileDlg.FileName;
                        pBitmap = new Bitmap(fileloc);
                        w = pBitmap.Width;
                        h = pBitmap.Height;
                        return pBitmap;
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


                private static Bitmap dyn_array2bmp(int[] ImgData, int ByteDepth, PixelFormat pixelFormat, ColorPalette palette)
                {
                        int Width = (int)Math.Sqrt(ImgData.GetLength(0) / ByteDepth);
                        int Height = (int)Math.Sqrt(ImgData.GetLength(0) / ByteDepth);
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

                private void rGBtoGrayToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        int ByteDepth = 0;
                                        PixelFormat pixelFormat = new PixelFormat();
                                        ColorPalette palette = null;
                                        f = dyn_bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[w * h * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_gray(f0, w, h, g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }

                }


                private void horizontalFlipToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        int ByteDepth = 0;
                                        PixelFormat pixelFormat = new PixelFormat();
                                        ColorPalette palette = null;
                                        f = dyn_bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[w * h * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_Hflip(f0, w, h, g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width, PB_Height);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }

                }






                private void verticalFlipToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        int ByteDepth = 0;
                                        PixelFormat pixelFormat = new PixelFormat();
                                        ColorPalette palette = null;
                                        f = dyn_bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[w * h * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_Vflip(f0, w, h, g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width, PB_Height);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }

                }

                private void saveToolStripMenuItem_Click(object sender, EventArgs e)
                {

                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        saveFileDialog1.Filter = "Bitmap files (*.bmp)|*.bmp";
                                        saveFileDialog1.FileName = "untitled";
                                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                        {
                                                cF.pBitmap.Save(saveFileDialog1.FileName);
                                        }
                                }
                        }
                }

                private void _90degreeFlipToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        int ByteDepth = 0;
                                        PixelFormat pixelFormat = new PixelFormat();
                                        ColorPalette palette = null;
                                        f = dyn_bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[w * h * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_90flip(f0, w, h, g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Height, PB_Width);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }

                }

                private void _270degreeFlipToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                        int[] f;
                        int[] g;
                        int PB_Width = 0;
                        int PB_Height = 0;
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        int ByteDepth = 0;
                                        PixelFormat pixelFormat = new PixelFormat();
                                        ColorPalette palette = null;
                                        f = dyn_bmp2array(cF.pBitmap, ref ByteDepth, ref pixelFormat, ref palette, ref PB_Width, ref PB_Height);
                                        g = new int[w * h * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_270flip(f0, w, h, g0, ByteDepth);
                                                }
                                        }

                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Height, PB_Width);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }

                }

                private void linearBrightnessTransferToolStripMenuItem_Click(object sender, EventArgs e)
                {

                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        linear_brightness_transfer newform = new linear_brightness_transfer(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = newform.res_Bitmap;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                        };
                                        newform.Show();

                                        break;
                                }
                        }
                }

                private void histogramEqualizationToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        Histogram_equalization newform = new Histogram_equalization(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = newform.res_Bitmap;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                        };
                                        newform.Show();
                                        break;
                                }
                        }
                }

                private void fileToolStripMenuItem_Click(object sender, EventArgs e)
                {

                }

        }
}
