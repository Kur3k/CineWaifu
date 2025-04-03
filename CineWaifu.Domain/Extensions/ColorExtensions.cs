using CineWaifu.Domain.Model;
using SixLabors.ImageSharp.PixelFormats;

namespace CineWaifu.Domain.Extensions
{
    public static class ColorExtensions
    {
        public static LabColor ToLab(this RgbColor color)
        {
            return color.ToXyz().ToLab();
        }

        public static RgbColor ToRgbColor(this Rgba32 color)
        {
            return new RgbColor(color.R, color.G, color.B);
        }

        private static LabColor ToLab(this XyzColor xyz)
        {
            return XyzToLab(xyz.X, xyz.Y, xyz.Z);
        }

        private static double GammaCorrection(double compound)
        {
            return (compound <= 0.04045) ? compound / 12.92 : Math.Pow((compound + 0.055) / 1.055, 2.4);
        }

        private static XyzColor ToXyz(this RgbColor color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            r = GammaCorrection(r);
            g = GammaCorrection(g);
            b = GammaCorrection(b);

            double x = r * 0.4124564 + g * 0.3575761 + b * 0.1804375;
            double y = r * 0.2126729 + g * 0.7151522 + b * 0.0721750;
            double z = r * 0.0193339 + g * 0.1191920 + b * 0.9503041;

            x = x / 0.95047;
            y = y / 1.00000;
            z = z / 1.08883;

            return new XyzColor(x, y, z);
        }

        private static double ConvertCompoundXyzToLab(double compound)
        {
            return (compound > 0.008856) ? Math.Pow(compound, 1 / 3.0) : (compound * 903.3 + 16) / 116;
        }

        private static LabColor XyzToLab(double x, double y, double z)
        {
            double fx = ConvertCompoundXyzToLab(x);
            double fy = ConvertCompoundXyzToLab(y);
            double fz = ConvertCompoundXyzToLab(z);

            double L = 116 * fy - 16;
            double a = 500 * (fx - fy);
            double b = 200 * (fy - fz);

            return new LabColor(L, a, b);
        }

    }
}
