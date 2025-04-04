using CineWaifu.Abstractions;
using CineWaifu.Domain.Builder;
using CineWaifu.Domain.Calculators;
using CineWaifu.Domain.Extensions;
using CineWaifu.Domain.Model;
using CineWaifu.Domain.Model.Color;
using CineWaifu.Domain.Utils;
using K4os.Compression.LZ4.Streams;
using OpenCvSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Concurrent;
using System.Text;

namespace CineWaifu.Domain.Processor
{
    public class AnsiProcessor : IAnsiProcessor
    {
        public AnsiProcessor(Action<AnsiProcessorOptions>? options = null)
        {
            options?.Invoke(_ansiProcessorOptions);
            _ansiColorMapper = new RgbAnsiColorMapper(new EuclidianDistanceProvider());
            _gradientCalculator = new GradientCalculator();
        }

        object lockObj = new object();

        public void SaveProcessedVideoToAnsiFramesFile(string ansiFramesFile, string inputVideoLocation)
        {
            FileInfo inputVideoFileInfo = new FileInfo(inputVideoLocation);
            Guards.AgainstNonExistingOrEmptyFile(inputVideoFileInfo);
            Guards.AgainstNonVideoFileExtension(inputVideoFileInfo);
            Guards.AgainstInvalidFileType(inputVideoFileInfo);

            List<string> processedFrames = ProcessAllVideoFramesToAnsi(inputVideoLocation);

            using (MemoryStream writer = new MemoryStream())
            {
                foreach (string frame in processedFrames)
                {
                    byte[] frameBytes = Encoding.UTF8.GetBytes(frame + "\n");
                    writer.Write(frameBytes);
                }

                writer.Seek(0, SeekOrigin.Begin);

                using (var compressionStream = LZ4Stream.Encode(File.Create($"{ansiFramesFile}{FileExtensions.ANSI}")))
                {
                    writer.CopyTo(compressionStream);
                }
            }
        }

        private List<string> ProcessAllVideoFramesToAnsi(string inputVideoLocation)
        {
            ConcurrentQueue<(int index, string content)> processedFramesQueue = new ConcurrentQueue<(int, string)>();
            using (VideoCapture capture = new VideoCapture(inputVideoLocation))
            {
                int totalFrames = capture.FrameCount;

                Parallel.For(0, totalFrames, new ParallelOptions { MaxDegreeOfParallelism = _ansiProcessorOptions.Threads }, i =>
                {
                    processedFramesQueue.Enqueue(ProcessVideoFrameToAnsi(capture));
                });

            }
            return processedFramesQueue.OrderBy(x => x.index).Select(x => x.content).ToList();
        }

        private (int position, string content) ProcessVideoFrameToAnsi(VideoCapture capture)
        {   
            MemoryStream stream;
            using (var frame = new Mat())
            {
                lock (lockObj)
                {
                    capture.Read(frame);
                }
                stream = frame.ToMemoryStream();
                return (capture.PosFrames, CreateSingleAnsiFrame(stream));
            }
        }

        private string CreateSingleAnsiFrame(MemoryStream imageStream)
        {
            IAnsiFrameBuilder builder = new AnsiFrameBuilder();
            using (var image = Image.Load<Rgba32>(imageStream))
            {
                IImage? sobel = null;
                if (_ansiProcessorOptions.EdgeDetectionEnabled)
                {
                   sobel = new ImageSharpAdapter(image.ToSobelImage());
                }

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        IColor color = image[x, y].ToRgbColor();
                        double brightness = color.GetBrightness(new RgbBrightnessCalculator());
                        int idx = (int)Math.Round(brightness / 255 * (_ansiProcessorOptions.AsciiBrightnessTresholds.Length - 1));
                        char selectedLetter = _ansiProcessorOptions.AsciiBrightnessTresholds[idx];

                        if (_ansiProcessorOptions.EdgeDetectionEnabled)
                        {
                            float gx = 0;
                            float gy = 0;

                            if (y > 0 && y < image.Height - 1 && x > 0 && x < image.Width - 1)
                            {
                                gx = _gradientCalculator.Calculate(new ImageSharpAdapter(image), x, y, SobelKernels.GxKernel);
                                gy = _gradientCalculator.Calculate(new ImageSharpAdapter(image), x, y, SobelKernels.GyKernel);
                            }

                            int magnitude = (int)Math.Sqrt(Math.Pow(gx, 2) + Math.Pow(gy, 2));
                            int angle = (int)(Math.Atan2(gy, gx) * 180 / Math.PI);

                            if (magnitude > _ansiProcessorOptions.EdgeDetectionThreshold)
                            {
                                selectedLetter = AngleCharacterMap.Map(angle);
                            }
                        }

                        builder.WithLetter(selectedLetter,
                                           _ansiColorMapper.GetClosestAnsiColor(_ansiProcessorOptions.ForegroundShader(color, 50)),
                                           _ansiColorMapper.GetClosestAnsiColor(_ansiProcessorOptions.BackgroundShader(color, 100)));
                    }
                    builder.WithNewLine();
                }
            }
            return builder.Build();
        }

        private readonly IAnsiColorMapper<RgbColor> _ansiColorMapper;
        private readonly IGradientCalculator _gradientCalculator;
        private AnsiProcessorOptions _ansiProcessorOptions = new();
    }
}
