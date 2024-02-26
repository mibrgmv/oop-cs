namespace Lab1.Source.Exceptions.IsNullExceptions;

public class IsNullException : Exception
{
    protected IsNullException()
    { }
    protected IsNullException(string message)
        : base(message)
    { }
    protected IsNullException(string message, Exception innerException)
        : base(message, innerException)
    { }
}