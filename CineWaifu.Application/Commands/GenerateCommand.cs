using CineWaifu.Abstractions;
using CineWaifu.Domain.Exceptions;
using CineWaifu.Domain.Processor;
using CineWaifu.Domain.Utils;

namespace CineWaifu.Application.Commands
{
    public class GenerateCommand
    {
        public void Generate(string outputAnsiFilename, string inputVideoLocation)
        {
            FileInfo fileInfo = new FileInfo(outputAnsiFilename);
            if (fileInfo.Exists) 
            {
                Console.WriteLine("File already exists.");
                return;
            }

            try
            {
                IAnsiProcessor processor = new AnsiProcessor(options => {
                    options.EdgeDetectionEnabled = true;
                    options.EdgeDetectionThreshold = 128;
                    options.AsciiBrightnessTresholds = ".:-=+*#%@WGZ";
                    options.Threads = 16;
                });

                Console.WriteLine("Processing video to ANSI frames...");
                processor.SaveProcessedVideoToAnsiFramesFile(outputAnsiFilename, inputVideoLocation);
                Console.WriteLine($"Processing {outputAnsiFilename}{FileExtensions.ANSI} completed.");
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
    }
}
