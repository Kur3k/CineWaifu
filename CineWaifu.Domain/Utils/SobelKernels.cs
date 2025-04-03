namespace CineWaifu.Domain.Utils
{
    public static class SobelKernels
    {
        public static int[,] GxKernel = new int[,]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        public static int[,] GyKernel = new int[,]
        {
            { 1, 2, 1 },
            { 0, 0, 0 },
            { -1, -2, -1 }
        };
    }
}
