using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class CpuCoolerRepo : Repo<CpuCooler>
{
    private static Collection<CpuCooler> _cpuCoolerRepo = new()
    {
        new CpuCooler(new("be quiet! PURE ROCK 2"), new(87), new(121), new(155), new Collection<string> { "LGA 1151", "LGA 1151-v2", "LGA 1200", "LGA 1700", "LGA 2066" }, new(150)),
        new CpuCooler(new("be quiet! DARK ROCK 4 PRO"), new(145), new(136), new(163), new Collection<string> { "LGA 1151", "LGA 1151-v2", "LGA 1200", "LGA 1700", "LGA 2066" }, new(260)),
    };

    public override IReadOnlyCollection<CpuCooler> Stock { get; } = _cpuCoolerRepo;

    public override CpuCooler? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        CpuCooler? cpuCooler = Stock.SingleOrDefault(x => x.Name.Value == name);
        return cpuCooler;
    }

    public override CpuCooler GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        CpuCooler cpuCooler = Stock.Single(x => x.Name.Value == name);
        return cpuCooler;
    }

    public override void AddItem(CpuCooler item)
    {
        if (item is null)
            throw new RepoException("Invalid Cpu Cooler");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Cpu Cooler Already Present");
        _cpuCoolerRepo.Add(item);
    }
}
