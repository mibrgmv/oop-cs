namespace Lab1.Source.Exceptions.RouteServiceExceptions;

public class ExistingPathException : RouteServiceException
{
    public ExistingPathException()
    { }

    public ExistingPathException(string message)
        : base(message)
    { }

    public ExistingPathException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}