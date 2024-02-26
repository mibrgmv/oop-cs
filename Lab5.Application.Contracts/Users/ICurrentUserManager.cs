using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Contracts.Users;

public interface ICurrentUserManager
{
    public User? User { get; }
    public void SetUser(User user);
}