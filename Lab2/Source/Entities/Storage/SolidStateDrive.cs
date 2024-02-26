using Lab2.Source.Models;

namespace Lab2.Source.Entities.Storage;

public class SolidStateDrive : Disk
{
    public SolidStateDrive(Name name, string? connectionInterface, Gigabyte capacity, int readSpeed, int writeSpeed, Watt powerConsumption)
        : base(name, capacity, powerConsumption, connectionInterface)
    {
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
    }

    public int ReadSpeed { get; private set; }
    public int WriteSpeed { get; private set; }
}