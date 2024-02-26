namespace Lab2.Source.Models;

public class Gigabyte
{
    public Gigabyte(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Gigabyte Value Cannot Be Negative");
        Value = value;
    }

    public int Value { get; }
}
