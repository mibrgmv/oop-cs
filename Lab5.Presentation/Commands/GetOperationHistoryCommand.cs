using System.Globalization;
using Lab5.Application.Abstractions.Repositories;
using Spectre.Console;

namespace Lab5.Presentation.Commands;

public class GetOperationHistoryCommand : Command
{
    private IAccountRepository _accountRepository;

    public GetOperationHistoryCommand(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["history", _])
        {
            AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[green]{string.Join("\n", _accountRepository.GetOperationHistory(Convert.ToInt32(split[1], null)))}[/]");
        }
        else
        {
            base.Execute(command);
        }
    }
}