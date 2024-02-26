using Itmo.ObjectOrientedProgramming.Lab1.Source.Filling.Environments.Types;
using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Actor.Spaceships.ShipTypes;
using Lab1.Source.Filling.Environments;
using Lab1.Source.Models;
using Path = Lab1.Source.Filling.Path.Path;

namespace Lab1.Source.Services;

public class Selector : ISelector
{
    public Path PathSelector(int distance, EnvironmentNames environmentName)
    {
        return environmentName switch
        {
            EnvironmentNames.Space => new Path(new Distance(distance), new Space()),
            EnvironmentNames.NebulaOfIncreasedDepthsOfSpace => new Path(new Distance(distance), new NebulaOfIncreasedDepthsOfSpace()),
            EnvironmentNames.NebulaOfNitrineParticles => new Path(new Distance(distance), new NebulaOfNitrineParticles()),
            _ => throw new ArgumentException("Unexpected Environment Name"),
        };
    }

    public Spaceship ShipSelector(SpaceshipNames name, bool photonic = false)
    {
        return name switch
        {
            SpaceshipNames.Avgur => new SpaceshipAvgur(photonic),
            SpaceshipNames.Meridian => new SpaceshipMeridian(photonic),
            SpaceshipNames.Shuttle => new SpaceshipShuttle(),
            SpaceshipNames.Stella => new SpaceshipStella(photonic),
            SpaceshipNames.Vaklas => new SpaceshipVaklas(photonic),
            _ => throw new ArgumentException("Unexpected Ship Name"),
        };
    }
}