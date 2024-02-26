using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Services.ClassResult;
using Path = Lab1.Source.Filling.Path.Path;

namespace Lab1.Source.Services;

public interface IRoute
{
    public void AddPath(Path path);
    public Result CheckShip(Spaceship ship);
    public Spaceship? CompareShips(Spaceship shipOne, Spaceship shipTwo);
}