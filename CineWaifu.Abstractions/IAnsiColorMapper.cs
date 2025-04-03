using CineWaifu.Abstractions.Enum;

namespace CineWaifu.Abstractions
{
    public interface IAnsiColorMapper<T> where T : IColor
    {
        public AnsiColor GetClosestAnsiColor(T color);
    }
}
