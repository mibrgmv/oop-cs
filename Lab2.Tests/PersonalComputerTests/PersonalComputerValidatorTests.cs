using System.Collections.ObjectModel;
using Lab2.Source.Builders;
using Lab2.Source.Entities;
using Lab2.Source.Entities.Storage;
using Lab2.Source.Exceptions;
using Lab2.Source.Services;
using Lab2.Source.Warehouse;
using Xunit;

namespace Lab2.Tests.PersonalComputerTests;

public class PersonalComputerValidatorTests
{
    private PersonalComputerConfigurator _personalComputerConfigurator = new();
    private PersonalComputerBuilder _builder = new();

    [Fact]
    public void AllCompatibleTest()
    {
        Arrange();

        PersonalComputer personalComputer = _builder.Build();
        Result result = _personalComputerConfigurator.ValidatePersonalComputer(personalComputer);

        Assert.True(result.HasWarranty);
        Assert.False(result.IsGivenWarning);
    }

    [Fact]
    public void InsufficientPowerSupplyTest()
    {
        Arrange();
        _builder.BuildPowerSupply(Supplier.PowerSupplyRepo.FindItem("RM-550x"));

        PersonalComputer personalComputer = _builder.Build();

        PersonalComputerException personalComputerException = Assert.Throws<PersonalComputerException>(() => _personalComputerConfigurator.ValidatePersonalComputer(personalComputer));
        Assert.Equal("Cannot Boot: Insufficient Power Supply", personalComputerException.Message);
    }

    [Fact]
    public void InsufficientCoolerTest()
    {
        Arrange();
        _builder.BuildCpuCooler(Supplier.CpuCoolerRepo.FindItem("be quiet! PURE ROCK 2"));

        PersonalComputer personalComputer = _builder.Build();
        Result result = _personalComputerConfigurator.ValidatePersonalComputer(personalComputer);

        Assert.True(result.HasWarranty);
        Assert.True(result.IsGivenWarning);
    }

    [Fact]
    public void EmptyStorageTest()
    {
        Arrange();
        _builder.BuildStorage(new Collection<Disk>());

        PersonalComputer personalComputer = _builder.Build();

        PersonalComputerException personalComputerException = Assert.Throws<PersonalComputerException>(() => _personalComputerConfigurator.ValidatePersonalComputer(personalComputer));
        Assert.Equal("No Disk: Cannot Boot", personalComputerException.Message);
    }

    [Fact]
    public void InsufficientMemoryAndStorageTest()
    {
        Arrange();
        _builder.BuildMemory(Supplier.MemoryRepo.FindItem("16gb 8x2 DDR4"))
                .BuildStorage(new Collection<Disk>
                    { Supplier.DiskRepo.GetItem("SSD 1tb"), Supplier.DiskRepo.GetItem("SSD 1tb"), Supplier.DiskRepo.GetItem("SSD 1tb"), Supplier.DiskRepo.GetItem("SSD 1tb"), Supplier.DiskRepo.GetItem("SSD 1tb"), Supplier.DiskRepo.GetItem("SSD 1tb") });

        PersonalComputer personalComputer = _builder.Build();
        Result result = _personalComputerConfigurator.ValidatePersonalComputer(personalComputer);

        Assert.False(result.HasWarranty);
        Assert.True(result.IsGivenWarning);
    }

    private void Arrange()
    {
        PersonalComputerDriver driver = new(_builder);
        driver.BuildHighEndPersonalComputer();
    }
}