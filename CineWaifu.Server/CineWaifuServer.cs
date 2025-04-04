using System.Net.Sockets;
using System.Net;
using K4os.Compression.LZ4.Streams;
using System.Text;

namespace CineWaifu.Server
{
    public class CineWaifuServer
    {
        public CineWaifuServer(string ansiFileLocation, int port)
        {
            _port = port;
            _ansiFileLocation = ansiFileLocation;
        }

        public void Run()
        {
            string ipAddress = "127.0.0.1";

            TcpListener server = new TcpListener(IPAddress.Parse(ipAddress), _port);

            try
            {
                server.Start();
                Console.WriteLine($"Server listening on {ipAddress}:{_port}...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint!).Address.ToString();
                    Console.WriteLine($"Client {clientIP} connected.");

                    NetworkStream stream = client.GetStream();

                    try
                    {
                        using (var uncompressed = LZ4Stream.Decode(File.OpenRead(_ansiFileLocation)))
                        {
                            using (StreamReader reader = new StreamReader(uncompressed))
                            {
                                while (!reader.EndOfStream)
                                {
                                    byte[] decodedFrame = Encoding.UTF8.GetBytes(reader.ReadLine()!);
                                    stream.Write(decodedFrame);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Client exception: " + ex.Message);
                    }
                    finally
                    {
                        client.Close();
                        Console.WriteLine($"Client {clientIP} disconnected.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private readonly int _port;
        private readonly string _ansiFileLocation;
    }
}