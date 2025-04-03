namespace CineWaifu.Abstractions
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }
        IColor GetPixel(int x, int y);
        void SetPixel(int x, int y, IColor color);
        void Save(string filePath);
    }
}
