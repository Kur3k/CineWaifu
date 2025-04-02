using CineWaifu.Domain.Shader;

namespace CineWaifu.Domain.Model
{
    public class AnsiProcessorOptions
    {
        public string AsciiBrightnessTresholds { get; set; } = " .:-=+*#%@";
        public int Threads { get; set; } = 4;
        public Func<RgbColor, int, RgbColor> CustomShade { get; set; } = AnsiCustomShaders.Darker;
    }
}
