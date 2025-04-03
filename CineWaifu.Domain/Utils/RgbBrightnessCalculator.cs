using CineWaifu.Abstractions;

namespace CineWaifu.Domain.Utils
{
    public class RgbBrightnessCalculator : IBrightnessCalculator
    {
        public double Calculate(IColor color)
        {
            return color.Components[0] * 0.299 +
                   color.Components[1] * 0.587 +
                   color.Components[2] * 0.114;
        }
    }
}
