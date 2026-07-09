using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.Cli.Abstractions;

namespace UrbanMart.Cli.Commands.Stack
{
    public class UpCommand : AsyncCommand
    {
        private readonly IProcessRunner _processRunner;

        public UpCommand(IProcessRunner processRunner)
        {
            _processRunner = processRunner;
        }

        //  public override async Task<int> ExecuteAsync(
        //CommandContext context)
        //  {
        //      AnsiConsole.MarkupLine(
        //          "[yellow]Starting UrbanMart infrastructure...[/]");

        //      var exitCode = await _processRunner.RunAsync(
        //          "docker",
        //          "compose up -d");

        //      if (exitCode != 0)
        //      {
        //          AnsiConsole.MarkupLine(
        //              "[red]Failed to start UrbanMart infrastructure.[/]");

        //          return exitCode;
        //      }

        //      AnsiConsole.MarkupLine(
        //          "[green]UrbanMart infrastructure started successfully.[/]");

        //      return 0;
        //  }

        protected override Task<int> ExecuteAsync(CommandContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}