using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class PowerSupplyRepo : Repo<PowerSupply>
{
    private static Collection<PowerSupply> _powerSupplyRepo = new()
    {
        new PowerSupply(new("RM-550x"), new(550)),
        new PowerSupply(new("RM-850x"), new(850)),
        new PowerSupply(new("RM-1000x"), new(1000)),
    };

    public override IReadOnlyCollection<PowerSupply> Stock { get; } = _powerSupplyRepo;

    public override PowerSupply? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        PowerSupply? powerSupply = Stock.SingleOrDefault(x => x.Name.Value == name);
        return powerSupply;
    }

    public override PowerSupply GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        PowerSupply powerSupply = Stock.Single(x => x.Name.Value == name);
        return powerSupply;
    }

    public override void AddItem(PowerSupply item)
    {
        if (item is null)
            throw new RepoException("Invalid Power Supply");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Power Supply Already Present");
        _powerSupplyRepo.Add(item);
    }
}