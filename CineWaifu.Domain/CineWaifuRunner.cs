using CineWaifu.Abstractions;

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

            using (StreamReader reader = new StreamReader(_ansiFileLocation))
            {
                while (!reader.EndOfStream)
                {
                    Console.Write(reader.ReadLine());
                }
                
            }
        }

        private readonly string _ansiFileLocation;
    }
}
