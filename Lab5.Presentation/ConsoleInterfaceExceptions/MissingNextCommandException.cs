namespace Lab5.Presentation.ConsoleInterfaceExceptions;

public class MissingNextCommandException : Exception
{
    public MissingNextCommandException()
    { }

    public MissingNextCommandException(string message)
        : base(message)
    { }

    public MissingNextCommandException(string message, Exception innerException)
        : base(message, innerException)
    { }
}