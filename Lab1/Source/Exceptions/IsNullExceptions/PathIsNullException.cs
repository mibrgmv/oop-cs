namespace Lab1.Source.Exceptions.IsNullExceptions;

public class PathIsNullException : IsNullException
{
    public PathIsNullException()
    { }

    public PathIsNullException(string message)
        : base(message)
    { }

    public PathIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}