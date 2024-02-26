using System.Collections.ObjectModel;
using Lab2.Source.Entities.Storage;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class DiskRepo : Repo<Disk>
{
    private static Collection<Disk> _diskRepo = new()
    {
        new HardDiskDrive(new("HDD 1tb"), new(1000), 7200, new(7)),
        new HardDiskDrive(new("HDD 2,5tb"), new(1000), 7200, new(7)),
        new SolidStateDrive(new("SSD 500gb"), "SATA", new(500), 560, 530, new(4)),
        new SolidStateDrive(new("SSD 1tb"), "SATA", new(1000), 560, 530, new(4)),
    };

    public override IReadOnlyCollection<Disk> Stock { get; } = _diskRepo;

    public override Disk? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Disk? disk = Stock.SingleOrDefault(x => x.Name.Value == name);
        return disk;
    }

    public override Disk GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Disk disk = Stock.Single(x => x.Name.Value == name);
        return disk;
    }

    public override void AddItem(Disk item)
    {
        if (item is null)
            throw new RepoException("Invalid Disk");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Disk Already Present");
        _diskRepo.Add(item);
    }
}
