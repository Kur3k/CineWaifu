using CineWaifu.Abstractions;

namespace CineWaifu.Domain.Model
{
    public record LabColor : IColor
    {
        public LabColor(double l, double a, double b)
        {
            L = l;
            A = a;
            B = b;
        }

        public double L { get; init; }
        public double A { get; init; }
        public double B { get; init; }

        public double[] Components => [L, A, B];

        public double GetBrightness(IBrightnessCalculator brightnessCalculator)
        {
            throw new NotImplementedException();
        }

        public double DistanceTo(IColor color, IDistanceProvider distanceProvider)
        {
            return distanceProvider.Calculate(color, this);
        }
    }
}
