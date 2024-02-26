namespace Lab2.Source.Models;

public class Watt
{
    public Watt(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Wattage Value Cannot Be Negative");
        Value = value;
    }

    public int Value { get; }
}
