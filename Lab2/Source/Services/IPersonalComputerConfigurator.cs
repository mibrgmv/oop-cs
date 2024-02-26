using Lab2.Source.Entities;

namespace Lab2.Source.Services;

public interface IPersonalComputerConfigurator
{
    public bool ValidateSizes(PersonalComputer personalComputer);
    public bool ValidateSlots(PersonalComputer personalComputer);
    public bool ValidateProcessorCompatibility(PersonalComputer personalComputer);
    public bool ValidateTemperature(PersonalComputer personalComputer);
    public Result ValidatePersonalComputer(PersonalComputer personalComputer);
}