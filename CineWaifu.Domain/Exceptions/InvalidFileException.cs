namespace CineWaifu.Domain.Exceptions
{
    public class InvalidFileException : Exception
    {
        public InvalidFileException() : base("Invalid file extension") { }
    }
}
