namespace Lab4.Source.Exceptions.FileSystemExceptions;

public class OccupiedDestinationException : FileSystemException
{
    public OccupiedDestinationException()
    { }

    public OccupiedDestinationException(string message)
        : base(message)
    { }

    public OccupiedDestinationException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}