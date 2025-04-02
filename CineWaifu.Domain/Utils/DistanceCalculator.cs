using CineWaifu.Domain.Model;

namespace CineWaifu.Domain.Utils
{
    public static class DistanceCalculator
    {
        public static double CalculateEuclidian(LabColor colorA, LabColor colorB)
        {
            return Math.Sqrt(Math.Pow(colorB.L - colorA.L, 2) +
                             Math.Pow(colorB.A - colorA.A, 2) + 
                             Math.Pow(colorB.B - colorA.B, 2));
        }
    }
}
