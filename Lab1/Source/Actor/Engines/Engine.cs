using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines;

public abstract class Engine
{
    protected Engine(Speed speed, Velocity velocity, FuelConsumption fuelConsumption)
    {
        Speed = speed;
        Velocity = velocity;
        FuelConsumption = fuelConsumption;
    }

    public Speed Speed { get; protected set; }
    public Velocity Velocity { get; protected set; }
    public FuelConsumption FuelConsumption { get; protected init; }
    public abstract double CalculateFuelForRoute(Distance distance);
}