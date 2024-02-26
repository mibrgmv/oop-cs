using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Filling.Obstacles.Types;

public class Meteor : Obstacle
{
    private const double BaseMeteorDamage = 120.0;
    public Meteor(int quantity)
        : base(new Damage(DamageTypes.Physical, BaseMeteorDamage), quantity) { }
}