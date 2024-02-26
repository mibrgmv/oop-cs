using Lab1.Source.Actor.Spaceships;
using Lab1.Source.Filling.Environments;
using Lab1.Source.Filling.Obstacles.Types;
using Lab1.Source.Services;
using Path = Lab1.Source.Filling.Path.Path;
using Xunit;

namespace Lab1.Tests.DeflectorTests;

public class DeflectorTests
{
    [Fact]
    public void DeflectorAsteroidTest1()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(SpaceshipNames.Vaklas);
        Spaceship ship2 = s.ShipSelector(SpaceshipNames.Meridian); 
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur); 
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Asteroid(2);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship1);
        r.CheckShip(ship2);
        r.CheckShip(ship3);

        Assert.False(ship1.DeflectorActive);
        Assert.True(ship2.DeflectorActive);
        Assert.True(ship3.DeflectorActive);
    }

    [Fact]
    public void DeflectorAsteroidTest2()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship2 = s.ShipSelector(SpaceshipNames.Meridian);
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur); 
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Asteroid(10);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship2);
        r.CheckShip(ship3);

        Assert.False(ship2.DeflectorActive);
        Assert.True(ship3.DeflectorActive);
    }

    [Fact]
    public void DeflectorAsteroidTest3()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur); 
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Asteroid(40);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship3);

        Assert.False(ship3.DeflectorActive);
    }

    [Fact]
    public void DeflectorMeteorTest1()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship1 = s.ShipSelector(SpaceshipNames.Vaklas);
        Spaceship ship2 = s.ShipSelector(SpaceshipNames.Meridian);
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur); 
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Meteor(1);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship1);
        r.CheckShip(ship2);
        r.CheckShip(ship3);

        Assert.False(ship1.DeflectorActive);
        Assert.True(ship2.DeflectorActive);
        Assert.True(ship3.DeflectorActive);
    }

    [Fact]
    public void DeflectorMeteorTest2()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship2 = s.ShipSelector(SpaceshipNames.Meridian); 
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur); 
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Meteor(3);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship2);
        r.CheckShip(ship3);

        Assert.False(ship2.DeflectorActive);
        Assert.True(ship3.DeflectorActive);
    }

    [Fact]
    public void DeflectorMeteorTest3()
    {
        var r = new Route();
        var s = new Selector();
        Spaceship ship3 = s.ShipSelector(SpaceshipNames.Avgur);
        Path p = s.PathSelector(250, EnvironmentNames.Space);
        var o = new Meteor(10);
        p.Environment.AddObstacle(o);
        r.AddPath(p);

        r.CheckShip(ship3);

        Assert.False(ship3.DeflectorActive);
    }
}
