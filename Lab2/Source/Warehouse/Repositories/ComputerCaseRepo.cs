using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class ComputerCaseRepo : Repo<ComputerCase>
{
    private static Collection<ComputerCase> _computerCaseRepo = new()
    {
        new ComputerCase(new("Cooler Master n200"), new(330), new(155), new Collection<string> { "Mini-ITX" }, new(376), new(185), new(292)),
        new ComputerCase(new("NZXT H500"), new(381), new(165), new Collection<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new(428), new(210), new(460)),
        new ComputerCase(new("Lian Li 011D"), new(446), new(167), new Collection<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new(471), new(285), new(513)),
    };

    public override IReadOnlyCollection<ComputerCase> Stock { get; } = _computerCaseRepo;

    public override ComputerCase? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        ComputerCase? computerCase = Stock.SingleOrDefault(x => x.Name.Value == name);
        return computerCase;
    }

    public override ComputerCase GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        ComputerCase computerCase = Stock.Single(x => x.Name.Value == name);
        return computerCase;
    }

    public override void AddItem(ComputerCase item)
    {
        if (item is null)
            throw new RepoException("Invalid Computer Case");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Computer Case Already Present");
        _computerCaseRepo.Add(item);
    }
}