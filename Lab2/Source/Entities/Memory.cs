using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class Memory
{
    public Memory(Name name, Gigabyte volume, int quantity, Megahertz clock, string timings, DdrStandard standard, Watt powerConsumption)
    {
        Name = name;
        Volume = volume;
        Quantity = quantity;
        Clock = clock;
        Timings = timings;
        Standard = standard;
        PowerConsumption = powerConsumption;
    }

    public Name Name { get; private set; }
    public Gigabyte Volume { get; private set; }
    public int Quantity { get; private set; }
    public Megahertz Clock { get; private set; }
    public string Timings { get; private set; }
    public DdrStandard Standard { get; private set; }
    public Watt PowerConsumption { get; private set; }
}
