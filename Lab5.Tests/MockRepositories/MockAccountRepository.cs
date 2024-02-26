using System.Collections.ObjectModel;
using System.Globalization;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities.Accounts;

namespace Lab5.Tests.MockRepositories;

public class MockAccountRepository : IAccountRepository
{
    private Collection<Account> _accounts = new();
    private Collection<string> _operations = new();

    public void AddAccount(int number, int userId, string password)
    {
        _accounts.Add(new Account(number, 0, userId, password));
    }

    public void DeleteAccount(int number, int userId, string password)
    {
        Account? account =
            _accounts.SingleOrDefault(x => x.Number == number && x.UserId == userId && x.Password == password);
        if (account != null)
            _accounts.Remove(account);
    }

    public Account? FindAccount(int accountNumber)
    {
        return _accounts.SingleOrDefault(x => x.Number == accountNumber);
    }

    public void ChangeAccountBalance(int accountNumber, long amount, string type)
    {
        Account? account = FindAccount(accountNumber);
        _operations.Add(accountNumber.ToString(CultureInfo.InvariantCulture));
        account?.ChangeAmount(amount);
    }

    public IEnumerable<string> GetOperationHistory(int accountNumber)
    {
        Account? account = FindAccount(accountNumber);
        foreach (string number in _operations)
        {
            if (number == accountNumber.ToString(CultureInfo.InvariantCulture))
                yield return number;
        }
    }
}