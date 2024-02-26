using Lab2.Source.Warehouse.Repositories;

namespace Lab2.Source.Warehouse;

public abstract class Supplier
{
    public static BiosRepo BiosRepo { get; } = new();
    public static ComputerCaseRepo ComputerCaseRepo { get; } = new();
    public static CpuCoolerRepo CpuCoolerRepo { get; } = new();
    public static DiskRepo DiskRepo { get; } = new();
    public static GraphicsCardRepo GraphicsCardRepo { get; } = new();
    public static MemoryRepo MemoryRepo { get; } = new();
    public static MotherboardRepo MotherboardRepo { get; } = new();
    public static PowerSupplyRepo PowerSupplyRepo { get; } = new();
    public static ProcessorRepo ProcessorRepo { get; } = new();
}