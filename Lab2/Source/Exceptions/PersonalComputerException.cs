namespace Lab2.Source.Exceptions;

public class PersonalComputerException : Exception
{
    public PersonalComputerException()
    { }

    public PersonalComputerException(string message)
        : base(message)
    { }

    public PersonalComputerException(string message, Exception innerException)
        : base(message, innerException)
    { }
}