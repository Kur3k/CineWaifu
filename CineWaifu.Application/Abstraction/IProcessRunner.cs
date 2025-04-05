namespace CineWaifu.Application.Abstraction
{
    public interface IProcessRunner
    {
        public Task RunProcessAsync(string processLocation, string arguments);
    }
}
