using CineWaifu.Abstractions;
using CineWaifu.Domain;
using Cocona;

namespace CineWaifu.Application.Commands
{
    public class RunCommand
    {
        [Command("run", Description = "Runs ANSI file.")]
        public void Run([Option("input-ansi-file-location", ['i'], Description = "Location of ansi file.")] string inputAnsiFileLocation)
        {
            try
            {
                ICineWaifuRunner runner = new CineWaifuRunner(inputAnsiFileLocation);
                runner?.Run();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Ansi file not found.");
            }
        }
    }
}