using Lab2.Source.Entities;
using Lab2.Source.Entities.Storage;

namespace Lab2.Source.Builders;

public class PersonalComputerBuilder
{
    private ComputerCase? _computerCase;
    private PowerSupply? _powerSupply;
    private Motherboard? _motherboard;
    private Processor? _processor;
    private CpuCooler? _cpuCooler;
    private Memory? _memory;
    private GraphicsCard? _graphicsCard;
    private ICollection<Disk>? _storage;

    public PersonalComputerBuilder BuildCase(ComputerCase? computerCase)
    {
        if (computerCase is null)
            throw new ArgumentException("Invalid Computer Case");
        _computerCase = computerCase;
        return this;
    }

    public PersonalComputerBuilder BuildPowerSupply(PowerSupply? powerSupply)
    {
        if (powerSupply is null)
            throw new ArgumentException("Invalid Power Supply");
        _powerSupply = powerSupply;
        return this;
    }

    public PersonalComputerBuilder BuildMotherboard(Motherboard? motherboard)
    {
        if (motherboard is null)
            throw new ArgumentException("Invalid Motherboard");
        _motherboard = motherboard;
        return this;
    }

    public PersonalComputerBuilder BuildProcessor(Processor? processor)
    {
        if (processor is null)
            throw new ArgumentException("Invalid Processor");
        _processor = processor;
        return this;
    }

    public PersonalComputerBuilder BuildCpuCooler(CpuCooler? cpuCooler)
    {
        if (cpuCooler is null)
            throw new ArgumentException("Invalid CPU Cooler");
        _cpuCooler = cpuCooler;
        return this;
    }

    public PersonalComputerBuilder BuildMemory(Memory? memory)
    {
        if (memory is null)
            throw new ArgumentException("Invalid Memory");
        _memory = memory;
        return this;
    }

    public PersonalComputerBuilder BuildGraphicsCard(GraphicsCard? graphicsCard)
    {
        if (graphicsCard is null)
            throw new ArgumentException("Invalid Graphics Card");
        _graphicsCard = graphicsCard;
        return this;
    }

    public PersonalComputerBuilder BuildStorage(ICollection<Disk>? disks)
    {
        if (disks is null)
            throw new ArgumentException("Invalid List Of Disks");
        _storage = disks;
        return this;
    }

    public PersonalComputer Build()
    {
        PersonalComputer personalComputer = new(
            _computerCase ?? throw new ArgumentException("Trying To Build With Invalid Computer Case"),
            _powerSupply ?? throw new ArgumentException("Trying To Build With Invalid PSU"),
            _motherboard ?? throw new ArgumentException("Trying To Build With Invalid Motherboard"),
            _processor ?? throw new ArgumentException("Trying To Build With Invalid Processor"),
            _cpuCooler ?? throw new ArgumentException("Trying To Build With Invalid CPU Cooler"),
            _memory ?? throw new ArgumentException("Trying To Build With Invalid Memory"),
            _graphicsCard,
            _storage ?? throw new ArgumentException("Trying To Build With Invalid Storage"));
        return personalComputer;
    }
}
