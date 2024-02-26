using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class ProcessorRepo : Repo<Processor>
{
    private static Collection<Processor> _processorRepo = new()
    {
        new Processor(new("i3-9100"), new(3600), 6, new("LGA 1151"), true, 2400, new(65), new(65)),
        new Processor(new("i5-13400"), new(2500), 10, new("LGA 1700"), true, 4800, new(154), new(65)),
        new Processor(new("i7-13700k"), new(3400), 16, new("LGA 1700"), true, 5600, new(253), new(125)),
    };

    public override IReadOnlyCollection<Processor> Stock { get; } = _processorRepo;

    public override Processor? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Processor? processor = Stock.SingleOrDefault(x => x.Name.Value == name);
        return processor;
    }

    public override Processor GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        Processor processor = Stock.Single(x => x.Name.Value == name);
        return processor;
    }

    public override void AddItem(Processor item)
    {
        if (item is null)
            throw new RepoException("Invalid Processor");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Processor Already Present");
        _processorRepo.Add(item);
    }
}