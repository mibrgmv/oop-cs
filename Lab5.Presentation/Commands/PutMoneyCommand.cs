using Lab5.Application.Contracts.Banking;

namespace Lab5.Presentation.Commands;

public class PutMoneyCommand : Command
{
    private IBankingService _bankingService;

    public PutMoneyCommand(IBankingService bankingService)
    {
        _bankingService = bankingService;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["put", _, _, _])
        {
            _bankingService.PutMoney(
                Convert.ToInt32(split[1], null),
                Convert.ToInt32(split[3], null),
                split[2]);
        }
        else
        {
            base.Execute(command);
        }
    }
}