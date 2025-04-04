using K4os.Compression.LZ4.Streams;
using System.Net.Sockets;
using System.Text;

namespace CineWaifu.Server
{
    public class AnsiFileServer
    {
        public AnsiFileServer(string ansiFileLocation, NetworkStream stream)
        {
            _ansiFileLocation = ansiFileLocation;
            _stream = stream;
        }

        public void Serve()
        {
            using (var uncompressed = LZ4Stream.Decode(File.OpenRead(_ansiFileLocation)))
            {
                using (StreamReader reader = new StreamReader(uncompressed))
                {
                    while (!reader.EndOfStream)
                    {
                        byte[] decodedFrame = Encoding.UTF8.GetBytes(reader.ReadLine()!);
                        _stream.Write(decodedFrame);
                    }
                }
            }
        }

        private readonly string _ansiFileLocation;
        private readonly NetworkStream _stream;
    }
}
