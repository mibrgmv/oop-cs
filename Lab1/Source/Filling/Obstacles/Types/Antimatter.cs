using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Filling.Obstacles.Types;

public class Antimatter : Obstacle
{
    private const double BasePhotonicDamage = 1.0;
    public Antimatter(int quantity)
        : base(new Damage(DamageTypes.Crew, BasePhotonicDamage), quantity) { }
}