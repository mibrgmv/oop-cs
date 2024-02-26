namespace Lab2.Source.Models;

public class Socket
{
    public Socket(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Socket Cannot Be Null Or Empty String");
        Value = value;
    }

    public string Value { get; }

    public override bool Equals(object? obj)
    {
        return obj is Socket && Value == ((Socket)obj).Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}