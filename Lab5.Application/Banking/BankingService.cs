using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Banking;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Exceptions;
using Lab5.Domain.Entities.Accounts;
using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Banking;

public class BankingService : IBankingService
{
    private ICurrentUserManager _currentUserManager;
    private IUserService _userService;
    private IAccountService _accountService;

    public BankingService(IUserService userService, IAccountService accountService, ICurrentUserManager currentUserManager)
    {
        _userService = userService;
        _accountService = accountService;
        _currentUserManager = currentUserManager;
    }

    public void Login(string username, string password)
    {
        User? user = _userService.FindUser(username);
        if (user == null)
            throw new InvalidLoginException("No Such User Found");
        if (user.Password != password)
            throw new PasswordException("Incorrect User Password");

        _currentUserManager.SetUser(user);
    }

    public void PutMoney(int accountNumber, int amount, string password)
    {
        if (_currentUserManager.User != null)
        {
            Account? account = _accountService.FindAccount(accountNumber);
            if (account == null || _currentUserManager.User.Id != account.UserId)
                throw new AccountUserRegistrationException("No Such Account Registered To User");
            if (account.Password != password)
                throw new PasswordException("Incorrect Account Password");
            if (amount < 0)
                throw new DepositException("Cannot Put Negative Amount");

            _accountService.ChangeBalance(accountNumber, account.Balance + amount, "put");
            return;
        }

        throw new NoUserLogonException("No User Logon");
    }

    public void WithdrawMoney(int accountNumber, int amount, string password)
    {
        if (_currentUserManager.User != null)
        {
            Account? account = _accountService.FindAccount(accountNumber);
            if (account == null || _currentUserManager.User.Id != account.UserId)
                throw new AccountUserRegistrationException("No Such Account Registered To User");
            if (account.Password != password)
                throw new PasswordException("Incorrect Account Password");
            if (account.Balance < amount)
                throw new DepositException("Cannot Withdraw. Insufficient Balance");
            if (amount < 0)
                throw new DepositException("Cannot Withdraw Negative Amount");

            _accountService.ChangeBalance(accountNumber, account.Balance - amount, "withdraw");
            return;
        }

        throw new NoUserLogonException("No User Logon");
    }

    public long CheckBalance(int accountNumber, string password)
    {
        if (_currentUserManager.User != null)
        {
            Account? account = _accountService.FindAccount(accountNumber);
            if (account == null || _currentUserManager.User.Id != account.UserId)
                throw new AccountUserRegistrationException("No Such Account Registered To User");
            if (account.Password != password)
                throw new PasswordException("Incorrect Account Password");

            return account.Balance;
        }

        throw new NoUserLogonException("No User Logon");
    }
}