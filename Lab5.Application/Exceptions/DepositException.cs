namespace Lab5.Application.Exceptions;

public class DepositException : Exception
{
    public DepositException(string message)
        : base(message)
    { }

    public DepositException()
    { }

    public DepositException(string message, Exception innerException)
        : base(message, innerException)
    { }
}