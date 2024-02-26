using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Filling.Obstacles;

namespace Lab1.Source.Filling.Environments;

public abstract class Environment
{
    private readonly List<Obstacle> _obstacles;
    protected Environment()
    {
        _obstacles = new List<Obstacle>();
    }

    public IReadOnlyCollection<Obstacle> Obstacles => _obstacles;
    public void AddObstacle(Obstacle obstacle)
    {
        if (obstacle is null)
            throw new ObstacleIsNullException("Obstacle Cannot Be NULL");
        _obstacles.Add(obstacle);
    }
}