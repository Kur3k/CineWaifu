using Cocona;
using System.Diagnostics;

namespace CineWaifu.Application.Commands
{
    public class PreprocessCommand
    {
        [Command("preprocess", Description = "Preprocesses video for ansi frame generation.")]
        public void Preprocess([Option("input-file-location", ['i'], Description = "Input video file.")] string inputFileLocation,
                               [Option("output-filename", ['o'], Description = "Output filename.")] string outputFilename,
                               [Option("fps", ['f'], Description = "Fps limit.")] int fpsLimit = 24,
                               [Option("width", ['w'], Description = "Width of output video.")] int width = 100,
                               [Option("height", ['h'], Description = "Height of output video.")] int height = 30)
        {
            try
            {
                outputFilename = outputFilename.EndsWith(".mp4") ? outputFilename : $"{outputFilename}.mp4";

                Process process = new Process();
                process.StartInfo.FileName = "./External/ffmpeg.exe";
                process.StartInfo.Arguments = $"-i {inputFileLocation} -vf scale={width}:{height} -an -r {fpsLimit} {outputFilename}";
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
    }
}
