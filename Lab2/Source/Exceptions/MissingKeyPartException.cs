namespace Lab2.Source.Exceptions;

public class MissingKeyPartException : PersonalComputerException
{
    public MissingKeyPartException()
    { }

    public MissingKeyPartException(string message)
        : base(message)
    { }

    public MissingKeyPartException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}