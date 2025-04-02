using CineWaifu.Abstractions.Enum;
using CineWaifu.Domain.Model;

namespace CineWaifu.Domain
{
    public static class AnsiColorMap
    {
        public static readonly Dictionary<AnsiForegroundColor, RgbColor> ForegroundColors = new Dictionary<AnsiForegroundColor, RgbColor>()
        {
            { AnsiForegroundColor.Black, new RgbColor(0, 0, 0) },
            { AnsiForegroundColor.Red, new RgbColor(205, 0, 0) },
            { AnsiForegroundColor.Green, new RgbColor(0, 205, 0) },
            { AnsiForegroundColor.Yellow, new RgbColor(205, 205, 0) },
            { AnsiForegroundColor.Blue, new RgbColor(0, 0, 205) },
            { AnsiForegroundColor.Magenta, new RgbColor(205, 0, 205) },
            { AnsiForegroundColor.Cyan, new RgbColor(0, 205, 205) },
            { AnsiForegroundColor.White, new RgbColor(229, 229, 229) },
            { AnsiForegroundColor.Gray, new RgbColor(127, 127, 127) },
            { AnsiForegroundColor.BrightRed, new RgbColor(255, 85, 85) },
            { AnsiForegroundColor.BrightGreen, new RgbColor(85, 255, 85) },
            { AnsiForegroundColor.BrightYellow, new RgbColor(255, 255, 85) },
            { AnsiForegroundColor.BrightBlue, new RgbColor(85, 85, 255) },
            { AnsiForegroundColor.BrightMagenta, new RgbColor(255, 85, 255) },
            { AnsiForegroundColor.BrightCyan, new RgbColor(85, 255, 255) },
            { AnsiForegroundColor.BrightWhite, new RgbColor(255, 255, 255) },
        };

        public static readonly Dictionary<AnsiBackgroundColor, RgbColor> BackgroundColors = new Dictionary<AnsiBackgroundColor, RgbColor>()
        {
            { AnsiBackgroundColor.Black, new RgbColor(0, 0, 0) },
            { AnsiBackgroundColor.Red, new RgbColor(205, 0, 0) },
            { AnsiBackgroundColor.Green, new RgbColor(0, 205, 0) },
            { AnsiBackgroundColor.Yellow, new RgbColor(205, 205, 0) },
            { AnsiBackgroundColor.Blue, new RgbColor(0, 0, 205) },
            { AnsiBackgroundColor.Magenta, new RgbColor(205, 0, 205) },
            { AnsiBackgroundColor.Cyan, new RgbColor(0, 205, 205) },
            { AnsiBackgroundColor.White, new RgbColor(229, 229, 229) },
            { AnsiBackgroundColor.Gray, new RgbColor(127, 127, 127) },
            { AnsiBackgroundColor.BrightRed, new RgbColor(255, 85, 85) },
            { AnsiBackgroundColor.BrightGreen, new RgbColor(85, 255, 85) },
            { AnsiBackgroundColor.BrightYellow, new RgbColor(255, 255, 85) },
            { AnsiBackgroundColor.BrightBlue, new RgbColor(85, 85, 255) },
            { AnsiBackgroundColor.BrightMagenta, new RgbColor(255, 85, 255) },
            { AnsiBackgroundColor.BrightCyan, new RgbColor(85, 255, 255) },
            { AnsiBackgroundColor.BrightWhite, new RgbColor(255, 255, 255) },
        };

    }
}
