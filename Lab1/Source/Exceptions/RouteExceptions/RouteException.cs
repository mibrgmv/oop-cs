namespace Lab1.Source.Exceptions.RouteExceptions;

public class RouteException : Exception
{
    public RouteException()
    { }
    public RouteException(string message)
        : base(message)
    { }

    public RouteException(string message, Exception innerException)
        : base(message, innerException)
    { }
}