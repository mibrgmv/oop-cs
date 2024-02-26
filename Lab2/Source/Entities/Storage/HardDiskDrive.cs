using Lab2.Source.Models;

namespace Lab2.Source.Entities.Storage;

public class HardDiskDrive : Disk
{
    public HardDiskDrive(Name name, Gigabyte capacity, int spindleSpeed, Watt powerConsumption)
        : base(name, capacity, powerConsumption, null)
    {
        SpindleSpeed = spindleSpeed;
    }

    public int SpindleSpeed { get; private set; }
}
