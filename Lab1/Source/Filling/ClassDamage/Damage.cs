using Lab1.Source.Exceptions.ValueExceptions;

namespace Lab1.Source.Filling.ClassDamage;

public class Damage
{
    public Damage(DamageTypes type, double amount)
    {
        if (amount < 0)
            throw new NegativeValueException("Amount Of Damage Cannot Be Negative");
        Amount = amount;
        Type = type;
    }

    public double Amount { get; }
    public DamageTypes Type { get; }
}