using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class BiosRepo : Repo<Bios>
{
    private static Collection<Bios> _biosRepo = new()
    {
        new Bios("Legacy", 1996, new Collection<string> { "Pentium", "Pentium II" }),
        new Bios("UEFI", 2023, new Collection<string> { "i5-13400", "i7-13700k" }),
    };

    public override IReadOnlyCollection<Bios> Stock { get; } = _biosRepo;

    public override Bios? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Bios? bios = Stock.SingleOrDefault(x => x.Type == name);
        return bios;
    }

    public override Bios GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Bios bios = Stock.Single(x => x.Type == name);
        return bios;
    }

    public override void AddItem(Bios item)
    {
        if (item is null)
            throw new RepoException("Invalid Bios");
        if (FindItem(item.Type) is not null)
            throw new RepoException("Bios Already Present");
        _biosRepo.Add(item);
    }
}
