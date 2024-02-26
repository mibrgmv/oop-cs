using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    public User? FindUser(string username);

    public User? FindUser(int userId);
}