using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class GraphicsCard
{
    public GraphicsCard(
        Name name,
        Millimeter length,
        Millimeter width,
        Gigabyte memory,
        double pciVersion,
        Megahertz coreClock,
        Watt powerConsumption)
    {
        Name = name;
        Length = length;
        Width = width;
        Memory = memory;
        PciVersion = pciVersion;
        CoreClock = coreClock;
        PowerConsumption = powerConsumption;
    }

    public Name Name { get; private set; }
    public Millimeter Length { get; private set; }
    public Millimeter Width { get; private set; }
    public Gigabyte Memory { get; private set; }
    public double PciVersion { get; private set; }
    public Megahertz CoreClock { get; private set; }
    public Watt PowerConsumption { get; private set; }
}