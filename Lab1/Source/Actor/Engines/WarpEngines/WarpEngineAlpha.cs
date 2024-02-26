using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines.WarpEngines;

public class WarpEngineAlpha : WarpEngine
{
    private const int WarpEngineAlphaSpeed = 0;
    private const int WarpEngineAlphaVelocity = 0;
    private const int WarpEngineAlphaFuelConsumption = 5;
    private const int WarpEngineAlphaRange = 250;
    public WarpEngineAlpha()
        : base(
            new Speed(WarpEngineAlphaSpeed),
            new Velocity(WarpEngineAlphaVelocity),
            new FuelConsumption(WarpEngineAlphaFuelConsumption))
    {
        Range = WarpEngineAlphaRange;
    }

    public override double CalculateFuelForRoute(Distance distance)
    {
        if (distance is null)
            throw new ArgumentException("Distance Cannot Be NULL");
        double jumps = Math.Ceiling(distance.Value / FuelConsumption.Value);
        return FuelConsumption.Value * jumps;
    }
}