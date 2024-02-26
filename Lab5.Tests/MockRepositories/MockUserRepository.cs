using System.Collections.ObjectModel;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities.Users;

namespace Lab5.Tests.MockRepositories;

public class MockUserRepository : IUserRepository
{
    private Collection<User> _users = new Collection<User>();

    public void AddUser(int userId, string username, string password)
    {
        _users.Add(new User(userId, username, password));
    }

    public void DeleteUser(int userId, string username, string password)
    {
        User? user = _users.SingleOrDefault(x => x.Id == userId && x.Username == username && x.Password == password);
        if (user != null)
            _users.Remove(user);
    }

    public User? FindUser(string username)
    {
        return _users.SingleOrDefault(x => x.Username == username);
    }

    public User? FindUser(int userId)
    {
        return _users.SingleOrDefault(x => x.Id == userId);
    }
}