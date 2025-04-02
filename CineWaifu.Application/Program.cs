
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
            string outputAnsiFile = "output.ans";
            string inputVideoFile = "Resources/badapple.mp4";

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            if (!File.Exists(outputAnsiFile))
            {
                IAnsiProcessor processor = new AnsiProcessor(options => { options.AsciiBrightnessTresholds = ".:-=+*#%@WGZ"; });
            
                Console.WriteLine("Processing video to ANSI frames...");
                processor.SaveProcessedVideoToAnsiFramesFile(outputAnsiFile, inputVideoFile);
            }

            ICineWaifuRunner runner = new CineWaifuRunner(outputAnsiFile);
            runner?.Run();
        }
    }
}
