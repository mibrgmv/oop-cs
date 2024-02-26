namespace Lab1.Source.Exceptions.SwitchExceptions;

public class SwitchException : Exception
{
    public SwitchException()
    { }

    public SwitchException(string message)
        : base(message)
    { }

    public SwitchException(string message, Exception innerException)
        : base(message, innerException)
    { }
}