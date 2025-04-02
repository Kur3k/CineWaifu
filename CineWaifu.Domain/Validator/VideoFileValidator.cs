namespace CineWaifu.Domain.Validator
{
    public static class VideoFileValidator
    {
        public static void ValidateVideoFile(string videoName)
        {
            FileInfo videoFileInfo = new FileInfo(videoName);
            Guards.AgainstNonExistingOrEmptyFile(videoFileInfo);
            Guards.AgainstNonVideoFileExtension(videoFileInfo);
            Guards.AgainstInvalidFileType(videoName);
        }
    }
}
