namespace Lab1.Source.Models;

public class Speed
{
    public Speed(double speed)
    {
        if (speed < 0)
            throw new ArgumentException("Speed Must Be Greater Than 0");
        Value = speed;
    }

    public double Value { get; }
}