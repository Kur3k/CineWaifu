using CineWaifu.Domain.Exceptions;
using FileTypeChecker;

namespace CineWaifu.Domain.Utils
{
    public static class Guards
    {
        public static void AgainstNonExistingOrEmptyFile(FileInfo fileInfo)
        {
            if (!fileInfo.Exists || fileInfo.Length == 0)
                throw new FileNotFoundException();
        }

        public static void AgainstNonVideoFileExtension(FileInfo fileInfo)
        {
            if (!_videoExtensions.Any(ve => ve == fileInfo.Extension))
                throw new InvalidFileException();
        }

        public static void AgainstInvalidFileType(FileInfo fileInfo)
        {
            using (var fileStream = File.OpenRead(fileInfo.FullName))
            {
                var isRecognizableType = FileTypeValidator.IsTypeRecognizable(fileStream);

                if (!isRecognizableType)
                    throw new InvalidFileException();
            }
        }
        
        private static readonly string[] _videoExtensions = { ".mp4", ".avi", ".mkv", ".mov", ".flv", ".wmv", ".mpg", ".mpeg", ".webm" };
    }
}
