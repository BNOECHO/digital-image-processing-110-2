// dip_proc.cpp : 定義 DLL 應用程式的匯出函式。
//
#include "pch.h"
#include "image_lib.h"



extern "C" {
	//===========================================================================
	//
	//===========================================================================
	 __declspec(dllexport) void encode(int *f,int w,int h,int *g)
	{
		int i0,j0;
		int *b,wb,hb;

		wb=w/4;
		hb=h/4;
		b=new int[wb*hb];

		i0=w/4;
		j0=h/4;

		block_get(f,w,h,b,wb,hb,i0,j0);
		//contrast(b,wb,hb,1.5);
		copy(f,w,h,g);
		block_put(b,wb,hb,g,w,h,i0,j0);
		//===========================================================================
	}
	 __declspec(dllexport) void encode_gray(int* f, int w, int h, int* g,int d)
	 {
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 if (d == 1)
				 {
					 g[(j * w + i)] = f[(j * w + i)];
				 }
				 else
				 {
					 int avg = (double)f[(j * w + i) * 3] * 0.144 + (double)f[(j * w + i) * 3 + 1] * 0.587 + (double)f[(j * w + i) * 3 + 2] * 0.299;
					 for (int k = 0; k < 3; k++)
					 {
						 g[(j * w + i) * 3 + k] = avg;
					 }
				 }
			 }
		 }

		 //===========================================================================
	 }

	 __declspec(dllexport) void encode_Hflip(int* f, int w, int h, int* g,int D)
	 {
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 g[(j * w + i) * D + k] = f[(j * w + w-i-1) * D + k];
				 }
			 }
		 }

		 //===========================================================================
	 }
	 __declspec(dllexport) void encode_Vflip(int* f, int w, int h, int* g,int D)
	 {
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 g[(j * w + i) * D + k] = f[((h-j-1) * w +i ) * D + k];
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void encode_90flip(int* f, int w, int h, int* g, int D)
	 {
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					g[((i*h)+h-j-1)*D+k] =f[(j * w + i) * D + k] ;
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void encode_270flip(int* f, int w, int h, int* g, int D)
	 {
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 g[((i * h) + j ) * D + k] = f[(j * w + i) * D + k];
				 }
			 }
		 }
		 //===========================================================================
	 }

	
	 __declspec(dllexport) void linear_brightness_transfer_process(int* f, int w, int h, int* g, int D, float P1X, float P1Y, float P2X, float P2Y)
	 {
		 float transmap[256] = {100};
		 for (int i = 0; i < P1X; i++)
		 {
			 transmap[i] = (float)(P1Y * i) / (float)P1X;
		 }
		 for (int i = P1X; i < P2X; i++)
		 {
			 transmap[i] = P1Y + ((P2Y - P1Y) * (float)(i - P1X) / (float)(P2X - P1X));
		 }
		 for (int i = P2X; i < 256; i++)
		 {
			 transmap[i] = P2Y + (float)((256 - P2Y) * (float)(i - P2X) / (float)(256 - P2X));
		 }


		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 g[(j * w + i) * D + k] = transmap[f[(j * w + i) * D + k]];
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void analyze_Histogram_process(int* f, int w, int h, int* count, int D)
	 {
		 for (int i = 0; i < 256 * D; i++)count[i] = 0;
		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 count[256*k+f[(j * w + i) * D + k]]++;
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void analyze_Histogram_image_process(int* f, int w, int h,int*g,int*cdf, int D)
	 {
		 float transmap[768] = { 0 };
		 int mincdf[3] = {255};
		 int maxcdf[3] = {w*h};
		 for (int o = 0; o < D; o++)
		 {
			 for (int i = 0; i < 255; i++)if (cdf[o * 256 + i] != 0)
			 {
				 mincdf[o] = cdf[o * 256 + i];
				 break;
			 }
		 }
		 
		 for(int o=0;o<D;o++)
		 {
			 for (int i = 0; i < 255; i++)transmap[o*256+i] = (cdf[o * 256 + i]-mincdf[o]) * 255 / (w * h - mincdf[o]);
		 }


		 for (int j = 0; j < h; j++)
		 {
			 for (int i = 0; i < w; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 g[(j * w + i) * D + k] = transmap[k*256+f[(j * w + i) * D + k]];
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void zoom_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g,int D)
	 {
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double mapping_x = (double)i / ((double)w_out-1) * ((double)w_in-1);
					 double mapping_y = (double)j / ((double)h_out-1) * ((double)h_in-1);
					 int x1 = (int)mapping_x;
					 int y1 = (int)mapping_y;
					 int x2 = x1 + 1;
					 int y2 = y1 + 1;
					 int LU = f[(y1 * w_in + x1) * D + k];//左上
					 int RU = (x2 == w_in) ? 0 : f[(y1 * w_in + x2) * D + k]; //右上
					 int LD = (y2 == h_in) ? 0 : f[(y2 * w_in + x1) * D + k]; //左下
					 int RD = (y2 == h_in|| x2 == w_in) ? 0 : f[(y2 * w_in + x2) * D + k]; //右下
					 double alpha = mapping_x - x1;
					 double beta = mapping_y - y1;
					 g[(j * w_out + i) * D + k] = ((1 - alpha) * LU + alpha * RU) * (1 - beta) + (((1 - alpha) * LD + alpha * RD)) * beta;
				 }
			 }
		 }
		 



		 //===========================================================================
	 }

}