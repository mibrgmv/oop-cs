namespace Lab2.Source.Models;

public class DdrStandard
{
    public DdrStandard(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("DDR Standard Cannot Be Null Or Empty String");
        Value = value;
    }

    public string Value { get; }
}
