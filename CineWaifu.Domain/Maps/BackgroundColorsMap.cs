using CineWaifu.Abstractions.Enum;
using CineWaifu.Domain.Extensions;
using CineWaifu.Domain.Model;
using CineWaifu.Domain.Utils;

namespace CineWaifu.Domain.Maps
{
    public static class AnsiBackgroundColorsMap
    {
        public static AnsiBackgroundColor ClosestColor(RgbColor rgbColor)
        {
            LabColor currentLabColor = rgbColor.ToLab();
            double minDistance = double.MaxValue;
            AnsiBackgroundColor closestColor = default;

            foreach (KeyValuePair<AnsiBackgroundColor, LabColor> color in _backgroundColors.Value)
            {
                LabColor mapLabColor = color.Value;

                double distance = DistanceCalculator.CalculateEuclidian(mapLabColor, currentLabColor);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = color.Key;
                }
            }
            return closestColor;
        }

        private static readonly Lazy<IDictionary<AnsiBackgroundColor, LabColor>> _backgroundColors = new Lazy<IDictionary<AnsiBackgroundColor, LabColor>>(BuildBackgroundColors, true);

        private static IDictionary<AnsiBackgroundColor, LabColor> BuildBackgroundColors()
        {
            return new Dictionary<AnsiBackgroundColor, LabColor>()
            {
                { AnsiBackgroundColor.Black, new RgbColor(0, 0, 0).ToLab() },
                { AnsiBackgroundColor.Red, new RgbColor(205, 0, 0).ToLab() },
                { AnsiBackgroundColor.Green, new RgbColor(0, 205, 0).ToLab() },
                { AnsiBackgroundColor.Yellow, new RgbColor(205, 205, 0).ToLab() },
                { AnsiBackgroundColor.Blue, new RgbColor(0, 0, 205).ToLab() },
                { AnsiBackgroundColor.Magenta, new RgbColor(205, 0, 205).ToLab() },
                { AnsiBackgroundColor.Cyan, new RgbColor(0, 205, 205).ToLab() },
                { AnsiBackgroundColor.White, new RgbColor(229, 229, 229).ToLab() },
                { AnsiBackgroundColor.Gray, new RgbColor(127, 127, 127).ToLab() },
                { AnsiBackgroundColor.BrightRed, new RgbColor(255, 85, 85).ToLab() },
                { AnsiBackgroundColor.BrightGreen, new RgbColor(85, 255, 85).ToLab() },
                { AnsiBackgroundColor.BrightYellow, new RgbColor(255, 255, 85).ToLab() },
                { AnsiBackgroundColor.BrightBlue, new RgbColor(85, 85, 255).ToLab() },
                { AnsiBackgroundColor.BrightMagenta, new RgbColor(255, 85, 255).ToLab() },
                { AnsiBackgroundColor.BrightCyan, new RgbColor(85, 255, 255).ToLab() },
                { AnsiBackgroundColor.BrightWhite, new RgbColor(255, 255, 255).ToLab() },
            };
        }
    }
}
