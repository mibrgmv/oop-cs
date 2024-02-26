using Lab1.Source.Actor.Deflectors.DeflectorClasses;
using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Engines.WarpEngines;
using Lab1.Source.Actor.Toughness.ToughnessClasses;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;

namespace Lab1.Source.Actor.Spaceships.ShipTypes;

public class SpaceshipStella : Spaceship
{
    public SpaceshipStella()
        : base(
            new ImpulseEngineClassC(),
            new WarpEngineOmega(),
            new DeflectorClassOne(),
            new ToughnessClassOne(),
            WeightDimensionalCharacteristic.Low,
            false)
    { }

    public SpaceshipStella(bool photonic)
        : base(
            new ImpulseEngineClassC(),
            new WarpEngineOmega(),
            new DeflectorClassOne(photonic),
            new ToughnessClassOne(),
            WeightDimensionalCharacteristic.Low,
            false)
    { }
}