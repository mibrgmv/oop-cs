namespace Lab5.Domain.Entities.Accounts;

public class Account
{
    public Account(int number, long balance, int userId, string password)
    {
        Number = number;
        Balance = balance;
        UserId = userId;
        Password = password;
    }

    public int Number { get; }
    public long Balance { get; private set; }
    public int UserId { get; }
    public string Password { get; private set; }

    public void ChangePassword(string newPassword)
    {
        Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
    }

    public void ChangeAmount(long amount)
    {
        Balance += amount;
    }
}