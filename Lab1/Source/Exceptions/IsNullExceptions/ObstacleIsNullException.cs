namespace Lab1.Source.Exceptions.IsNullExceptions;

public class ObstacleIsNullException : IsNullException
{
    public ObstacleIsNullException()
    { }

    public ObstacleIsNullException(string message)
        : base(message)
    { }

    public ObstacleIsNullException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}