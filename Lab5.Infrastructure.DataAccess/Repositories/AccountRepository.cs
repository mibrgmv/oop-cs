using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities.Accounts;
using Lab5.Infrastructure.DataAccess.DataAccessExceptions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddAccount(int number, int userId, string password)
    {
        if (FindAccount(number) != null)
            throw new CollisionException("Account Number Collision");
        const string sql = """
                           INSERT INTO accounts (number, balance, user_id, password)
                           VALUES (@number, @balance, @user_id, @password);
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("balance", 0);
        command.Parameters.AddWithValue("user_id", userId);
        command.Parameters.AddWithValue("password", password);
        command.ExecuteNonQuery();
    }

    public void DeleteAccount(int number, int userId, string password)
    {
        if (FindAccount(number) == null)
            throw new NonexistentContentException("Cannot Delete Nonexistent Account");
        const string sql = """
                           DELETE FROM accounts
                           WHERE number = @number and user_id = @id and password = @password;
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("id", userId);
        command.Parameters.AddWithValue("password", password);
        command.ExecuteNonQuery();
    }

    public Account? FindAccount(int accountNumber)
    {
        const string sql = """
                           SELECT number, balance, user_id, password
                           FROM accounts
                           WHERE number = @accountNumber;
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("accountNumber", accountNumber);
        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read()
            ? new Account(
                number: reader.GetInt32(0),
                balance: reader.GetInt64(1),
                userId: reader.GetInt32(2),
                password: reader.GetString(3))
            : null;
    }

    public void ChangeAccountBalance(int accountNumber, long amount, string type)
    {
        const string sql = """
                           update accounts
                           SET balance = @amount
                           WHERE number = @accountNumber;
                           """;
        AddOperation(accountNumber, type, amount);
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("accountNumber", accountNumber);
        command.ExecuteNonQuery();
    }

    public IEnumerable<string> GetOperationHistory(int accountNumber)
    {
        if (FindAccount(accountNumber) == null)
            throw new NonexistentContentException("Cannot Show History Of Nonexistent Account");
        const string sql = """
                           select account_number, type, balance
                           from operations
                           where account_number = @number
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("number", accountNumber);
        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return
                reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetInt32(2);
        }
    }

    private void AddOperation(int accountNumber, string type, long amount)
    {
        const string sql = """
                           INSERT INTO operations (account_number, type, balance)
                           VALUES (@id, @type, @amount);
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", accountNumber);
        command.Parameters.AddWithValue("type", type);
        command.Parameters.AddWithValue("amount", amount);
        command.ExecuteNonQuery();
    }
}