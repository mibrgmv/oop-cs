using System.Collections.ObjectModel;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;

namespace Lab2.Source.Warehouse.Repositories;

public class GraphicsCardRepo : Repo<GraphicsCard>
{
    private static Collection<GraphicsCard> _graphicsCardRepo = new()
    {
        new GraphicsCard(new("RTX-1660"), new(247), new(127), new(6), 3.0, new(1530), new(120)),
        new GraphicsCard(new("RTX-4060"), new(247), new(130), new(8), 4.0, new(1830), new(120)),
        new GraphicsCard(new("RTX-4090"), new(337), new(140), new(24), 4.0, new(2230), new(450)),
    };

    public override IReadOnlyCollection<GraphicsCard> Stock { get; } = _graphicsCardRepo;

    public override GraphicsCard? FindItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        GraphicsCard? graphicsCard = Stock.SingleOrDefault(x => x.Name.Value == name);
        return graphicsCard;
    }

    public override GraphicsCard GetItem(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new RepoException("Invalid Name");
        GraphicsCard graphicsCard = Stock.Single(x => x.Name.Value == name);
        return graphicsCard;
    }

    public override void AddItem(GraphicsCard item)
    {
        if (item is null)
            throw new RepoException("Invalid Graphics Card");
        if (FindItem(item.Name.Value) is not null)
            throw new RepoException("Graphics Card Already Present");
        _graphicsCardRepo.Add(item);
    }
}