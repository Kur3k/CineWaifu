using CineWaifu.Abstractions;
using CineWaifu.Domain.Model.Color;

namespace CineWaifu.Domain.Utils
{
    public static class AnsiShaders
    {
        public static RgbColor Default(IColor color, int percentage) => new RgbColor((byte)color.Components[0], (byte)color.Components[1], (byte)color.Components[2]);

        public static RgbColor Darker(IColor color, int percentage) => new RgbColor((int)color.Components[0] - GetPercentage(color.Components[0], percentage), 
                                                                                    (int)color.Components[1] - GetPercentage(color.Components[1], percentage),
                                                                                    (int)color.Components[2] - GetPercentage(color.Components[2], percentage));

        public static RgbColor Lighter(IColor color, int percentage) => new RgbColor((int)color.Components[0] + GetPercentage(color.Components[0], percentage),
                                                                                     (int)color.Components[1] + GetPercentage(color.Components[1], percentage),
                                                                                     (int)color.Components[2] + GetPercentage(color.Components[2], percentage));
        private static int GetPercentage(double compound, int percentage)
        {
            return (int)(compound * (percentage / 100.0));
        }
    }
}
