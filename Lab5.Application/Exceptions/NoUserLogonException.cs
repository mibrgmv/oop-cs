namespace Lab5.Application.Exceptions;

public class NoUserLogonException : Exception
{
    public NoUserLogonException()
    {
    }

    public NoUserLogonException(string message)
        : base(message)
    { }

    public NoUserLogonException(string message, Exception innerException)
        : base(message, innerException)
    { }
}