using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines;

public abstract class ImpulseEngine : Engine
{
    protected ImpulseEngine(Speed speed, Velocity velocity, FuelConsumption fuelConsumption)
        : base(speed, velocity, fuelConsumption)
    { }
    public int FuelForStartup { get; protected init; }
}