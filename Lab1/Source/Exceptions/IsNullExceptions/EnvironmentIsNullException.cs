namespace Lab1.Source.Exceptions.IsNullExceptions;

public class EnvironmentIsNullException : IsNullException
{
    public EnvironmentIsNullException()
    { }

    public EnvironmentIsNullException(string message)
        : base(message)
    { }

    public EnvironmentIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}