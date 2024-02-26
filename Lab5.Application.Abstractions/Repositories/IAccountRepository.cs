using Lab5.Domain.Entities.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    public void AddAccount(int number, int userId, string password);

    public void DeleteAccount(int number, int userId, string password);

    public Account? FindAccount(int accountNumber);

    public void ChangeAccountBalance(int accountNumber, long amount, string type);

    public IEnumerable<string> GetOperationHistory(int accountNumber);
}