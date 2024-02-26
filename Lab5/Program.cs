using Lab5.Application.Accounts;
using Lab5.Application.Banking;
using Lab5.Application.Users;
using Lab5.Infrastructure.DataAccess.Repositories;
using Lab5.Presentation.ConsoleInterface;
    
namespace Lab5;

public static class Program
{
    public static void Main()
    {
        const string connectionString = "Host=localhost;Port=5432;Username=mibrgmv;Password=postgres;Database=postgres";
        string systemPassword = "1234";
        var userRepository = new UserRepository(connectionString);
        var accountRepository = new AccountRepository(connectionString);
        var bankingService = new BankingService(
            new UserService(userRepository),
            new AccountService(accountRepository),
            new CurrentUserManager());
        var userInterface = new UserInterface(systemPassword, bankingService, userRepository, accountRepository);
        userInterface.Run();
    }
}