//===========================================================================
// some special routines
//===========================================================================
inline int round(double s)
{
	if(s>=0) s=s+0.5; else s=s-0.5;
	return((int)s);
}

inline int clip(double s)
{
	if(s>255) s=255;
	if(s<0)   s=0;
	if(s>=0)  s=s+0.5; else s=s-0.5;
	return((int)s);
}
//===========================================================================

//===========================================================================
//
//===========================================================================
void copy(int* f, int w, int h, int* g)
{
	int i, j;

	for (j = 0; j < h; j++)
	{
		for (i = 0; i < w; i++)
		{
			*g++ = *f++;
		}
	}
}
//===========================================================================

//===========================================================================
//
//===========================================================================
void block_get(int* f, int wf, int hf, int* b, int wb, int hb, int i0, int j0)
{
	int i, j;
	int* ptf, wdiff;

	ptf = f + i0 + j0 * wf;
	wdiff = wf - wb;
	for (j = 0; j < hb; j++)
	{
		for (i = 0; i < wb; i++)
			*b++ = *ptf++;
		ptf += wdiff;
	}
}
//===========================================================================

//===========================================================================
//
//===========================================================================
void block_put(int* b, int wb, int hb, int* g, int wg, int hg, int i0, int j0)
{
	int i, j;

	for (j = 0; j < hb; j++)
		for (i = 0; i < wb; i++)
			g[(i + i0) + ((j + j0) * wg)] = b[i + (j * wb)];
}
//===========================================================================

//===========================================================================
// contrast
//===========================================================================
void contrast(int* f, int w, int h, int* g, double p)
{
	int i, j;

	for (j = 0; j < h; j++)
	{
		for (i = 0; i < w; i++)
		{
			*g++ = clip(1.0 * (*f++) * p);
		}
	}
}
//===========================================================================

//===========================================================================
// contrast
//===========================================================================
void contrast(int *f,int w,int h,double p)
{
	int *g;

	g=new int[w*h];
	contrast(f,w,h,g,p);
	copy(g,w,h,f);
	delete g;
}
//===========================================================================
