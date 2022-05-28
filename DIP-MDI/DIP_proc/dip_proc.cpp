// dip_proc.cpp : �w�q DLL ���ε{�����ץX�禡�C
//
#include "pch.h"
#include <math.h>
#include<random>
#include<time.h>
#include<vector>
#include<map>
#include<set>
#include<iostream>
#include<algorithm>
using namespace std;
extern "C" {
	//===========================================================================
	//
	//===========================================================================
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
						 g[(j * w + i)] = avg>255?255:avg;
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
					 int LU = f[(y1 * w_in + x1) * D + k];//���W
					 int RU = (x2 == w_in) ? 0 : f[(y1 * w_in + x2) * D + k]; //�k�W
					 int LD = (y2 == h_in) ? 0 : f[(y2 * w_in + x1) * D + k]; //���U
					 int RD = (y2 == h_in|| x2 == w_in) ? 0 : f[(y2 * w_in + x2) * D + k]; //�k�U
					 double alpha = mapping_x - x1;
					 double beta = mapping_y - y1;
					 g[(j * w_out + i) * D + k] = ((1 - alpha) * LU + alpha * RU) * (1 - beta) + (((1 - alpha) * LD + alpha * RD)) * beta;
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void average_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filter[3][3] =
		 { {1,1,1},
			 {1,1,1},
			 {1,1,1} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sum = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sum += f[((j + o) * w_in + (i + p)) * D + k] * filter[o][p];
					 }
					 g[(j * w_out + i) * D + k] = sum / 9;
				 }
			 }
		 }
		 //===========================================================================
	 }
	 __declspec(dllexport) void sobel_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filterX[3][3] =
		 { {1,0,-1},
			 {2,0,-2},
			 {1,0,-1} };
		 double filterY[3][3] =
		 { {1,2,1},
			 {0,0,0},
			 {-1,-2,-1} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sumX = 0;
					 double sumY = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sumX += f[((j + o) * w_in + (i + p)) * D + k] * filterX[o][p];
						 sumY += f[((j + o) * w_in + (i + p)) * D + k] * filterY[o][p];
					 }
					 g[(j * w_out + i) * D + k] = sqrt(pow(sumX, 2) + pow(sumY, 2));
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void prewitt_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filterX[3][3] =
		 { {1,0,-1},
			 {1,0,-1},
			 {1,0,-1} };
		 double filterY[3][3] =
		 { {1,1,1},
			 {0,0,0},
			 {-1,-1,-1} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sumX = 0;
					 double sumY = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sumX += f[((j + o) * w_in + (i + p)) * D + k] * filterX[o][p];
						 sumY += f[((j + o) * w_in + (i + p)) * D + k] * filterY[o][p];
					 }
					 g[(j * w_out + i) * D + k] = sqrt(pow(sumX, 2) + pow(sumY, 2));
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void gaussian_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filter[3][3] =
		 { {1,2,1},
			 {2,4,2},
			 {1,2,1} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sum = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sum += f[((j + o) * w_in + (i + p)) * D + k] * filter[o][p];
					 }
					 g[(j * w_out + i) * D + k] = sum / 16;
				 }
			 }
		 }
		 //===========================================================================
	 }
	 __declspec(dllexport) void laplacian_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filter[3][3] =
		 { {0,1,0},
			 {1,-4,1},
			 {0,1,0} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sum = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sum += f[((j + o) * w_in + (i + p)) * D + k] * filter[o][p];
					 }
					 g[(j * w_out + i) * D + k] = sum;
				 }
			 }
		 }
		 //===========================================================================
	 }
	 __declspec(dllexport) void sharp_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		 double filter[3][3] =
		 { {-1,-1,-1},
			 {-1,9,-1},
			 {-1,-1,-1} };
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 double sum = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sum += f[((j + o) * w_in + (i + p)) * D + k] * filter[o][p];
					 }
					 sum = sum > 255 ? 255 : sum;
					 sum = sum < 0 ? 0 : sum;
					 g[(j * w_out + i) * D + k] = sum;
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void pepper_noise_process(int* f, int w_in, int h_in, int D)
	 {
		 srand(time(NULL));
		 for (int j = 0; j < h_in; j++)
		 {
			 for (int i = 0; i < w_in; i++)
			 {
				 double ran = (double)rand() / (double)RAND_MAX;
				 if (ran < 0.02)
				 {
					 int pepper = rand() % 256;
					 for (int k = 0; k < D; k++)
					 {
						 f[(j * w_in + i) * D + k] = pepper;
					 }
				 }
			 }
		 }
		 //===========================================================================
	 }
	 __declspec(dllexport) void median_filter_process(int* f, int w_in, int h_in, int w_out, int h_out, int* g, int D)
	 {
		
		 for (int j = 0; j < h_out; j++)
		 {
			 for (int i = 0; i < w_out; i++)
			 {
				 for (int k = 0; k < D; k++)
				 {
					 
					 vector<int> filter;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 filter.push_back( f[((j + o) * w_in + (i + p)) * D + k] );
					 }
					 sort(filter.begin(), filter.end());
					 g[(j * w_out + i) * D + k] = filter[4];
				 }
			 }
		 }
		 //===========================================================================
	 }

	 __declspec(dllexport) void rotate_process(int* f, int w_in, int h_in, int &w_out, int &h_out, int* g, int D,int degree)
	 {
		 double PI = acos(-1);
		 double theta = (double)degree/180 * PI;
		 vector<double> Xrotated;
		 vector<double> Yrotated;
		 Xrotated.push_back(0);//���W
		 Xrotated.push_back(w_in *cos(theta)-0* sin(theta));//���U
		 Xrotated.push_back(w_in * cos(theta) - h_in * sin(theta));//�k�U
		 Xrotated.push_back(0 * cos(theta) - h_in * sin(theta));//�k�W
		 Yrotated.push_back(0);//���W
		 Yrotated.push_back(h_in * cos(theta) + 0 * sin(theta));//���U
		 Yrotated.push_back(h_in * cos(theta) + w_in * sin(theta));//�k�U
		 Yrotated.push_back(0 * cos(theta) + w_in * sin(theta));//�k�W
		 sort(Xrotated.begin(), Xrotated.end());
		 sort(Yrotated.begin(), Yrotated.end());
		 int Xmax = Xrotated[3];
		 int Xmin = Xrotated[0];
		 int Ymax = Yrotated[3];
		 int Ymin = Yrotated[0];
		 
		 double SIN = sin(-theta);
		 double COS = cos(-theta);
		 w_out = (double)Xrotated[3] - (double)Xrotated[0] ;
		 h_out = (double)Yrotated[3] - (double)Yrotated[0];
		 //above correct
		 for (int j = Ymin; j <= Ymax; j++)
		 {
			 for (int i = Xmin; i <= Xmax; i++)
			 {
				 double mapping_x = (double)i*COS- (double)j*SIN;
				 double mapping_y = (double)i*SIN+ (double)j*COS;
				 int x1 = (int)mapping_x;
				 int y1 = (int)mapping_y;
				 int x2 = x1 + 1;
				 int y2 = y1 + 1;

				 for (int k = 0; k < D; k++)
				 {
					 if (x1 >= 0 && x1 < w_in && y1 >= 0 && y1 < h_in)
					 {
						 int LU = f[(y1 * w_in + x1) * D + k];//���W
						 int RU = (x2 == w_in) ? 0 : f[(y1 * w_in + x2) * D + k]; //�k�W
						 int LD = (y2 == h_in) ? 0 : f[(y2 * w_in + x1) * D + k]; //���U
						 int RD = (y2 == h_in || x2 == w_in) ? 0 : f[(y2 * w_in + x2) * D + k]; //�k�U
						 double alpha = mapping_x - x1;
						 double beta = mapping_y - y1;
						 g[((j - Ymin) * w_out + (i - Xmin)) * D + k] = ((1 - alpha) * LU + alpha * RU) * (1 - beta) + (((1 - alpha) * LD + alpha * RD)) * beta;
					 }
					 else g[((j - Ymin) * w_out + (i - Xmin)) * D + k] = 255;
				 }

			 }
		 }

		 

		 //===========================================================================
	 }

	 __declspec(dllexport) void OTSU_process(int* f, int w_in, int h_in, int D)
	 {
		 srand(time(NULL));

		 for (int k = 0; k < D; k++)
		 {
			 map<int, int> Histogram;

			 for (int i = 0; i < 256; i++) Histogram[i] = 0;
			 for (int j = 0; j < h_in; j++)
			 {
				 for (int i = 0; i < w_in; i++)
				 {
					 Histogram[f[(j * w_in + i) * D + k]]++;
				 }
			 }
			 
			 int threshold = 0;
			 double maxBetweenClassVariance = 0;
			 //�H�U�i�H�u�� ��ѨӰ�
			 for (int t = 0; t < 256; t++)
			 {
				 int n0=0;
				 int u0 = 0;
				 
				 int n1=0;
				 int u1 = 0;
				 for (int i = 0; i < 256; i++)
				 {
					 if (i < t)
					 {
						 n0 += Histogram[i];
						 u0 += Histogram[i] * i;
					 }
					 else
					 {
						 n1 += Histogram[i];
						 u1 += Histogram[i] * i;
					 }
					 

				 }
				 if (n0 == 0 || n1 == 0)continue;

				 u0 /= n0;
				 u1 /= n1;

				 double BCV = ((double)n0 / (double)(w_in * h_in)) * ((double)n1 / (double)(w_in * h_in)) * pow(u0 - u1, 2);
				 if (BCV > maxBetweenClassVariance)
				 {
					 maxBetweenClassVariance = BCV;
					 threshold = t;
				 }

			 }

			 for (int j = 0; j < h_in; j++)
			 {
				 for (int i = 0; i < w_in; i++)
				 {
					 if (f[(j * w_in + i) * D + k] < threshold)f[(j * w_in + i) * D + k] = 0;
					 else f[(j * w_in + i) * D + k] = 255;
				 }
			 }


		 }
		 //===========================================================================
	 }
	


	 __declspec(dllexport) void connected_component_labeling_process(int* f, int w_in, int h_in, int* g,int &count)
	 {
		 map<int, set<int>*> mapping;
		 map<int, int> outputmapping;

		 count = 0;
		 for (int j = 0; j < h_in; j++)
		 {
			 for (int i = 0; i < w_in; i++)
			 {
				 g[(j * w_in + i)] = 0;
				 if (f[(j * w_in + i) ] < 128)f[(j * w_in + i)] = 0;
				 else f[(j * w_in + i)] = 1;
			 }
		 }
		 int counting=0;
		 for (int j = 0; j < h_in; j++)
		 {
			 for (int i = 0; i < w_in; i++)
			 {

				 if (f[(j * w_in + i)] == 1)
				 {
					 int U = 0, L = 0;
					 if (j - 1 >= 0 && g[((j - 1) * w_in + i)] != 0)
					 {
						 U = g[((j - 1) * w_in + i)];
					 }
					 if (i - 1 >= 0 && g[(j  * w_in + (i-1))] != 0)
					 {
						 L = g[(j  * w_in + (i-1))];
					 }
					 if (L != 0)g[(j * w_in + i)] = L;
					 if (U != 0)g[(j * w_in + i)] = U;
					 
					 if (U == 0 && L == 0) 
					 {
						 g[(j * w_in + i)] = ++counting;
						 mapping[counting] = new set<int>();
						 mapping[counting]->insert(counting); 
					 }
					 if (U != 0 && L != 0 && U != L)
					 {
						 mapping[U]->insert(mapping[L]->begin(), mapping[L]->end());
						 mapping[L] = mapping[U];
					 }

				 }

			 }

		 }

		 for (int i = counting; i > 0; i--)
		 {
			 int target = *(mapping[i]->begin());
			 if (target == i)
			 {
				 count++;
				 outputmapping[i] = count;
			 }

		 }

		 for (int j = 0; j < h_in; j++)
		 {
			 for (int i = 0; i < w_in; i++)
			 {

				 if (f[(j * w_in + i)] == 1)
				 {
					 g[(j * w_in + i)] = outputmapping[*(mapping[g[(j * w_in + i)]]->begin())];
				 }

			 }

		 }

	 }

	 __declspec(dllexport) void canny_process(int* f, int w_in, int h_in, int* g)
	 {
		 double* Gau = new double[(w_in-2) * (h_in-2)];
		 
		 double GS = 0;
		 double filterX[3][3] =
		 { {1,0,-1},
			 {2,0,-2},
			 {1,0,-1} };
		 double filterY[3][3] =
		 { {-1,-2,-1},
			 {0,0,0},
			 {1,2,1} };
		 double filter[3][3] =
		 { {1,2,1},
			 {2,4,2},
			 {1,2,1} };
		 for (int j = 0; j < h_in-2; j++)
		 {
			 for (int i = 0; i < w_in-2; i++)
			 {
					 double sum = 0;
					 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
					 {
						 sum += f[((j + o) * w_in + (i + p)) ] * filter[o][p];
					 }
					 Gau[(j * (w_in-2) + i)] = sum / 16;
					 GS+= sum / 16;
			 }
		 }
		 

		 w_in -= 2;
		 h_in -= 2;
		 GS /= (double)(w_in * h_in);
		 double* I = new double[(w_in - 2) * (h_in - 2)];
		 double* D = new double[(w_in - 2) * (h_in - 2)];
		


		 for (int j = 0; j < h_in - 2; j++)
		 {
			 for (int i = 0; i < w_in - 2; i++)
			 {
				 double sumX = 0;
				 double sumY = 0;
				 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
				 {
					 sumX += Gau[((j + o) * (w_in) + (i + p))] * filterX[o][p];
					 sumY += Gau[((j + o) * (w_in) + (i + p))] * filterY[o][p];
				 }
				 I[(j * (w_in - 2) + i)] = sqrt(sumX * sumX + sumY * sumY);
				 D[(j * (w_in - 2) + i)] = (sumY!=0||sumX!=0)?atan2(sumY, sumX):-999;
			 }
		 }
		  
		 w_in -= 2;
		 h_in -= 2;


		 for (int j = 1; j < h_in -1 ; j++)
		 {
			 for (int i = 1; i < w_in - 1; i++)
			 {
				 double degree = (D[(j * (w_in)+i)] * (double)180 / acos(-1)) ;
				 if (degree > 90)degree -= 180;
				 if (degree <= -90)degree += 180;
				 double P0=0, P1=0, P2=0;
				 P0 = I[(j * (w_in ) + i)];
				 if (degree > -27.5&&degree<=27.5)
				 {
					 P1 = I[((j - 0) * (w_in)+(i + 1))];
					 P2 = I[((j + 0) * (w_in)+(i - 1))];
				 }
				 else if (degree > 27.5 && degree <= 72.5)
				 {
					 P1 = I[((j - 1) * (w_in)+(i + 1))];
					 P2 = I[((j + 1) * (w_in)+(i - 1))];
				 }
				 else if (degree > 72.5 && degree <= 90)
				 {
					 P1 = I[((j - 1) * (w_in)+(i + 0))];
					 P2 = I[((j + 1) * (w_in)+(i - 0))];
				 }
				 else if (degree > -90 && degree <= -72.5)
				 {
					 P1 = I[((j - 1) * (w_in)+(i + 0))];
					 P2 = I[((j + 1) * (w_in)+(i - 0))];
				 }
				 else if (degree > -72.5 && degree <= 27.5)
				 {
					 P1 = I[((j - 1) * (w_in)+(i - 1))];
					 P2 = I[((j + 1) * (w_in)+(i + 1))];
				 }

				 else
				 {
					 I[(j * (w_in)+i)] = 0;
				 }
					 
				 if (P0 < P1 || P0 < P2)
				 {
					 I[(j * (w_in)+i)] = 0;
				 }


			 }
		 }
		 

		

		 double lowThreshold=GS*0.35, highThreshold=GS*0.7 ;
		 
		 for (int j = 1; j < h_in - 1; j++)
		 {
			 for (int i = 1; i < w_in - 1; i++)
			 {
				 if (I[(j * (w_in)+i)] > highThreshold)I[(j * (w_in)+i)] = 255;
				 else if (I[(j * (w_in)+i)] < lowThreshold)I[(j * (w_in)+i)] = 0;
			 }
		 }
		 for (int j = 1; j < h_in - 1; j++)
		 {
			 for (int i = 1; i < w_in - 1; i++)
			 {
				 if (I[(j * (w_in)+i)] == 0)continue;
				 int HightCount = 0;
				 for (int o = 0; o < 3; o++)for (int p = 0; p < 3; p++)
				 {
					 if (I[((j - 1 + o) * (w_in)+(i - 1 + p))] == 255)HightCount++;
				 }
				 if(HightCount>=2)I[(j * (w_in)+i)] = 255;
				 else I[(j * (w_in)+i)] = 0;
			 }
		 }
		 
		 w_in -= 2;
		 h_in -= 2;
		 for (int j = 0; j < h_in ; j++)
		 {
			 for (int i = 0; i < w_in ; i++)
			 {
				 g[(j * (w_in)+i)] = I[((j + 1) * (w_in + 2) + (i + 1))];
			 }
		 }
		 
		

	 }
	



}