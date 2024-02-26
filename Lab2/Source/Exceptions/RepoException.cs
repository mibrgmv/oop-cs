namespace Lab2.Source.Exceptions;

public class RepoException : Exception
{
    public RepoException()
    { }

    public RepoException(string message)
        : base(message)
    { }

    public RepoException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
