using Lab5.Application.Contracts.Users;
using Lab5.Domain.Entities.Users;

namespace Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserManager
{
    public User? User { get; private set; }

    public void SetUser(User user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
    }
}