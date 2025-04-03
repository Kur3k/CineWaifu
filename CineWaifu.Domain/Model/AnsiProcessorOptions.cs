using CineWaifu.Abstractions;
using CineWaifu.Domain.Shader;

namespace CineWaifu.Domain.Model
{
    public class AnsiProcessorOptions
    {
        public string AsciiBrightnessTresholds { get; set; } = " .:-=+*#%@";
        public int Threads { get; set; } = 4;
        public bool EdgeDetectionEnabled { get; set; } = true;
        public int EdgeDetectionThreshold { get; set; } = 128;
        public Func<IColor, int, RgbColor> ForegroundShader { get; set; } = AnsiShaders.Darker;
        public Func<IColor, int, RgbColor> BackgroundShader { get; set; } = AnsiShaders.Default;
    }
}
