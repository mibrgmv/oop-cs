namespace Lab1.Source.Exceptions.IsNullExceptions;

public class ShipIsNullException : IsNullException
{
    public ShipIsNullException()
    { }
    public ShipIsNullException(string message)
        : base(message)
    { }
    public ShipIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}