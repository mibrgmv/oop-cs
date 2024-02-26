using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class Processor
{
    public Processor(Name name, Megahertz coreClock, int numberOfCores, Socket socket, bool hasIntegralGraphics, int maxRamClock, Watt thermalDesignPower, Watt powerConsumption)
    {
        Name = name;
        CoreClock = coreClock;
        NumberOfCores = numberOfCores;
        Socket = socket;
        HasIntegralGraphics = hasIntegralGraphics;
        MaxRamClock = maxRamClock;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
    }

    public Name Name { get; private set; }
    public Megahertz CoreClock { get; private set; }
    public int NumberOfCores { get; private set; }
    public Socket Socket { get; private set; }
    public bool HasIntegralGraphics { get; private set; }
    public int MaxRamClock { get; private set; }
    public Watt ThermalDesignPower { get; private set; }
    public Watt PowerConsumption { get; private set; }
}
