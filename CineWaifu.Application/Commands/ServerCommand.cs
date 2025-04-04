using CineWaifu.Server;

namespace CineWaifu.Application.Commands
{
    public class ServerCommand
    {
        public void Serve(string inputAnsiFileLocation, int port)
        {
            new CineWaifuServer(inputAnsiFileLocation, port).Run();
        }
    }
}