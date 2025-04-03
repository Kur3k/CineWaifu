namespace CineWaifu.Abstractions
{
    public interface IDistanceProvider
    {
        public double Calculate(IColor colorA, IColor colorB);
    }
}
