using CineWaifu.Abstractions;

namespace CineWaifu.Domain.Model
{
    public record RgbColor : IColor
    {
        public RgbColor(int r, int g, int b)
        {
            R = Math.Clamp(r, 0, 255);
            G = Math.Clamp(g, 0, 255);
            B = Math.Clamp(b, 0, 255);
        }

        public int R { get; init; }
        public int G { get; init; }
        public int B { get; init; }

        public double[] Components => [R, G, B];

        public double DistanceTo(IColor color, IDistanceProvider distanceProvider)
        {
            return distanceProvider.Calculate(color, this);
        }

        public double GetBrightness(IBrightnessCalculator brightnessCalculator)
        {
            return brightnessCalculator.Calculate(this);
        }
    }
}
