using CineWaifu.Abstractions;
using CineWaifu.Domain;
using CineWaifu.Domain.Exceptions;
using CineWaifu.Domain.Processor;

namespace CineWaifu
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int width = 110;
            int height = 30;
            string outputAnsiFile = "output.ans";
            string inputVideoFile = "Resources/badapple.mp4";

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            FileInfo fileInfo = new FileInfo(outputAnsiFile);
            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                try
                {
                    IAnsiProcessor processor = new AnsiProcessor(options => { options.AsciiBrightnessTresholds = ".:-=+*#%@WGZ"; });
                    Console.WriteLine("Processing video to ANSI frames...");
                    processor.SaveProcessedVideoToAnsiFramesFile(outputAnsiFile, inputVideoFile);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("Video file not found.");
                }
                catch (InvalidFileException e)
                {
                    Console.WriteLine("Invalid video file extension.");
                }
                catch (InvalidFileDataTypeException e)
                {
                    Console.WriteLine("Provided file isn't actually a video.");
                }
            }

            try
            {
                ICineWaifuRunner runner = new CineWaifuRunner(outputAnsiFile);
                runner?.Run();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Ansi file not found.");
            }
        }
    }
}
