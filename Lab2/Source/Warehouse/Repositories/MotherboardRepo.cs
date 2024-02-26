using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class MotherboardRepo : Repo<Motherboard>
{
    private static Collection<Motherboard> _motherboardRepo = new()
    {
        new Motherboard(new("MSI Mortar"), new("LGA 1700"), 2, 4, "B760", new("DDR4"), 4, "ATX", Supplier.BiosRepo.GetItem("UEFI")),
        new Motherboard(new("MSI Carbon"), new("LGA 1700"), 2, 6, "Z790", new("DDR5"), 4, "ATX", Supplier.BiosRepo.GetItem("UEFI")),
    };

    public override IReadOnlyCollection<Motherboard> Stock { get; } = _motherboardRepo;

    public override Motherboard? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Motherboard? motherboard = Stock.SingleOrDefault(x => x.Name.Value == name);
        return motherboard;
    }

    public override Motherboard GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Motherboard motherboard = Stock.Single(x => x.Name.Value == name);
        return motherboard;
    }

    public override void AddItem(Motherboard item)
    {
        if (item is null)
            throw new RepoException("Invalid Motherboard");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Motherboard Already Present");
        _motherboardRepo.Add(item);
    }
}