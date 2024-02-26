namespace Lab1.Source.Exceptions.RouteServiceExceptions;

public class RouteServiceException : Exception
{
    public RouteServiceException()
    { }

    public RouteServiceException(string message)
        : base(message)
    { }

    public RouteServiceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}