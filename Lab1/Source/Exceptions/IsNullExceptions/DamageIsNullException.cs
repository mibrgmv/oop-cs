namespace Lab1.Source.Exceptions.IsNullExceptions;

public class DamageIsNullException : IsNullException
{
    public DamageIsNullException()
    { }
    public DamageIsNullException(string message)
        : base(message)
    { }
    public DamageIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}