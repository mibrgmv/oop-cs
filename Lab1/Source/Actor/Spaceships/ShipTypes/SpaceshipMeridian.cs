using Lab1.Source.Actor.Deflectors.DeflectorClasses;
using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Toughness.ToughnessClasses;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;

namespace Lab1.Source.Actor.Spaceships.ShipTypes;

public class SpaceshipMeridian : Spaceship
{
    public SpaceshipMeridian()
        : base(
            new ImpulseEngineClassE(),
            null,
            new DeflectorClassTwo(),
            new ToughnessClassTwo(),
            WeightDimensionalCharacteristic.Medium,
            true)
    { }

    public SpaceshipMeridian(bool photonic)
        : base(
            new ImpulseEngineClassE(),
            null,
            new DeflectorClassTwo(photonic),
            new ToughnessClassTwo(),
            WeightDimensionalCharacteristic.Medium,
            true)
    { }
}