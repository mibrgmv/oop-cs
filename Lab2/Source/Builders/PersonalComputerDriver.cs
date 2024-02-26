using Lab2.Source.Entities.Storage;
using Lab2.Source.Warehouse;

namespace Lab2.Source.Builders;

public class PersonalComputerDriver
{
    private readonly PersonalComputerBuilder _builder;

    public PersonalComputerDriver(PersonalComputerBuilder builder)
    {
        _builder = builder;
    }

    public void BuildHighEndPersonalComputer()
    {
        _builder.BuildCase(Supplier.ComputerCaseRepo.FindItem("Lian Li 011D"))
                .BuildPowerSupply(Supplier.PowerSupplyRepo.FindItem("RM-1000x"))
                .BuildMotherboard(Supplier.MotherboardRepo.FindItem("MSI Carbon"))
                .BuildProcessor(Supplier.ProcessorRepo.FindItem("i7-13700k"))
                .BuildCpuCooler(Supplier.CpuCoolerRepo.FindItem("be quiet! DARK ROCK 4 PRO"))
                .BuildMemory(Supplier.MemoryRepo.FindItem("32gb 8x4 DDR5"))
                .BuildGraphicsCard(Supplier.GraphicsCardRepo.FindItem("RTX-4090"))
                .BuildStorage(new List<Disk>
                    { Supplier.DiskRepo.GetItem("HDD 2,5tb"), Supplier.DiskRepo.GetItem("SSD 1tb"), });
    }
}