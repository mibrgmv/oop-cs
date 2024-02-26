using Lab5.Application.Accounts;
using Lab5.Application.Banking;
using Lab5.Application.Exceptions;
using Lab5.Application.Users;
using Lab5.Tests.MockRepositories;
using Xunit;

namespace Lab5.Tests.ApplicationTests;

public class ApplicationTests
{
    private MockUserRepository _userRepository = new();
    private MockAccountRepository _accountRepository = new();

    [Fact]
    public void AddUserTest()
    {
        _userRepository.AddUser(1, "Sasha", "password");
        Assert.True(_userRepository.FindUser("Sasha") != null);
    }

    [Fact]
    public void AddAccountTest()
    {
        _accountRepository.AddAccount(33, 1, "123");
        _accountRepository.AddAccount(87, 1, "password");
        Assert.True(_accountRepository.FindAccount(33) != null);
        Assert.True(_accountRepository.FindAccount(87) != null);
    }

    [Fact]
    public void PutMoneyTest()
    {
        var bankingService = new BankingService(
            new UserService(_userRepository), new AccountService(_accountRepository), new CurrentUserManager());

        _userRepository.AddUser(0, "test", "test");
        _accountRepository.AddAccount(0, 0, "test");
        bankingService.Login("test", "test");
        bankingService.PutMoney(0, 100, "test");

        Assert.True(_accountRepository.FindAccount(0) != null);
        Assert.True(_accountRepository.FindAccount(0)?.Balance == 100);
    }

    [Fact]
    public void WithdrawMoneyTest()
    {
        var bankingService = new BankingService(
            new UserService(_userRepository), new AccountService(_accountRepository), new CurrentUserManager());

        _userRepository.AddUser(0, "test", "test");
        _accountRepository.AddAccount(0, 0, "test");
        bankingService.Login("test", "test");

        Assert.True(_accountRepository.FindAccount(0) != null);
        DepositException messageException = Assert.Throws<DepositException>(()
            => bankingService.WithdrawMoney(0, 100, "test"));
        Assert.Equal("Cannot Withdraw. Insufficient Balance", messageException.Message);
    }
}