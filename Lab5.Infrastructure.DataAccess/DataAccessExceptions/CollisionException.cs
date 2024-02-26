namespace Lab5.Infrastructure.DataAccess.DataAccessExceptions;

public class CollisionException : Exception
{
    public CollisionException()
    {
    }

    public CollisionException(string message)
        : base(message)
    { }

    public CollisionException(string message, Exception innerException)
        : base(message, innerException)
    { }
}