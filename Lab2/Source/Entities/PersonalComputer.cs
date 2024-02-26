using Lab2.Source.Entities.Storage;

namespace Lab2.Source.Entities;

public class PersonalComputer
{
    public PersonalComputer(
        ComputerCase computerCase,
        PowerSupply powerSupply,
        Motherboard motherboard,
        Processor processor,
        CpuCooler cooler,
        Memory memory,
        GraphicsCard? graphicsCard,
        ICollection<Disk> storage)
    {
        ComputerCase = computerCase;
        PowerSupply = powerSupply;
        Motherboard = motherboard;
        Processor = processor;
        CpuCooler = cooler;
        Memory = memory;
        GraphicsCard = graphicsCard;
        Storage = storage;
    }

    public ComputerCase ComputerCase { get; private set; }
    public PowerSupply PowerSupply { get; private set; }
    public Motherboard Motherboard { get; private set; }
    public Processor Processor { get; private set; }
    public CpuCooler CpuCooler { get; private set; }
    public Memory Memory { get; private set; }
    public GraphicsCard? GraphicsCard { get; private set; }
    public ICollection<Disk> Storage { get; private set; }
}
