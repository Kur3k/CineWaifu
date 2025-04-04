using CineWaifu.Abstractions;
using CineWaifu.Abstractions.Enum;
using System.Text;

namespace CineWaifu.Domain.Builder
{
    public class AnsiFrameBuilder : IAnsiFrameBuilder
    {
        public AnsiFrameBuilder()
        {
            _imageBuilder = new StringBuilder();
        }

        public IAnsiFrameBuilder WithLetter(char letter, AnsiColor fgColor = AnsiColor.White, AnsiColor bgColor = AnsiColor.Black)
        {
            _imageBuilder.Append($"\x1b[38;5;{(int)fgColor}m\x1b[48;5;{(int)bgColor}m");
            _imageBuilder.Append(letter);
            _imageBuilder.Append(_defaultStyling);
            return this;
        }

        public IAnsiFrameBuilder WithNewLine()
        {
            _imageBuilder.Append(_newLineAnsi);
            _imageBuilder.Append(_defaultStyling);
            return this;
        }

        public string Build()
        {
            _imageBuilder.Append(_resetCursorToDefaultPosition);
            _imageBuilder.Append("\n");
            return _imageBuilder.ToString();
        }

        private readonly string _defaultStyling = "\x1b[0m";
        private readonly string _newLineAnsi = "\x1b[1E";
        private readonly string _resetCursorToDefaultPosition = "\x1b[H";
        private readonly StringBuilder _imageBuilder;
    }
}
