namespace Lab1.Source.Exceptions.SwitchExceptions;

public class SwitchArgumentOutOfRangeException : SwitchException
{
    public SwitchArgumentOutOfRangeException()
    { }

    public SwitchArgumentOutOfRangeException(string message)
        : base(message)
    { }

    public SwitchArgumentOutOfRangeException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}
