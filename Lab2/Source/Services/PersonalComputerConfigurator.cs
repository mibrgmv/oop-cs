using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Services;

public class PersonalComputerConfigurator : IPersonalComputerConfigurator
{
    public bool ValidateSizes(PersonalComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentException("Invalid Personal Computer");
        if (personalComputer.ComputerCase.MaxCoolerHeight.Value < personalComputer.CpuCooler.Height.Value
            || personalComputer.ComputerCase.MaxGpuLength.Value < personalComputer.GraphicsCard?.Length.Value
            || personalComputer.ComputerCase.ValidMotherboardFormFactors.Contains(personalComputer.Motherboard.FormFactor) is false)
            return false;
        return true;
    }

    public bool ValidateSlots(PersonalComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentException("Invalid Personal Computer");
        if (personalComputer.CpuCooler.SupportedSockets.Contains(personalComputer.Processor.Socket.Value) is false
            || personalComputer.Motherboard.NumberOfRamSlots < personalComputer.Memory.Quantity
            || personalComputer.Storage.Count(x => x.ConnectionInterface == "SATA") > personalComputer.Motherboard.NumberOfSataPorts
            || personalComputer.Motherboard.SupportedDdrStandard.Value != personalComputer.Memory.Standard.Value)
            return false;
        return true;
    }

    public bool ValidateProcessorCompatibility(PersonalComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentException("Invalid Personal Computer");
        if (personalComputer.Motherboard.Bios.SupportedProcessors.Contains(personalComputer.Processor.Name.Value) is false
            || Equals(personalComputer.Processor.Socket, personalComputer.Motherboard.CpuSocket) is false)
            return false;
        return true;
    }

    public bool ValidateTemperature(PersonalComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentException("Invalid Personal Computer");
        return personalComputer.CpuCooler.MaxThermalDesignPower.Value >= personalComputer.Processor.ThermalDesignPower.Value;
    }

    public Result ValidatePersonalComputer(PersonalComputer personalComputer)
    {
        if (personalComputer is null)
            throw new ArgumentException("Invalid Personal Computer");
        bool hasWarranty = true;
        bool isGivenWarning = false;
        if (personalComputer.GraphicsCard is null && personalComputer.Processor.HasIntegralGraphics is false)
            throw new PersonalComputerException("Cannot Output Graphics");
        if (personalComputer.Storage.Count == 0)
            throw new PersonalComputerException("No Disk: Cannot Boot");
        if (personalComputer.Storage.Sum(x => x.PowerConsumption.Value) + personalComputer.Processor.PowerConsumption.Value + personalComputer.GraphicsCard?.PowerConsumption.Value > personalComputer.PowerSupply.Capacity.Value)
            throw new PersonalComputerException("Cannot Boot: Insufficient Power Supply");
        if (ValidateSlots(personalComputer) is false || ValidateProcessorCompatibility(personalComputer) is false)
            hasWarranty = false;
        if (ValidateSizes(personalComputer) is false || ValidateTemperature(personalComputer) is false || hasWarranty is false)
            isGivenWarning = true;
        return new(hasWarranty, isGivenWarning);
    }
}