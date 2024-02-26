using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Exceptions.ValueExceptions;
using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Actor.Toughness;

public abstract class Toughness
{
    protected Toughness(double health)
    {
        if (health < 0)
            throw new NegativeValueException("Health Cannot Be Negative");
        Health = health;
    }

    public double Health { get; private set; }
    public bool HasHealth => Health > 0;
    public void TakeAHit(Damage damage, double multiplier)
    {
        if (damage is null)
            throw new DamageIsNullException("Damage Cannot Be NULL");
        Health -= damage.Amount * multiplier;
    }
}