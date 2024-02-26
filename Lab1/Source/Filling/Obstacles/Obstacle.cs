using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Exceptions.ValueExceptions;
using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Filling.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(Damage damage, int quantity)
    {
        if (damage is null)
            throw new DamageIsNullException("Damage Cannot Be NULL");
        if (quantity < 0)
            throw new NegativeValueException("Obstacle Quantity Cannot Be Negative");
        Damage = damage;
        Quantity = quantity;
    }

    public Damage Damage { get; }
    public int Quantity { get; }
}