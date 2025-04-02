using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Utils
{
    public static class BrightnessCalculator
    {
        public static double Calculate(RgbColor color) => (int)(Math.Sqrt(
            color.R * color.R * .241 +
            color.G * color.G * .691 +
            color.B * color.B * .068));
    }
}
