namespace Lab5.Application.Exceptions;

public class AccountUserRegistrationException : Exception
{
    public AccountUserRegistrationException()
    { }

    public AccountUserRegistrationException(string message)
        : base(message)
    { }

    public AccountUserRegistrationException(string message, Exception innerException)
        : base(message, innerException)
    { }
}