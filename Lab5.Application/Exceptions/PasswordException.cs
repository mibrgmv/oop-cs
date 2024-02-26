namespace Lab5.Application.Exceptions;

public class PasswordException : Exception
{
    public PasswordException()
    { }

    public PasswordException(string message)
        : base(message)
    { }

    public PasswordException(string message, Exception innerException)
        : base(message, innerException)
    { }
}