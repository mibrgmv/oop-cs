using Itmo.ObjectOrientedProgramming.Lab1.Source.Services.ClassResult.Results;
using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Filling.Environments;
using Lab1.Source.Filling.Obstacles.Types;
using Lab1.Source.Services;
using Lab1.Source.Services.ClassResult;
using Path = Lab1.Source.Filling.Path.Path;
using Xunit;

namespace Lab1.Tests.RouteServiceTests;

public class RouteServiceTests
{
    [Theory]
    [InlineData(SpaceshipNames.Shuttle, SpaceshipNames.Avgur, 600, EnvironmentNames.NebulaOfIncreasedDepthsOfSpace)]
    public void TestCase1(SpaceshipNames name1, SpaceshipNames name2, int distance, EnvironmentNames environment)
    {
        var a = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name1);
        Spaceship ship2 = s.ShipSelector(name2);

        a.AddPath(s.PathSelector(distance, environment));
        Result res1 = a.CheckShip(ship1);
        Result res2 = a.CheckShip(ship2);

        Assert.True(res1 is Failure);
        Assert.True(res2 is Failure);
    }

    [Theory]
    [InlineData(SpaceshipNames.Vaklas, 600, EnvironmentNames.Space)]
    public void TestCase2(SpaceshipNames name, int distance, EnvironmentNames environment)
    {
        var route = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name);
        Spaceship ship2 = s.ShipSelector(name, true);
        Path path = s.PathSelector(distance, environment);

        path.Environment.AddObstacle(new Antimatter(1));
        route.AddPath(path);
        Result res1 = route.CheckShip(ship1);
        Result res2 = route.CheckShip(ship2);

        Assert.True(res1 is Failure);
        Assert.True(res2 is Success);
    }

    [Theory]
    [InlineData(SpaceshipNames.Vaklas, SpaceshipNames.Avgur, SpaceshipNames.Meridian, 600, EnvironmentNames.NebulaOfNitrineParticles)]
    public void TestCase3(SpaceshipNames name1, SpaceshipNames name2, SpaceshipNames name3, int distance, EnvironmentNames environment)
    {
        var route = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name1);
        Spaceship ship2 = s.ShipSelector(name2);
        Spaceship ship3 = s.ShipSelector(name3);
        Path path = s.PathSelector(distance, environment);

        path.Environment.AddObstacle(new Whale(1));
        route.AddPath(path);
        Result res1 = route.CheckShip(ship1);
        Result res2 = route.CheckShip(ship2);
        Result res3 = route.CheckShip(ship3);

        Assert.True(res1.Type is ResultType.ShipDestroyed);
        Assert.True(res2 is Success);
        Assert.False(ship2.DeflectorActive);
        Assert.True(res3 is Success);
        Assert.True(ship3.DeflectorActive);
    }

    [Theory]
    [InlineData(SpaceshipNames.Shuttle, SpaceshipNames.Vaklas, 150, EnvironmentNames.Space)]
    public void TestCase4(SpaceshipNames name1, SpaceshipNames name2, int distance, EnvironmentNames environment)
    {
        var route = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name1);
        Spaceship ship2 = s.ShipSelector(name2);

        route.AddPath(s.PathSelector(distance, environment));

        Assert.True(route.CompareShips(ship1, ship2) == ship1);
    }

    [Theory]
    [InlineData(SpaceshipNames.Avgur, SpaceshipNames.Stella, 500, EnvironmentNames.NebulaOfIncreasedDepthsOfSpace)]
    public void TestCase5(SpaceshipNames name1, SpaceshipNames name2, int distance, EnvironmentNames environment)
    {
        var route = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name1);
        Spaceship ship2 = s.ShipSelector(name2);

        route.AddPath(s.PathSelector(distance, environment));
        Result res1 = route.CheckShip(ship1);

        Assert.True(res1.Type is ResultType.ShipLost);
        Assert.True(route.CompareShips(ship1, ship2) == ship2);
    }

    [Theory]
    [InlineData(SpaceshipNames.Shuttle, SpaceshipNames.Vaklas, 150, EnvironmentNames.NebulaOfNitrineParticles)]
    public void TestCase6(SpaceshipNames name1, SpaceshipNames name2, int distance, EnvironmentNames environment)
    {
        var route = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(name1);
        Spaceship ship2 = s.ShipSelector(name2);

        route.AddPath(s.PathSelector(distance, environment));

        Assert.True(route.CompareShips(ship1, ship2) == ship2);
    }

    [Fact]
    public void MultiplePathsTest()
    {
        var r1 = new Route();
        var r2 = new Route();
        var r3 = new Route();
        var s = new Selector();
        Spaceship ship = s.ShipSelector(SpaceshipNames.Shuttle);

        r1.AddPath(s.PathSelector(150, EnvironmentNames.Space));
        r2.AddPath(s.PathSelector(150, EnvironmentNames.Space));
        r1.AddPath(s.PathSelector(450, EnvironmentNames.Space));
        r3.AddPath(s.PathSelector(450, EnvironmentNames.Space));

        Assert.True(Math.Abs(r1.CheckShip(ship).RequiredFuel - (r2.CheckShip(ship).RequiredFuel + r3.CheckShip(ship).RequiredFuel)) < 0.001);
    }

    [Fact]
    public void MultiplePathsTest2()
    {
        var r1 = new Route();
        var r2 = new Route();
        var r3 = new Route();
        var s = new Selector();
        Spaceship ship = s.ShipSelector(SpaceshipNames.Avgur);

        r1.AddPath(s.PathSelector(150, EnvironmentNames.NebulaOfIncreasedDepthsOfSpace));
        r2.AddPath(s.PathSelector(150, EnvironmentNames.NebulaOfIncreasedDepthsOfSpace));
        r1.AddPath(s.PathSelector(450, EnvironmentNames.NebulaOfNitrineParticles));
        r3.AddPath(s.PathSelector(450, EnvironmentNames.NebulaOfNitrineParticles));

        Assert.True(Math.Abs(r1.CheckShip(ship).RequiredFuel - (r2.CheckShip(ship).RequiredFuel + r3.CheckShip(ship).RequiredFuel)) < 0.001);
    }
}
