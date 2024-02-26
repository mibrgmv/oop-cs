using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Banking;
using Lab5.Presentation.Abstractions.ConsoleInterface;
using Lab5.Presentation.Commands;

namespace Lab5.Presentation.ConsoleInterface;

public class InputParser : IInputParser
{
    private AddUserCommand _addUserCommand;
    private PutMoneyCommand _userCommandHead;
    private LoginCommand _loginCommand;

    public InputParser(IBankingService bankingService, IUserRepository userRepository, IAccountRepository accountRepository)
    {
        _addUserCommand = new AddUserCommand(userRepository);
        _addUserCommand
            .SetNextCommand(new AddAccountCommand(accountRepository))
            .SetNextCommand(new DeleteUserCommand(userRepository))
            .SetNextCommand(new DeleteAccountCommand(accountRepository))
            .SetNextCommand(new GetOperationHistoryCommand(accountRepository));
        _userCommandHead = new PutMoneyCommand(bankingService);
        _userCommandHead
            .SetNextCommand(new WithdrawCommand(bankingService))
            .SetNextCommand(new ShowBalanceCommand(bankingService));
        _loginCommand = new LoginCommand(bankingService);
    }

    public void ParseAdminCommand(string command)
    {
        _addUserCommand.Execute(command);
    }

    public void ParseCustomerCommand(string command)
    {
        _userCommandHead.Execute(command);
    }

    public void ParseLoginCommand(string command)
    {
        _loginCommand.Execute(command);
    }
}