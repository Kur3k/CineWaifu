namespace CineWaifu.Abstractions
{
    public interface IGradientCalculator
    {
        int Calculate(IImage image, int x, int y, int[,] kernel);
    }
}
