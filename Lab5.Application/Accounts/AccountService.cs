using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Domain.Entities.Accounts;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void ChangeBalance(int accountNumber, long amount, string type)
    {
        _accountRepository.ChangeAccountBalance(accountNumber, amount, type);
    }

    public Account? FindAccount(int accountNumber)
    {
        return _accountRepository.FindAccount(accountNumber);
    }
}