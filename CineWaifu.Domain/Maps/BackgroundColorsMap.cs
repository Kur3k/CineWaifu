using CineWaifu.Abstractions.Enum;
using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Maps
{
    public static class AnsiBackgroundColorsMap
    {
        public static AnsiBackgroundColor ClosestColor(RgbColor rgbColor)
        {
            int minDistance = int.MaxValue;
            AnsiBackgroundColor closestColor = default;

            foreach (KeyValuePair<AnsiBackgroundColor, RgbColor> color in _backgroundColors.Value)
            {
                var colorRGB = color.Value;
                int dr = colorRGB.R - rgbColor.R;
                int dg = colorRGB.G - rgbColor.G;
                int db = colorRGB.B - rgbColor.B;

                int distance = dr * dr + dg * dg + db * db;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = color.Key;
                }
            }
            return closestColor;
        }

        private static readonly Lazy<IDictionary<AnsiBackgroundColor, RgbColor>> _backgroundColors = new Lazy<IDictionary<AnsiBackgroundColor, RgbColor>>(BuildBackgroundColors, true);

        private static IDictionary<AnsiBackgroundColor, RgbColor> BuildBackgroundColors()
        {
            return new Dictionary<AnsiBackgroundColor, RgbColor>()
            {
                { AnsiBackgroundColor.Black, new RgbColor(0, 0, 0) },
                { AnsiBackgroundColor.Red, new RgbColor(205, 0, 0) },
                { AnsiBackgroundColor.Green, new RgbColor(0, 205, 0) },
                { AnsiBackgroundColor.Yellow, new RgbColor(205, 205, 0) },
                { AnsiBackgroundColor.Blue, new RgbColor(0, 0, 205) },
                { AnsiBackgroundColor.Magenta, new RgbColor(205, 0, 205) },
                { AnsiBackgroundColor.Cyan, new RgbColor(0, 205, 205) },
                { AnsiBackgroundColor.White, new RgbColor(229, 229, 229) },
                { AnsiBackgroundColor.Gray, new RgbColor(127, 127, 127) },
                { AnsiBackgroundColor.BrightRed, new RgbColor(255, 85, 85) },
                { AnsiBackgroundColor.BrightGreen, new RgbColor(85, 255, 85) },
                { AnsiBackgroundColor.BrightYellow, new RgbColor(255, 255, 85) },
                { AnsiBackgroundColor.BrightBlue, new RgbColor(85, 85, 255) },
                { AnsiBackgroundColor.BrightMagenta, new RgbColor(255, 85, 255) },
                { AnsiBackgroundColor.BrightCyan, new RgbColor(85, 255, 255) },
                { AnsiBackgroundColor.BrightWhite, new RgbColor(255, 255, 255) },
            };
        }
    }
}
