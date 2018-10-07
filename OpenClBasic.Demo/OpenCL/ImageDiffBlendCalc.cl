__kernel void ImageDiffBlend(__global const uint* imageA, __global const uint* imageB, __global uint* imageC)
{
    int i = get_global_id(0);

    uint A = imageA[i];
    uint B = imageB[i];
    uint C = 0;

    if(A != B)
	{
		C = 0xffffffu ^ A;
	}
	imageC[i] = C;
}
