using Itmo.ObjectOrientedProgramming.Lab1.Source.Filling.Environments.Types;
using Itmo.ObjectOrientedProgramming.Lab1.Source.Services.ClassResult.Results;
using Lab1.Source.Actor.Engines.ImpulseEngines;
using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Exceptions.RouteServiceExceptions;
using Lab1.Source.Filling.Obstacles;
using Lab1.Source.Services.ClassResult;
using Path = Lab1.Source.Filling.Path.Path;

namespace Lab1.Source.Services;

public class Route : IRoute
{
    private readonly List<Path> _paths;
    public Route()
    {
        _paths = new List<Path>();
    }

    private IReadOnlyCollection<Path> Paths => _paths;

    public void AddPath(Path path)
    {
        if (path is null)
            throw new PathIsNullException("Path Cannot Be NULL");
        if (Paths.Contains(path))
            throw new ExistingPathException("Cannot Add Already Present Path");
        _paths.Add(path);
    }

    public Result CheckShip(Spaceship ship)
    {
        double requiredFuel = 0;
        if (ship is null)
        {
            throw new ShipIsNullException("Ship Cannot Be NULL");
        }

        foreach (Path path in Paths)
        {
            foreach (Obstacle obstacle in path.Environment.Obstacles)
            {
                for (int i = 0; i < obstacle.Quantity; ++i)
                {
                    ship.TakeDamage(obstacle.Damage);
                    if (ship.Destroyed) return new Failure(ResultType.ShipDestroyed);
                    if (ship.IsCrewAlive is false) return new Failure(ResultType.CrewAnnihilated);
                }
            }

            switch (path.Environment)
            {
                case Space when ship.ImpulseEngine is null:
                    return new Failure(ResultType.ShipInsufficient);
                case Space:
                    requiredFuel += ship.ImpulseEngine.CalculateFuelForRoute(path.Distance);
                    break;
                case NebulaOfIncreasedDepthsOfSpace when ship.WarpEngine is null:
                    return new Failure(ResultType.ShipInsufficient);
                case NebulaOfIncreasedDepthsOfSpace when ship.WarpEngine.Range < path.Distance.Value:
                    return new Failure(ResultType.ShipLost);
                case NebulaOfIncreasedDepthsOfSpace:
                    requiredFuel += ship.WarpEngine.CalculateFuelForRoute(path.Distance);
                    break;
                case NebulaOfNitrineParticles when ship.ImpulseEngine is not ImpulseEngineClassE:
                    return new Failure(ResultType.ShipInsufficient);
                case NebulaOfNitrineParticles:
                    requiredFuel += ship.ImpulseEngine.CalculateFuelForRoute(path.Distance);
                    break;
            }
        }

        return new Success(ResultType.Success, requiredFuel);
    }

    public Spaceship? CompareShips(Spaceship shipOne, Spaceship shipTwo)
    {
        Result resOne = CheckShip(shipOne);
        Result resTwo = CheckShip(shipTwo);
        if (resOne is not Success) return resTwo is Success ? shipTwo : null;
        if (resTwo is Success)
            return resOne.RequiredFuel <= resTwo.RequiredFuel ? shipOne : shipTwo;

        return shipOne;
    }
}