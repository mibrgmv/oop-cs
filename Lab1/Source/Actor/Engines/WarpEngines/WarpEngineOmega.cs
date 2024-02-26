using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines.WarpEngines;

public class WarpEngineOmega : WarpEngine
{
    private const int WarpEngineOmegaSpeed = 0;
    private const int WarpEngineOmegaVelocity = 0;
    private const int WarpEngineOmegaFuelConsumption = 5;
    private const int WarpEngineOmegaRange = 1000;
    public WarpEngineOmega()
        : base(
            new Speed(WarpEngineOmegaSpeed),
            new Velocity(WarpEngineOmegaVelocity),
            new FuelConsumption(WarpEngineOmegaFuelConsumption))
    {
        Range = WarpEngineOmegaRange;
    }

    public override double CalculateFuelForRoute(Distance distance)
    {
        if (distance is null)
            throw new ArgumentException("Distance Cannot Be NULL");
        double jumps = Math.Ceiling(distance.Value / FuelConsumption.Value);
        return FuelConsumption.Value * jumps * jumps;
    }
}