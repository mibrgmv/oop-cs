using Lab5.Domain.Entities.Accounts;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    public void ChangeBalance(int accountNumber, long amount, string type);

    public Account? FindAccount(int accountNumber);
}