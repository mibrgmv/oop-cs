namespace Lab4.Source.Models;

public class ConsoleCommand
{
    public ConsoleCommand(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Invalid Console Command Value");
        Value = value;
    }

    public string Value { get; }
}