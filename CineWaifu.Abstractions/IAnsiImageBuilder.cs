using CineWaifu.Abstractions.Enum;

namespace CineWaifu.Abstractions
{
    public interface IAnsiImageBuilder
    {
        public IAnsiImageBuilder WithLetter(char letter, AnsiColor fgColor, AnsiColor bgColor);
        public IAnsiImageBuilder WithNewLine();
        public string Build();
    }
}
