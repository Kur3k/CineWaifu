using CineWaifu.Abstractions;

namespace CineWaifu.Domain.Utils
{
    public class GradientCalculator : IGradientCalculator
    {
        public int Calculate(IImage image, int x, int y, int[,] kernel)
        {
            int gradient = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int pixel = (int)image.GetPixel(x + i, y + j).Components[0];
                    int kernelValue = kernel[i + 1, j + 1];
                    gradient += pixel * kernelValue;
                }
            }
            return gradient;
        }
    }
}
