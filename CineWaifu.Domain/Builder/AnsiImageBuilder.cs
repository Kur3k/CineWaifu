using CineWaifu.Abstractions;
using CineWaifu.Abstractions.Enum;
using System.Text;

namespace CineWaifu.Domain.Builder
{
    public class AnsiImageBuilder : IAnsiImageBuilder
    {
        public AnsiImageBuilder()
        {
            _imageBuilder = new StringBuilder();
        }

        public IAnsiImageBuilder WithLetter(char letter, AnsiForegroundColor fgColor = AnsiForegroundColor.White, AnsiBackgroundColor bgColor = AnsiBackgroundColor.Black)
        {
            _imageBuilder.Append($"\x1b[{(int)fgColor};{(int)bgColor}m");
            _imageBuilder.Append(letter);
            _imageBuilder.Append(_defaultStyling);
            return this;
        }

        public IAnsiImageBuilder WithNewLine()
        {
            _imageBuilder.Append(_newLineAnsi);
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
