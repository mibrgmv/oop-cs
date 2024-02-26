using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Models;
using Environment = Lab1.Source.Filling.Environments.Environment;

namespace Lab1.Source.Filling.Path;

public class Path
{
    public Path(Distance distance, Environment environment)
    {
        if (environment is null)
            throw new EnvironmentIsNullException("Environment Cannot Be BULL");
        if (distance is null)
            throw new ArgumentException("Distance Cannot Be NULL");
        Environment = environment;
        Distance = distance;
    }

    public Environment Environment { get; private set; }
    public Distance Distance { get; private set; }
}