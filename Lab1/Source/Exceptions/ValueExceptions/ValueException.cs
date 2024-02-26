namespace Lab1.Source.Exceptions.ValueExceptions;

public class ValueException : Exception
{
    public ValueException()
    { }

    public ValueException(string message)
        : base(message)
    { }

    public ValueException(string message, Exception innerException)
        : base(message, innerException)
    { }
}