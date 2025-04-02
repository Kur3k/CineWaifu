using CineWaifu.Domain.Shader;

namespace CineWaifu.Domain.Model
{
    public class AnsiProcessorOptions
    {
        public string AsciiBrightnessTresholds { get; set; } = " .:-=+*#%@";
        public int Threads { get; set; } = 4;
        public Func<RgbColor, int, RgbColor> ForegroundShader { get; set; } = AnsiShaders.Darker;
        public Func<RgbColor, int, RgbColor> BackgroundShader { get; set; } = AnsiShaders.Default;
    }
}
