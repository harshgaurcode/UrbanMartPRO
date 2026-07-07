namespace UrbanMart.Cli.Abstractions
{
    public interface IProcessRunner
    {
        Task<int> RunAsync(
            string fileName,
            string arguments,
            CancellationToken cancellationToken = default);
    }
}