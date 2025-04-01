
using CineWaifu.Abstractions;
using CineWaifu.Domain;
using CineWaifu.Domain.Processor;

namespace CineWaifu
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int width = 160;
            int height = 40;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            IAnsiProcessor processor = new AnsiProcessor(options => { options.AsciiBrightnessTresholds = ".:-=+*#%@WGZ"; });
            
            Console.WriteLine("Processing video to ANSI frames...");
            processor.SaveProcessedVideoToAnsiFramesFile("output.ans", "Resources/badapple.mp4");

            ICineWaifuRunner runner = new CineWaifuRunner("output.ans");
            runner?.Run();
        }
    }
}
