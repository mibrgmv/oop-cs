namespace Lab5.Application.Contracts.Banking;

public interface IBankingService
{
    public void Login(string username, string password);

    public void PutMoney(int accountNumber, int amount, string password);

    public void WithdrawMoney(int accountNumber, int amount, string password);

    public long CheckBalance(int accountNumber, string password);
}