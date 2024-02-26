namespace Lab1.Source.Actor.Deflectors.DeflectorClasses;

public class DeflectorClassTwo : Deflector
{
    private const double DeflectorClassTwoBaseHealth = 140;
    public DeflectorClassTwo(bool isPhotonic = false)
        : base(DeflectorClassTwoBaseHealth, isPhotonic) { }
}