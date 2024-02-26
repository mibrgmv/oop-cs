namespace Lab3.Source.Exceptions.ModelsExceptions;

public class UnwantedWhitespaceException : Exception
{
    public UnwantedWhitespaceException()
    { }

    public UnwantedWhitespaceException(string message)
        : base(message)
    { }

    public UnwantedWhitespaceException(string message, Exception innerException)
        : base(message, innerException)
    { }
}