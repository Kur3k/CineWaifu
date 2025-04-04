using CineWaifu.Application.Commands;
using Cocona;

namespace CineWaifu
{
    public class Program
    {
        static void Main(string[] args)
        {
            int width = 100;
            int height = 30;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            var builder = CoconaApp.CreateBuilder();
            var app = builder.Build();

            app.AddCommands<DownloadCommand>();
            app.AddCommands<GenerateCommand>();
            app.AddCommands<RunCommand>();
            app.AddCommands<ServerCommand>();

            app.Run();
        }
    }
}
