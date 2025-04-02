namespace CineWaifu.Domain.Model
{
    public class AnsiProcessorOptions
    {
        public string AsciiBrightnessTresholds { get; set; } = " .:-=+*#%@";
        public int Threads { get; set; } = 4;
    }
}
