using Lab2.Source.Builders;
using Lab2.Source.Entities;
using Lab2.Source.Exceptions;
using Lab2.Source.Warehouse;
using Xunit;

namespace Lab2.Tests.PersonalComputerTests;

public class RepositoryTests
{
    [Fact]
    public void AddGraphicsCardTest()
    {
        Supplier.GraphicsCardRepo.AddItem(new GraphicsCard(
            new("RTX-3070"), 
            new(232),
            new(124),
            new(8),
            4.0, 
            new(1500),
            new(220)
            )
        );
        var builder = new PersonalComputerBuilder();
        PersonalComputerDriver driver = new(builder);

        driver.BuildHighEndPersonalComputer();
        PersonalComputer pc = builder
            .BuildGraphicsCard(Supplier.GraphicsCardRepo.FindItem("RTX-3070"))
            .Build();

        Assert.True(Supplier.GraphicsCardRepo.FindItem("RTX-3070") != null);
        Assert.True(pc.GraphicsCard is not null);
        Assert.True(pc.GraphicsCard.Name.Value == "RTX-3070");
    }

    [Fact]
    public void AddExistingGraphicsCardTest()
    {
        RepoException repoException = Assert.Throws<RepoException>(
            () => Supplier.GraphicsCardRepo.AddItem(
                new GraphicsCard(
                    new("RTX-4060"),
                    new(247),
                    new(130),
                    new(8),
                    4.0,
                    new(1830),
                    new(120))
                )
            );
        Assert.Equal("Graphics Card Already Present", repoException.Message);
    }
}