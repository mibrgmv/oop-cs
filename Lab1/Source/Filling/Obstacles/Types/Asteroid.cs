using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Filling.Obstacles.Types;

public class Asteroid : Obstacle
{
    private const double BaseAsteroidDamage = 30.0;
    public Asteroid(int quantity)
        : base(new Damage(DamageTypes.Physical, BaseAsteroidDamage), quantity) { }
}