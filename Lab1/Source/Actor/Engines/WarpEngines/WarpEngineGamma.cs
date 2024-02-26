using Lab1.Source.Models;

namespace Lab1.Source.Actor.Engines.WarpEngines;

public class WarpEngineGamma : WarpEngine
{
    private const int WarpEngineGammaSpeed = 0;
    private const int WarpEngineGammaVelocity = 0;
    private const int WarpEngineGammaFuelConsumption = 5;
    private const int WarpEngineGammaRange = 500;
    public WarpEngineGamma()
        : base(
            new Speed(WarpEngineGammaSpeed),
            new Velocity(WarpEngineGammaVelocity),
            new FuelConsumption(WarpEngineGammaFuelConsumption))
    {
        Range = WarpEngineGammaRange;
    }

    public override double CalculateFuelForRoute(Distance distance)
    {
        if (distance is null)
            throw new ArgumentException("Distance Must Be Greater Than 0");
        double jumps = Math.Ceiling(distance.Value / FuelConsumption.Value);
        return FuelConsumption.Value * jumps * Math.Log(jumps);
    }
}