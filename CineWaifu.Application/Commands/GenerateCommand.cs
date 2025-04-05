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
                             [Option("input-video-location", ['i'], Description = "Input video file for generating ansi.")] string inputVideoLocation,
                             [Option("edge-detection-enabled", ['e'], Description ="Edge detection flag.")] bool edgeDetectionEnabled = true,
                             [Option("edge-detection-treshold", ['d'], Description = "Edge detection treshold.")] int edgeDetectionTreshold = 128,
                             [Option("ascii-brigthtness-characters", ['c'], Description = "ASCII characters from the least visible to the most.")] string asciiBrightnessCharacters = ".:-=+*#%@WGZ",
                             [Option("threads", ['t'], Description = "Threads used to process video to ANSI frames.")] int threads = 4)
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
                    options.EdgeDetectionEnabled = edgeDetectionEnabled;
                    options.EdgeDetectionThreshold = edgeDetectionTreshold;
                    options.AsciiBrightnessTresholds = asciiBrightnessCharacters;
                    options.Threads = threads;
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
