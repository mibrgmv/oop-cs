using Lab1.Source.Actor.Deflectors;
using Lab1.Source.Actor.Deflectors.DeflectorClasses;
using Lab1.Source.Actor.Engines;
using Lab1.Source.Actor.WeightDimensionalCharacteristics;
using Lab1.Source.Exceptions.IsNullExceptions;
using Lab1.Source.Filling.ClassDamage;

namespace Lab1.Source.Actor.Spaceships;

public abstract class Spaceship
{
    protected Spaceship(
        ImpulseEngine? impulse,
        WarpEngine? warp,
        Deflector? deflector,
        Toughness.Toughness toughness,
        WeightDimensionalCharacteristic weightDimensionalCharacteristic,
        bool emitter)
    {
        ImpulseEngine = impulse;
        WarpEngine = warp;
        Deflector = deflector;
        Toughness = toughness;
        WeightDimensionalCharacteristic = weightDimensionalCharacteristic;
        Emitter = emitter;
        IsCrewAlive = true;
        Destroyed = false;
        DamageMultiplier = WeightDimensionalCharacteristic switch
        {
            WeightDimensionalCharacteristic.High => 0.95,
            WeightDimensionalCharacteristic.Medium => 0.975,
            WeightDimensionalCharacteristic.Low => 1.0,
            _ => throw new ArgumentException("Unexpected Enum Argument"),
        };
    }

    public ImpulseEngine? ImpulseEngine { get; }
    public WarpEngine? WarpEngine { get; }
    public Deflector? Deflector { get; private set; }
    public bool IsCrewAlive { get; private set; }
    public bool Destroyed { get; private set; }
    public bool DeflectorActive => Deflector is not null;
    private bool Emitter { get; }
    private WeightDimensionalCharacteristic WeightDimensionalCharacteristic { get; }
    private Toughness.Toughness Toughness { get; }
    private double DamageMultiplier { get; }
    public void TakeDamage(Damage damage)
    {
        if (damage is null)
        {
            throw new DamageIsNullException("Damage Cannot Be NULL");
        }

        switch (damage.Type)
        {
            case DamageTypes.Colossal when Emitter is false && (Deflector is null or not DeflectorClassThree):
            {
                Destroyed = true;
                break;
            }

            case DamageTypes.Colossal when Emitter is false && Deflector is not null:
            {
                Deflector.TakeAHit(damage, DamageMultiplier);
                if (Deflector.DeflectorHasHealth is false) Deflector = null;
                break;
            }

            case DamageTypes.Physical when Deflector is not null:
            {
                Deflector.TakeAHit(damage, DamageMultiplier);
                if (Deflector.DeflectorHasHealth is false) Deflector = null;
                break;
            }

            case DamageTypes.Physical:
            {
                Toughness.TakeAHit(damage, DamageMultiplier);
                if (Toughness.HasHealth is false) Destroyed = true;
                break;
            }

            case DamageTypes.Crew when Deflector is null:
            {
                IsCrewAlive = false;
                break;
            }

            case DamageTypes.Crew:
            {
                Deflector.TakeAHit(damage, DamageMultiplier);
                if (!Deflector.DeflectorHasPhotonicHealth) IsCrewAlive = false;
                break;
            }
        }
    }
}