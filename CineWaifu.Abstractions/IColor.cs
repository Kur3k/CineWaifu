namespace CineWaifu.Abstractions
{
    public interface IColor
    {
        double[] Components { get; }
        double GetBrightness(IBrightnessCalculator brightnessCalculator);
        double DistanceTo(IColor color, IDistanceProvider distanceProvider);
    }
}
