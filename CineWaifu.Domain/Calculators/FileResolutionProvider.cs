using CineWaifu.Abstractions;
using OpenCvSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CineWaifu.Domain.Calculators
{
    public class VideoResolutionProvider : IVideoResolutionProvider
    {
        public (int width, int height) GetResolution(string videoLocation)
        {
            using (VideoCapture capture = new VideoCapture(videoLocation))
            using (var frame = new Mat())
            {
                capture.Read(frame);
                using (var image = Image.Load<Rgba32>(frame.ToMemoryStream()))
                {
                    return (image.Width, image.Height);
                }
            }
        }
    }
}
