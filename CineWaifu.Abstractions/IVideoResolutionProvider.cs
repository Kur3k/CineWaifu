namespace CineWaifu.Abstractions
{
    public interface IVideoResolutionProvider
    {
        public (int width, int height) GetResolution(string videoLocation);
    }
}
