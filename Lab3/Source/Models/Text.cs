namespace Lab3.Source.Models;

public class Text
{
    public Text(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Invalid Text");
        Value = value;
    }

    public string Value { get; }
}