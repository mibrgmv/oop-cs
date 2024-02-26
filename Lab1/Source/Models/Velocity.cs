namespace Lab1.Source.Models;

public class Velocity
{
    public Velocity(double velocity)
    {
        if (velocity < 0)
            throw new ArgumentException("Velocity Must Be Greater Than 0");
        Value = velocity;
    }

    public double Value { get; }
}