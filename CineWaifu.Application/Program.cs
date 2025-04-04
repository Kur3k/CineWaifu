using CineWaifu.Application.Commands;
using Cocona;

namespace CineWaifu
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = CoconaApp.CreateBuilder();
            var app = builder.Build();

            app.AddCommands<DownloadCommand>();
            app.AddCommands<PreprocessCommand>();
            app.AddCommands<GenerateCommand>();
            app.AddCommands<RunCommand>();
            app.AddCommands<ServerCommand>();

            app.Run();
        }
    }
}
