using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CineWaifu.Domain.Extensions
{
    public static class ImageExtensions
    {
        public static Image<Rgba32> ToSobelImage(this Image<Rgba32> originalImage)
        {
            Image<Rgba32> sobel = originalImage.Clone();
            sobel.Mutate(x => x.Grayscale());
            sobel = sobel.DifferenceOfGaussian(1.0f, 3.0f);
            sobel.Mutate(x => x.DetectEdges(KnownEdgeDetectorKernels.Sobel));
            return sobel;
        }

        public static Image<Rgba32> DifferenceOfGaussian(this Image<Rgba32> image, float smallSigma, float largeSigma)
        {
            Image<Rgba32> blurredSmallSigma = image.Clone(ctx => ctx.GaussianBlur(smallSigma));
            Image<Rgba32> blurredLargeSigma = image.Clone(ctx => ctx.GaussianBlur(largeSigma));
            return SubtractImages(blurredSmallSigma, blurredLargeSigma);
        }

        private static Image<Rgba32> SubtractImages(Image<Rgba32> image1, Image<Rgba32> image2)
        {
            int width = image1.Width;
            int height = image1.Height;
            var result = new Image<Rgba32>(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rgba32 pixel1 = image1[x, y];
                    Rgba32 pixel2 = image2[x, y];

                    byte r = (byte)Math.Clamp(pixel1.R - pixel2.R, 0, 255);
                    byte g = (byte)Math.Clamp(pixel1.G - pixel2.G, 0, 255);
                    byte b = (byte)Math.Clamp(pixel1.B - pixel2.B, 0, 255);

                    result[x, y] = new Rgba32(r, g, b);
                }
            }
            return result;
        }
    }
}
