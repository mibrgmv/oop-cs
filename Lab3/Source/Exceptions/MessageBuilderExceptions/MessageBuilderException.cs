namespace Lab3.Source.Exceptions.MessageBuilderExceptions;

public class MessageBuilderException : Exception
{
    public MessageBuilderException()
    { }

    public MessageBuilderException(string message)
        : base(message)
    { }

    public MessageBuilderException(string message, Exception innerException)
        : base(message, innerException)
    { }
}