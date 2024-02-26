using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Presentation.Commands;

public class DeleteAccountCommand : Command
{
    private IAccountRepository _accountRepository;

    public DeleteAccountCommand(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["delete", "account", _, _, _])
        {
            _accountRepository.DeleteAccount(
                Convert.ToInt32(split[2], null),
                Convert.ToInt32(split[3], null),
                split[4]);
        }
        else
        {
            base.Execute(command);
        }
    }
}