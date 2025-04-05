using Cocona;
using CineWaifu.Application.Abstraction;

namespace CineWaifu.Application.Commands
{
    public class DownloadCommand
    {

        public DownloadCommand() {
            _processRunner = new ProcessRunner();
        }

        [Command("download", Description = "Downloads and preprocesses video for ansi frame generation.")]
        public async Task Download([Option("url", ['u'], Description = "Video location ex. YouTube video (all yt-dlp sources)")] string url, 
                             [Option("output-filename", ['o'], Description = "Output filename.")] string outputFilename,
                             [Option("fps", ['f'], Description = "Fps limit.")] int fpsLimit = 24,
                             [Option("width", ['w'], Description = "Width of output video.")] int width = 100,
                             [Option("height", ['h'], Description = "Height of output video.")] int height = 30)
        {
            try
            {
                outputFilename = outputFilename.EndsWith(".mp4") ? outputFilename : $"{outputFilename}.mp4";
                string tempFilename = $"{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}";
                await _processRunner.RunProcessAsync("./External/yt-dlp.exe", $"{url} -o {tempFilename}");
                string[] files = Directory.GetFiles("./", $"{tempFilename}.*");
                string tempFilenameExtracted = files.First();
                await _processRunner.RunProcessAsync("./External/ffmpeg.exe", $"-y -i {tempFilenameExtracted} -vf scale={width}:{height} -an -r {fpsLimit} {outputFilename}");
                File.Delete(tempFilenameExtracted);
                Console.WriteLine($"Temporary file {tempFilenameExtracted} removed.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }

        private readonly IProcessRunner _processRunner;
    }
}
