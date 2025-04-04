using CineWaifu.Abstractions;
using CineWaifu.Domain;

namespace CineWaifu.Application.Commands
{
    public class RunCommand
    {
        public void Run(string inputAnsiFileLocation)
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