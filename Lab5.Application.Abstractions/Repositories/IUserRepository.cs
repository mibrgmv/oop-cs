using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    void AddUser(int userId, string username, string password);

    void DeleteUser(int userId, string username, string password);

    User? FindUser(string username);

    User? FindUser(int userId);
}