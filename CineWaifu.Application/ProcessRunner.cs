using CineWaifu.Application.Abstraction;
using System.Diagnostics;

namespace CineWaifu.Application
{
    public class ProcessRunner : IProcessRunner
    {
        public async Task RunProcessAsync(string processLocation, string arguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = processLocation;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await Task.Run(process.WaitForExit);
            process.Close();
        }
    }
}
