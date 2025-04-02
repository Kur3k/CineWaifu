using CineWaifu.Abstractions;
using CineWaifu.Domain.Builder;
using CineWaifu.Domain.Model;
using CineWaifu.Domain.Utils;
using OpenCvSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CineWaifu.Domain.Processor
{
    public class AnsiProcessor : IAnsiProcessor
    {
        public AnsiProcessor(Action<AnsiProcessorOptions>? options = null)
        {
            options?.Invoke(ansiProcessorOptions);
        }

        public void SaveProcessedVideoToAnsiFramesFile(string ansiFramesFile, string videoName)
        {
            List<string> processedFrames = ProcessAllVideoFramesToAnsi(videoName);
            using (StreamWriter writer = new StreamWriter(ansiFramesFile))
            {
                foreach (string frame in processedFrames)
                {
                    writer.WriteLine(frame);
                }
            }
        }

        private List<string> ProcessAllVideoFramesToAnsi(string videoName)
        {
            List<string> processedFrames = new();
            using (VideoCapture capture = new VideoCapture(videoName))
            {
                int totalFrames = capture.FrameCount;

                for (int i = 0; i < totalFrames; i++)
                {
                    processedFrames.Add(ProcessVideoFrameToAnsi(capture));
                }
            }
            return processedFrames;
        }

        private string ProcessVideoFrameToAnsi(VideoCapture capture)
        {
            MemoryStream stream;
            using (var frame = new Mat())
            {
                capture.Read(frame);
                stream = frame.ToMemoryStream();
            }
            return CreateSingleAnsiFrame(stream);

        }

        private string CreateSingleAnsiFrame(MemoryStream imageStream)
        {
            IAnsiImageBuilder builder = new AnsiImageBuilder();
            using (var image = Image.Load<Rgba32>(imageStream))
            {
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Rgba32 pixelColor = image[x, y];
                        CreateAsciiWrappedInAnsi(new RgbColor(pixelColor.R, pixelColor.G, pixelColor.B), ansiProcessorOptions.AsciiBrightnessTresholds, builder);
                    }
                    builder.WithNewLine();
                }
            }
            return builder.Build();
        }

        private void CreateAsciiWrappedInAnsi(RgbColor pixelColor, string asciiBrightnessTresholds, IAnsiImageBuilder builder)
        {
            RgbColor color = pixelColor;
            double brightness = Brightness(color);
            int idx = (int)Math.Round(brightness / 255 * (ansiProcessorOptions.AsciiBrightnessTresholds.Length - 1));
            builder.WithLetter(ansiProcessorOptions.AsciiBrightnessTresholds[idx], AnsiUtils.ClosestColor(GetReverseColor(color), AnsiColorMap.ForegroundColors),
                                            AnsiUtils.ClosestColor(color, AnsiColorMap.BackgroundColors));
        }

        private AnsiProcessorOptions ansiProcessorOptions = new();

        private RgbColor GetReverseColor(RgbColor color) => new RgbColor(255 - color.R, 255 - color.G, 255 - color.B);

        private double Brightness(RgbColor color) => (int)(Math.Sqrt(
            color.R * color.R * .241 +
            color.G * color.G * .691 +
            color.B * color.B * .068));
    }
}
