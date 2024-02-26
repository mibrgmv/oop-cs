using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Filling.Obstacles.Types;

public class Whale : Obstacle
{
    private const double BaseWhaleDamage = 1300.0;
    public Whale(int quantity)
        : base(new Damage(DamageTypes.Colossal, BaseWhaleDamage), quantity) { }
}