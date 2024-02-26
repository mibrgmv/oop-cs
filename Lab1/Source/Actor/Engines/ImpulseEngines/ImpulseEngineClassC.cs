using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines.ImpulseEngines;

public class ImpulseEngineClassC : ImpulseEngine
{
    private const int ImpulseEngineClassCSpeed = 50;
    private const int ImpulseEngineClassCVelocity = 0;
    private const int ImpulseEngineClassCFuelConsumption = 5;
    private const int ImpulseEngineClassCCostOfStartup = 10;
    public ImpulseEngineClassC()
        : base(
            new Speed(ImpulseEngineClassCSpeed),
            new Velocity(ImpulseEngineClassCVelocity),
            new FuelConsumption(ImpulseEngineClassCFuelConsumption))
    {
        FuelForStartup = ImpulseEngineClassCCostOfStartup;
    }

    public override double CalculateFuelForRoute(Distance distance)
    {
        if (distance == null)
            throw new ArgumentException("Distance Cannot Be NULL");
        double time = distance.Value / Speed.Value;
        return FuelForStartup + (FuelConsumption.Value * time);
    }
}