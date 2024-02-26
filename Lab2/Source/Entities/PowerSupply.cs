using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class PowerSupply
{
    public PowerSupply(Name name, Watt capacity)
    {
        Name = name;
        Capacity = capacity;
    }

    public Name Name { get; private set; }
    public Watt Capacity { get; private set; }
}
