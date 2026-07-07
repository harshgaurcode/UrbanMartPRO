using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.Cli.Abstractions;

namespace UrbanMart.Cli.Infrastructure
{
    public class ProcessRunner : IProcessRunner
    {
        public async Task<int> RunAsync(
        string fileName,
        string arguments,
        CancellationToken cancellationToken = default)
        {
            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false
            };

            process.Start();

            await process.WaitForExitAsync(cancellationToken);

            return process.ExitCode;
        }
    }
}