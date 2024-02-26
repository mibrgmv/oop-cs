using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Filling.Environments;
using Path = Lab1.Source.Filling.Path.Path;

namespace Lab1.Source.Services;

public interface ISelector
{
    public Path PathSelector(int distance, EnvironmentNames environmentName);
    public Spaceship ShipSelector(SpaceshipNames name, bool photonic = false);
}