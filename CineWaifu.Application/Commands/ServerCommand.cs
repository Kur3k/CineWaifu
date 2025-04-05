using Cocona;
using CineWaifu.Server;

namespace CineWaifu.Application.Commands
{
    public class ServerCommand
    {
        [Command("serve", Description = "Serve ANSI file or directory over tcp.")]
        public void Serve([Option("input-ansi-file-location", ['i'], Description = "Location of file or directory (directory displays random ansi on connection.)")] string inputAnsiFileLocation,
                          [Option("port", ['p'], Description = "Tcp server port")] int port)
        {
            new CineWaifuServer(inputAnsiFileLocation, Directory.Exists(inputAnsiFileLocation), port).Run();
        }
    }
}