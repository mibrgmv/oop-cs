namespace Lab1.Source.Exceptions.ValueExceptions;

public class NegativeValueException : ValueException
{
    public NegativeValueException()
    { }

    public NegativeValueException(string message)
        : base(message)
    { }

    public NegativeValueException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}