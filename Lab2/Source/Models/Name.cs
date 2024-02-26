namespace Lab2.Source.Models;

public class Name
{
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Name Cannot Be Null Or Empty String");
        Value = value;
    }

    public string Value { get; }
}
