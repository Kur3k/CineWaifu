using Cocona;
using System.Diagnostics;

namespace CineWaifu.Application.Commands
{
    public class DownloadCommand
    {
        [Command("download", Description = "Downloads and preprocesses video for ansi frame generation.")]
        public void Download([Option("url", ['u'], Description = "Video location ex. YouTube video (all yt-dlp sources)")] string url, 
                             [Option("output-filename", ['o'], Description = "Output filename.")] string outputFilename,
                             [Option("fps", ['f'], Description = "Fps limit.")] int fpsLimit = 24,
                             [Option("width", ['w'], Description = "Width of output video.")] int width = 100,
                             [Option("height", ['h'], Description = "Height of output video.")] int height = 30)
        {
            try
            {
                outputFilename = outputFilename.EndsWith(".mp4") ? outputFilename : $"{outputFilename}.mp4";

                string tempFilename = $"{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}";

                Process process = new Process();
                process.StartInfo.FileName = "./External/yt-dlp.exe";
                process.StartInfo.Arguments = $"{url} -o {tempFilename}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();

                string[] files = Directory.GetFiles("./", $"{tempFilename}.*");
                string filename = files.First();

                process = new Process();
                process.StartInfo.FileName = "./External/ffmpeg.exe";
                process.StartInfo.Arguments = $"-i {filename} -vf scale={width}:{height} -an -r {fpsLimit} {outputFilename}";
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();

                File.Delete(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
    }
}
