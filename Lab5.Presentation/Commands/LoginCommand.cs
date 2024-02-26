using Lab5.Application.Contracts.Banking;

namespace Lab5.Presentation.Commands;

public class LoginCommand : Command
{
    private IBankingService _bankingService;

    public LoginCommand(IBankingService bankingService)
    {
        _bankingService = bankingService;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is [_, _])
        {
            _bankingService.Login(split[0], split[1]);
        }
        else
        {
            base.Execute(command);
        }
    }
}