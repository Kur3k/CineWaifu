using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Utils
{
    public static class AnsiUtils
    {
        public static T ClosestColor<T>(RgbColor rgbColor, Dictionary<T, RgbColor> ansiColors) where T : Enum
        {
            int minDistance = int.MaxValue;
            T closestColor = default!;

            foreach (KeyValuePair<T, RgbColor> color in ansiColors)
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
    }
}
