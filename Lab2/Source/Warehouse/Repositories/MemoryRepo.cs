using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class MemoryRepo : Repo<Memory>
{
    private static Collection<Memory> _memoryRepo = new()
    {
        new Memory(new("16gb 8x2 DDR4"), new(16), 2, new(3200), "16-18-18-36", new("DDR4"), new(2)),
        new Memory(new("32gb 8x4 DDR5"), new(32), 4, new(5600), "40-40-40-76", new("DDR5"), new(2)),
    };

    public override IReadOnlyCollection<Memory> Stock { get; } = _memoryRepo;

    public override Memory? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Memory? memory = Stock.SingleOrDefault(x => x.Name.Value == name);
        return memory;
    }

    public override Memory GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Memory memory = Stock.Single(x => x.Name.Value == name);
        return memory;
    }

    public override void AddItem(Memory item)
    {
        if (item is null)
            throw new RepoException("Invalid Memory");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Memory Already Present");
        _memoryRepo.Add(item);
    }
}
