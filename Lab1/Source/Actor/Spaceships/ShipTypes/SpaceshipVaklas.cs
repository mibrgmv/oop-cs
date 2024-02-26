using Lab1.Source.Actor.Deflectors.DeflectorClasses;
using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Engines.WarpEngines;
using Lab1.Source.Actor.Toughness.ToughnessClasses;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;

namespace Lab1.Source.Actor.Spaceships.ShipTypes;

public class SpaceshipVaklas : Spaceship
{
    public SpaceshipVaklas()
        : base(
            new ImpulseEngineClassE(),
            new WarpEngineGamma(),
            new DeflectorClassOne(),
            new ToughnessClassTwo(),
            WeightDimensionalCharacteristic.Medium,
            false)
    { }

    public SpaceshipVaklas(bool photonic)
        : base(
            new ImpulseEngineClassE(),
            new WarpEngineGamma(),
            new DeflectorClassOne(photonic),
            new ToughnessClassTwo(),
            WeightDimensionalCharacteristic.Medium,
            false)
    { }
}