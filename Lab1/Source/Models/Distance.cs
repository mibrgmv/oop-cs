namespace Lab1.Source.Models;

public class Distance
{
    public Distance(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Distance Must Be Greater Than Zero");
        Value = value;
    }

    public double Value { get; }
}