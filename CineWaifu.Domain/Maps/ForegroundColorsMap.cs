using CineWaifu.Abstractions.Enum;
using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Maps
{
    public static class AnsiForegroundColorsMap
    {
        public static AnsiForegroundColor ClosestColor(RgbColor rgbColor)
        {
            int minDistance = int.MaxValue;
            AnsiForegroundColor closestColor = default;

            foreach (KeyValuePair<AnsiForegroundColor, RgbColor> color in _foregroundColors.Value)
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

        private static readonly Lazy<IDictionary<AnsiForegroundColor, RgbColor>> _foregroundColors = new Lazy<IDictionary<AnsiForegroundColor, RgbColor>>(BuildForegroundColors, true);

        private static IDictionary<AnsiForegroundColor, RgbColor> BuildForegroundColors()
        {
            return new Dictionary<AnsiForegroundColor, RgbColor>()
            {
                { AnsiForegroundColor.Black, new RgbColor(0, 0, 0) },
                { AnsiForegroundColor.Red, new RgbColor(205, 0, 0) },
                { AnsiForegroundColor.Green, new RgbColor(0, 205, 0) },
                { AnsiForegroundColor.Yellow, new RgbColor(205, 205, 0) },
                { AnsiForegroundColor.Blue, new RgbColor(0, 0, 205) },
                { AnsiForegroundColor.Magenta, new RgbColor(205, 0, 205) },
                { AnsiForegroundColor.Cyan, new RgbColor(0, 205, 205) },
                { AnsiForegroundColor.White, new RgbColor(229, 229, 229) },
                { AnsiForegroundColor.Gray, new RgbColor(127, 127, 127) },
                { AnsiForegroundColor.BrightRed, new RgbColor(255, 85, 85) },
                { AnsiForegroundColor.BrightGreen, new RgbColor(85, 255, 85) },
                { AnsiForegroundColor.BrightYellow, new RgbColor(255, 255, 85) },
                { AnsiForegroundColor.BrightBlue, new RgbColor(85, 85, 255) },
                { AnsiForegroundColor.BrightMagenta, new RgbColor(255, 85, 255) },
                { AnsiForegroundColor.BrightCyan, new RgbColor(85, 255, 255) },
                { AnsiForegroundColor.BrightWhite, new RgbColor(255, 255, 255) },
            };
        }
    }
}
