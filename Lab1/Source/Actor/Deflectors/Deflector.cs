using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Exceptions.ValueExceptions;
using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Actor.Deflectors;

public abstract class Deflector
{
    private const double BasePhotonicHealth = 4.0;
    protected Deflector(double health, bool isPhotonic)
    {
        if (health < 0)
            throw new NegativeValueException("Deflector Health Cannot Be Negative");
        Health = health;
        PhotonicHealth = isPhotonic ? BasePhotonicHealth : 0.0;
    }

    public double PhotonicHealth { get; private set; }
    public double Health { get; private set; }
    public bool DeflectorHasHealth => Health > 0;
    public bool DeflectorHasPhotonicHealth => PhotonicHealth > 0;
    public void TakeAHit(Damage damage, double multiplier)
    {
        if (damage is null)
            throw new DamageIsNullException("Damage Cannot Be NULL");
        switch (damage.Type)
        {
            case DamageTypes.Physical or DamageTypes.Colossal:
                Health -= damage.Amount * multiplier;
                break;
            case DamageTypes.Crew:
                PhotonicHealth -= damage.Amount;
                break;
        }
    }
}
