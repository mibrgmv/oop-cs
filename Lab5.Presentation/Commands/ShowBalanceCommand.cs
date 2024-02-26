using System.Globalization;
using Lab5.Application.Contracts.Banking;
using Spectre.Console;

namespace Lab5.Presentation.Commands;

public class ShowBalanceCommand : Command
{
    private IBankingService _bankingService;

    public ShowBalanceCommand(IBankingService bankingService)
    {
        _bankingService = bankingService;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["balance", _, _])
        {
            AnsiConsole.MarkupInterpolated(CultureInfo.InvariantCulture, $"[deepskyblue1]{_bankingService.CheckBalance(Convert.ToInt32(split[1], null), split[2])}[/]\n");
        }
        else
        {
            base.Execute(command);
        }
    }
}