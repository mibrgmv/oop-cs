namespace Lab5.Infrastructure.DataAccess.DataAccessExceptions;

public class NonexistentContentException : Exception
{
    public NonexistentContentException()
    {
    }

    public NonexistentContentException(string message)
        : base(message)
    { }

    public NonexistentContentException(string message, Exception innerException)
        : base(message, innerException)
    { }
}