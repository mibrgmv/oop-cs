using Lab1.Source.Services.ClassResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Source.Services.ClassResult.Results;

public class Failure : Result
{
    public Failure(ResultType type)
    {
        Type = type;
    }
}