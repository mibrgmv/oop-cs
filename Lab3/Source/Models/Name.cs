using Lab3.Source.Exceptions.ModelsExceptions;

namespace Lab3.Source.Models;

public class Name
{
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Invalid Text");
        if (value.Contains(' ', StringComparison.Ordinal))
            throw new UnwantedWhitespaceException("Name Must Not Contain Whitespaces");
        Value = value;
    }

    public string Value { get; }
}