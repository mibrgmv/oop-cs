using Lab2.Source.Models;

namespace Lab2.Source.Entities.Storage;

public abstract class Disk
{
    protected Disk(Name name, Gigabyte capacity, Watt powerConsumption, string? connectionInterface)
    {
        Name = name;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
        ConnectionInterface = connectionInterface;
    }

    public string? ConnectionInterface { get; private set; }
    public Name Name { get; private set; }
    public Gigabyte Capacity { get; private set; }
    public Watt PowerConsumption { get; private set; }
}
