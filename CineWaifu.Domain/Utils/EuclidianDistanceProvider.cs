using CineWaifu.Abstractions;

namespace CineWaifu.Domain.Utils
{
    public class EuclidianDistanceProvider : IDistanceProvider
    {
        public double Calculate(IColor colorA, IColor colorB)
        {
            double[] colorAcomponents = colorA.Components;
            double[] colorBcomponents = colorB.Components;

            if (colorA.Components.Length != colorB.Components.Length)
                throw new InvalidOperationException();

            double distance = 0;
            for (int i = 0; i < colorBcomponents.Length; i++)
            {
                distance += Math.Pow(colorAcomponents[i] - colorBcomponents[i], 2);
            }
            return Math.Sqrt(distance);
        }
    }
}
