using Lab1.Source.Actor.Deflectors.DeflectorClasses;
using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Engines.WarpEngines;
using Lab1.Source.Actor.Toughness.ToughnessClasses;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;

namespace Lab1.Source.Actor.Spaceships.ShipTypes;

public class SpaceshipAvgur : Spaceship
{
    public SpaceshipAvgur()
        : base(
            new ImpulseEngineClassE(),
            new WarpEngineAlpha(),
            new DeflectorClassThree(),
            new ToughnessClassThree(),
            WeightDimensionalCharacteristic.High,
            false)
    { }

    public SpaceshipAvgur(bool photonic)
        : base(
            new ImpulseEngineClassE(),
            new WarpEngineAlpha(),
            new DeflectorClassThree(photonic),
            new ToughnessClassThree(),
            WeightDimensionalCharacteristic.High,
            false)
    { }
}
