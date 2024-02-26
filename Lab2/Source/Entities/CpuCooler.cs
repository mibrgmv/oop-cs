using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class CpuCooler
{
    public CpuCooler(Name name, Millimeter length, Millimeter width, Millimeter height, ICollection<string> supportedSockets, Watt maxThermalDesignPower)
    {
        Name = name;
        Length = length;
        Width = width;
        Height = height;
        SupportedSockets = supportedSockets;
        MaxThermalDesignPower = maxThermalDesignPower;
    }

    public Name Name { get; private set; }
    public Millimeter Length { get; private set; }
    public Millimeter Width { get; private set; }
    public Millimeter Height { get; private set; }
    public ICollection<string> SupportedSockets { get; private set; }
    public Watt MaxThermalDesignPower { get; private set; }
}