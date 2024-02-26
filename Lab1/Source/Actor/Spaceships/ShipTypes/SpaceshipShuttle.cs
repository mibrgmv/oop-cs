using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Toughness.ToughnessClasses;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;

namespace Lab1.Source.Actor.Spaceships.ShipTypes;

public class SpaceshipShuttle : Spaceship
{
    public SpaceshipShuttle()
        : base(
            new ImpulseEngineClassC(),
            null,
            null,
            new ToughnessClassOne(),
            WeightDimensionalCharacteristic.Low,
            false)
    { }
}