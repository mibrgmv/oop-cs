namespace Lab4.Source.Exceptions.FileSystemExceptions;

public class NonexistentFileException : FileSystemException
{
    public NonexistentFileException()
    {
    }

    public NonexistentFileException(string message)
        : base(message)
    {
    }

    public NonexistentFileException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}