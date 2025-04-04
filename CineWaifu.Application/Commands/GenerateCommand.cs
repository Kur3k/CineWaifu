using CineWaifu.Abstractions;
using CineWaifu.Domain.Exceptions;
using CineWaifu.Domain.Processor;
using CineWaifu.Domain.Utils;
using Cocona;

namespace CineWaifu.Application.Commands
{
    public class GenerateCommand
    {
        [Command("generate", Description = "Generate ANSI file from video.")]
        public void Generate([Option("output-ansi-filename", ['o'], Description = "Output name of ansi file." )] string outputAnsiFilename, 
                             [Option("input-video-location", ['i'], Description = "Input video file for generating ansi.")] string inputVideoLocation)
        {
            outputAnsiFilename = outputAnsiFilename.EndsWith(FileExtensions.ANSI) ? outputAnsiFilename : $"{outputAnsiFilename}{FileExtensions.ANSI}";

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
                Console.WriteLine($"Processing {outputAnsiFilename} completed.");
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
