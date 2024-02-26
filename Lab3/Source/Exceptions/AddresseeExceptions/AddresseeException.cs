namespace Lab3.Source.Exceptions.AddresseeExceptions;

public class AddresseeException : Exception
{
    public AddresseeException()
    {
    }

    public AddresseeException(string message)
        : base(message)
    { }

    public AddresseeException(string message, Exception innerException)
        : base(message, innerException)
    { }
}