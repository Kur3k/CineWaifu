namespace CineWaifu.Abstractions
{
    public interface IAnsiProcessor 
    {
        public void SaveProcessedVideoToAnsiFramesFile(string ansiFramesFile, string inputVideoLocation);
    }
}
