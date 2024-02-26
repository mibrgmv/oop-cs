using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? FindUser(string username)
    {
        return _userRepository.FindUser(username);
    }

    public User? FindUser(int userId)
    {
        return _userRepository.FindUser(userId);
    }
}