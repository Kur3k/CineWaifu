using CineWaifu.Abstractions;
using K4os.Compression.LZ4.Streams;

namespace CineWaifu.Domain
{
    public class CineWaifuRunner : ICineWaifuRunner
    {
        public CineWaifuRunner(string ansiFileLocation)
        {
            _ansiFileLocation = ansiFileLocation;
        }

        public void Run()
        {
            using (var uncompressed = LZ4Stream.Decode(File.OpenRead(_ansiFileLocation)))
            {
                using (StreamReader reader = new StreamReader(uncompressed))
                {
                    string[] resolution = reader.ReadLine()!.Split(":");
                    int width = int.Parse(resolution[0]);
                    int height = int.Parse(resolution[1]);
                    Console.SetWindowSize(width, height);

                    while (!reader.EndOfStream)
                    {
                        Console.Write(reader.ReadLine());
                    }
                }
            }
        }

        private readonly string _ansiFileLocation;
    }
}
