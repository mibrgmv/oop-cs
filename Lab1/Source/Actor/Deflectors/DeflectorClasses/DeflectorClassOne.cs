namespace Lab1.Source.Actor.Deflectors.DeflectorClasses;

public class DeflectorClassOne : Deflector
{
    private const double DeflectorClassOneBaseHealth = 50;
    public DeflectorClassOne(bool isPhotonic = false)
        : base(DeflectorClassOneBaseHealth, isPhotonic) { }
}