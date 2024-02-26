using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities.Users;
using Lab5.Infrastructure.DataAccess.DataAccessExceptions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddUser(int userId, string username, string password)
    {
        if (FindUser(username) != null)
            throw new CollisionException("Username Collision");
        if (FindUser(userId) != null)
            throw new CollisionException("User Id Collision");
        const string sql = """
                             INSERT INTO users (id, username, password)
                             VALUES (@id, @username, @password);
                             """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", userId);
        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("password", password);
        command.ExecuteNonQuery();
    }

    public void DeleteUser(int userId, string username, string password)
    {
        if (FindUser(username) == null)
            throw new NonexistentContentException("Cannot Delete Nonexistent User");
        const string sql = """
                           DELETE FROM users
                           WHERE id = @id and username = @username and password = @password;
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", userId);
        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("password", password);
        command.ExecuteNonQuery();
    }

    public User? FindUser(string username)
    {
        const string sql = """
                            SELECT id, username, password 
                            FROM users
                            WHERE username = :username;
                            """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("username", username);
        using NpgsqlDataReader reader = command.ExecuteReader();
        return reader.Read()
            ? new User(
                Id: reader.GetInt32(0),
                Username: reader.GetString(1),
                Password: reader.GetString(2))
            : null;
    }

    public User? FindUser(int userId)
    {
        const string sql = """
                           SELECT id, username, password
                           FROM users
                           WHERE id = @id;
                           """;
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", userId);
        using NpgsqlDataReader reader = command.ExecuteReader();
        return reader.Read()
            ? new User(
                Id: reader.GetInt32(0),
                Username: reader.GetString(1),
                Password: reader.GetString(2))
            : null;
    }
}