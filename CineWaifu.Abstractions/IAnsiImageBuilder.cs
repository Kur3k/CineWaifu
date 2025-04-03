using CineWaifu.Abstractions.Enum;

namespace CineWaifu.Abstractions
{
    public interface IAnsiFrameBuilder
    {
        public IAnsiFrameBuilder WithLetter(char letter, AnsiColor fgColor, AnsiColor bgColor);
        public IAnsiFrameBuilder WithNewLine();
        public string Build();
    }
}
