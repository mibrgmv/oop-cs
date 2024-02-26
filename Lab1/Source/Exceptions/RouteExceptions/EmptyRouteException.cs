namespace Lab1.Source.Exceptions.RouteExceptions;

public class EmptyRouteException : RouteException
{
    public EmptyRouteException()
    { }
    public EmptyRouteException(string message)
        : base(message)
    { }
    public EmptyRouteException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}