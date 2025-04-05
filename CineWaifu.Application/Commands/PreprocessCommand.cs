using CineWaifu.Application.Abstraction;
using Cocona;

namespace CineWaifu.Application.Commands
{
    public class PreprocessCommand
    {
        public PreprocessCommand()
        {
            _processRunner = new ProcessRunner();
        }

        [Command("preprocess", Description = "Preprocesses video for ansi frame generation.")]
        public async Task Preprocess([Option("input-file-location", ['i'], Description = "Input video file.")] string inputFileLocation,
                               [Option("output-filename", ['o'], Description = "Output filename.")] string outputFilename,
                               [Option("fps", ['f'], Description = "Fps limit.")] int fpsLimit = 24,
                               [Option("width", ['w'], Description = "Width of output video.")] int width = 100,
                               [Option("height", ['h'], Description = "Height of output video.")] int height = 30)
        {
            try
            {
                outputFilename = outputFilename.EndsWith(".mp4") ? outputFilename : $"{outputFilename}.mp4";
                await _processRunner.RunProcessAsync("./External/yt-dlp.exe", $"-i {inputFileLocation} -vf scale={width}:{height} -an -r {fpsLimit} {outputFilename}");
                Console.WriteLine($"File has been processed.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }

        private readonly IProcessRunner _processRunner;
    }
}
