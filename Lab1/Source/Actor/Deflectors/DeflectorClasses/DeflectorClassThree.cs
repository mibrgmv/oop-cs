namespace Lab1.Source.Actor.Deflectors.DeflectorClasses;

public class DeflectorClassThree : Deflector
{
    private const double DeflectorClassThreeBaseHealth = 1100;
    public DeflectorClassThree(bool isPhotonic = false)
        : base(DeflectorClassThreeBaseHealth, isPhotonic) { }
}