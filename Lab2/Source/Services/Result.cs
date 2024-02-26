namespace Lab2.Source.Services;

public class Result
{
    public Result(bool hasWarranty, bool isGivenWarning)
    {
        HasWarranty = hasWarranty;
        IsGivenWarning = isGivenWarning;
    }

    public bool HasWarranty { get; private set; }
    public bool IsGivenWarning { get; private set; }
}