using CineWaifu.Abstractions;
using CineWaifu.Domain.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CineWaifu.Domain.Model
{
    public class ImageSharpAdapter : IImage
    {
        public ImageSharpAdapter(Image<Rgba32> image)
        {
            _image = image;
        }

        public int Width => _image.Width;

        public int Height => _image.Height;

        public IColor GetPixel(int x, int y)
        {
            return _image[x, y].ToRgbColor();
        }

        public void Save(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(int x, int y, IColor color)
        {
            _image[x, y] = new Rgba32((byte)color.Components[0], (byte)color.Components[1], (byte)color.Components[2]);
        }

        private readonly Image<Rgba32> _image;
    }
}
