using CineWaifu.Abstractions.Enum;
using CineWaifu.Domain.Extensions;
using CineWaifu.Domain.Model;
using CineWaifu.Domain.Utils;

namespace CineWaifu.Domain.Maps
{
    public static class AnsiForegroundColorsMap
    {
        public static AnsiForegroundColor ClosestColor(RgbColor rgbColor)
        {
            LabColor currentLabColor = rgbColor.ToLab();
            double minDistance = double.MaxValue;
            AnsiForegroundColor closestColor = default;

            foreach (KeyValuePair<AnsiForegroundColor, LabColor> color in _foregroundColors.Value)
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

        private static readonly Lazy<IDictionary<AnsiForegroundColor, LabColor>> _foregroundColors = new Lazy<IDictionary<AnsiForegroundColor, LabColor>>(BuildForegroundColors, true);

        private static IDictionary<AnsiForegroundColor, LabColor> BuildForegroundColors()
        {
            return new Dictionary<AnsiForegroundColor, LabColor>()
            {
                { AnsiForegroundColor.Black, new RgbColor(0, 0, 0).ToLab() },
                { AnsiForegroundColor.Red, new RgbColor(205, 0, 0).ToLab() },
                { AnsiForegroundColor.Green, new RgbColor(0, 205, 0).ToLab() },
                { AnsiForegroundColor.Yellow, new RgbColor(205, 205, 0).ToLab() },
                { AnsiForegroundColor.Blue, new RgbColor(0, 0, 205).ToLab() },
                { AnsiForegroundColor.Magenta, new RgbColor(205, 0, 205).ToLab() },
                { AnsiForegroundColor.Cyan, new RgbColor(0, 205, 205).ToLab() },
                { AnsiForegroundColor.White, new RgbColor(229, 229, 229).ToLab() },
                { AnsiForegroundColor.Gray, new RgbColor(127, 127, 127).ToLab() },
                { AnsiForegroundColor.BrightRed, new RgbColor(255, 85, 85).ToLab() },
                { AnsiForegroundColor.BrightGreen, new RgbColor(85, 255, 85).ToLab() },
                { AnsiForegroundColor.BrightYellow, new RgbColor(255, 255, 85).ToLab() },
                { AnsiForegroundColor.BrightBlue, new RgbColor(85, 85, 255).ToLab() },
                { AnsiForegroundColor.BrightMagenta, new RgbColor(255, 85, 255).ToLab() },
                { AnsiForegroundColor.BrightCyan, new RgbColor(85, 255, 255).ToLab() },
                { AnsiForegroundColor.BrightWhite, new RgbColor(255, 255, 255).ToLab() },
            };
        }
    }
}
