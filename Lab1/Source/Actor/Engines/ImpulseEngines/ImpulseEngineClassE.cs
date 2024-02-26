using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines.ImpulseEngines;

public class ImpulseEngineClassE : ImpulseEngine
{
    private const int ImpulseEngineClassESpeed = 0;
    private const int ImpulseEngineClassEVelocity = 3;
    private const int ImpulseEngineClassEFuelConsumption = 20;
    private const int ImpulseEngineClassECostOfStartup = 10;
    public ImpulseEngineClassE()
        : base(
            new Speed(ImpulseEngineClassESpeed),
            new Velocity(ImpulseEngineClassEVelocity),
            new FuelConsumption(ImpulseEngineClassEFuelConsumption))
    {
        FuelForStartup = ImpulseEngineClassECostOfStartup;
    }

    public override double CalculateFuelForRoute(Distance distance)
    {
        if (distance is null)
            throw new ArgumentException("Distance Cannot Be NULL");
        double time = Math.Sqrt(2 * distance.Value / Velocity.Value);
        return FuelForStartup + (FuelConsumption.Value * time);
    }
}