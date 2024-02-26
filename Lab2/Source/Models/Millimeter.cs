namespace Lab2.Source.Models;

public class Millimeter
{
    public Millimeter(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Length/Height/Width Cannot Be Negative");
        Value = value;
    }

    public int Value { get; }
}
