using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class ComputerCase
{
    public ComputerCase(Name name, Millimeter maxGpuLength, Millimeter maxCoolerHeight, ICollection<string> validMotherboardFormFactors, Millimeter length, Millimeter width, Millimeter height)
    {
        Name = name;
        MaxGpuLength = maxGpuLength;
        MaxCoolerHeight = maxCoolerHeight;
        ValidMotherboardFormFactors = validMotherboardFormFactors;
        Length = length;
        Width = width;
        Height = height;
    }

    public Name Name { get; private set; }
    public Millimeter MaxGpuLength { get; private set; }
    public Millimeter MaxCoolerHeight { get; private set; }
    public ICollection<string> ValidMotherboardFormFactors { get; private set; }
    public Millimeter Length { get; private set; }
    public Millimeter Width { get; private set; }
    public Millimeter Height { get; private set; }
}
