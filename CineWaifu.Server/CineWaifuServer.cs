using System.Net;
using System.Net.Sockets;

namespace CineWaifu.Server
{
    public class CineWaifuServer
    {
        public CineWaifuServer(string ansiFileLocation, bool isDirectory, int port)
        {
            _port = port;
            _ansiFileLocation = ansiFileLocation;
            _isDirectory = isDirectory;
        }

        public void Run()
        {
            string ipAddress = "127.0.0.1";

            TcpListener server = new TcpListener(IPAddress.Parse(ipAddress), _port);
            Random random = new Random();
            
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
                        if (_isDirectory)
                        {
                            if (!Directory.Exists(_ansiFileLocation))
                                throw new Exception($"Directory {_ansiFileLocation} does not exist.");

                            string[] files = Directory.GetFiles(_ansiFileLocation, "*.ansi");

                            int randomFileIndex = random.Next(0, files.Length);
                            new AnsiFileServer(files[randomFileIndex], stream).Serve();
                        } 
                        else
                        {
                            new AnsiFileServer(_ansiFileLocation, stream).Serve();
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
        private readonly bool _isDirectory;
    }
}