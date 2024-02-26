using Lab2.Source.Models;

namespace Lab2.Source.Entities;

public class Motherboard
{
    public Motherboard(Name name, Socket cpuSocket, int numberOfPciLines, int numberOfSataPorts, string chipset, DdrStandard supportedDdrStandard, int numberOfRamSlots, string formFactor, Bios bios)
    {
        Name = name;
        CpuSocket = cpuSocket;
        NumberOfPciLines = numberOfPciLines;
        NumberOfSataPorts = numberOfSataPorts;
        Chipset = chipset;
        SupportedDdrStandard = supportedDdrStandard;
        NumberOfRamSlots = numberOfRamSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public Name Name { get; private set; }
    public Socket CpuSocket { get; private set; }
    public int NumberOfPciLines { get; private set; }
    public int NumberOfSataPorts { get; private set; }
    public string Chipset { get; private set; }
    public DdrStandard SupportedDdrStandard { get; private set; }
    public int NumberOfRamSlots { get; private set; }
    public string FormFactor { get; private set; }
    public Bios Bios { get; private set; }
}
