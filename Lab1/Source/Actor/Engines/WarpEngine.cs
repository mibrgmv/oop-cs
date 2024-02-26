using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines;

public abstract class WarpEngine : Engine
{
     protected WarpEngine(Speed speed, Velocity velocity, FuelConsumption fuelConsumption)
          : base(speed, velocity, fuelConsumption)
     { }
     public int Range { get; protected init; }
}