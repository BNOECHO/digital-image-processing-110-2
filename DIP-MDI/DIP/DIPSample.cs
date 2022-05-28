﻿using System;
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
                unsafe public static extern void encode_gray(int* f0, int w, int h, int* g0, int d);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_Hflip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_Vflip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_90flip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void encode_270flip(int* f0, int w, int h, int* g0, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void average_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void sobel_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void prewitt_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void gaussian_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void laplacian_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void pepper_noise_process(int* f, int w_in, int h_in, int D);
                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void median_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);

                [DllImport("dip_proc.dll", CallingConvention = CallingConvention.Cdecl)]
                unsafe public static extern void sharp_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D);
                
                Bitmap NpBitmap;
                int[] f;
                int[] g;
                int w, h;
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
                                        g = new int[w * h];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        encode_gray(f0, w, h, g0, ByteDepth);
                                                }
                                        }
                                        Bitmap temp = new Bitmap(100, 100, PixelFormat.Format8bppIndexed);
                                        ColorPalette grayscalePalette = temp.Palette;
                                        for (int i = 0; i < 256; i++) grayscalePalette.Entries[i] = Color.FromArgb(i, i, i);

                                        NpBitmap = dyn_array2bmp(g, 1, PixelFormat.Format8bppIndexed, grayscalePalette,PB_Width,PB_Height);//強行修改為1通道
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

                private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        Zoom newform = new Zoom(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = (Bitmap)newform.outputPictureBox.Image;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                        };
                                        newform.Show();
                                        break;
                                }
                        }


                }

                private void pepperNoiseToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        int[] f;
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
                                        unsafe
                                        {
                                                fixed (int* f0 = f)
                                                {
                                                        pepper_noise_process(f0, PB_Width, PB_Height, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(f, ByteDepth, pixelFormat, palette, PB_Width, PB_Height);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void averageFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f)fixed(int* g0=g)
                                                {
                                                        average_filter_process(f0, PB_Width, PB_Height,(PB_Width-2), (PB_Height - 2),g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width-2, PB_Height-2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void sobelFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        sobel_filter_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void prewittFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        prewitt_filter_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void gaussianFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        gaussian_filter_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void laplacianFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        laplacian_filter_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        median_filter_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        Rotate newform = new Rotate(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = (Bitmap)newform.outputPictureBox.Image;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                        };
                                        newform.Show();
                                        break;
                                }
                        }
                }

                private void sharpToolStripMenuItem_Click(object sender, EventArgs e)
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
                                        g = new int[(PB_Width - 2) * (PB_Height - 2) * ByteDepth];
                                        unsafe
                                        {
                                                fixed (int* f0 = f) fixed (int* g0 = g)
                                                {
                                                        sharp_process(f0, PB_Width, PB_Height, (PB_Width - 2), (PB_Height - 2), g0, ByteDepth);
                                                }
                                        }
                                        NpBitmap = dyn_array2bmp(g, ByteDepth, pixelFormat, palette, PB_Width - 2, PB_Height - 2);
                                        MSForm childForm = new MSForm();
                                        childForm.MdiParent = this;
                                        childForm.pf1 = stStripLabel;
                                        childForm.pBitmap = NpBitmap;
                                        childForm.Show();
                                        break;
                                }
                        }
                }

                private void oTSUToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        OTSU newform = new OTSU(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = (Bitmap)newform.pictureBox2.Image;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                        };
                                        newform.Show();
                                        break;
                                }
                        }
                }

                private void connectedcomponentLabelingToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        Connected_component_labeling newform = new Connected_component_labeling(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = (Bitmap)newform.pictureBox2.Image;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                                newform.Close();
                                        };
                                        newform.Show();
                                        break;
                                }
                        }
                }

                private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        foreach (Object Mdic in MdiChildren)
                        {
                                MSForm cF = null;
                                if (Mdic.GetType() == typeof(MSForm)) cF = (MSForm)Mdic;
                                else continue;
                                if (cF.Focused)
                                {
                                        Canny newform = new Canny(cF.pBitmap);
                                        newform.MdiParent = this;
                                        newform.button1.Click += delegate
                                        {
                                                MSForm childForm = new MSForm();
                                                childForm.pf1 = stStripLabel;
                                                childForm.pBitmap = (Bitmap)newform.pictureBox2.Image;
                                                childForm.MdiParent = this;
                                                childForm.Show();
                                                newform.Close();
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
