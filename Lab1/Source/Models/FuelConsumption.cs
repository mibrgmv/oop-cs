namespace Lab1.Source.Models;

public class FuelConsumption
{
    public FuelConsumption(double fuelConsumption)
    {
        if (fuelConsumption < 0)
            throw new ArgumentException("Fuel Consumption Must Be Greater Than 0");
        Value = fuelConsumption;
    }

    public double Value { get; }
}