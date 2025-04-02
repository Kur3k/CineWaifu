using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Shader
{
    public class AnsiCustomShaders
    {
        public static RgbColor Darker(RgbColor color, int percentage) => new RgbColor(color.R - GetPercentage(color.R, percentage),
                                                                                       color.G - GetPercentage(color.G, percentage),
                                                                                       color.B - GetPercentage(color.B, percentage));

        public static RgbColor Lighter(RgbColor color, int percentage) => new RgbColor(color.R + GetPercentage(color.R, percentage),
                                                                                       color.G + GetPercentage(color.G, percentage),
                                                                                       color.B + GetPercentage(color.B, percentage));
        private static int GetPercentage(int compound, int percentage)
        {
            return (int)(compound * (percentage / 100.0));
        }
    }
}
