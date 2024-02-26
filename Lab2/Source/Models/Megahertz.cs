namespace Lab2.Source.Models;

public class Megahertz
{
    public Megahertz(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Megahertz Value Cannot Be Negative");
        Value = value;
    }

    public int Value { get; }
}
