using Lab1.Source.Exceptions.ValueExceptions;
using Lab1.Source.Services.ClassResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Source.Services.ClassResult.Results;

public class Success : Result
{
    public Success(ResultType type, double requiredFuel)
    {
        if (requiredFuel < 0)
            throw new NegativeValueException("Required Fuel Cannot Be Less Than 0");
        Type = type;
        RequiredFuel = requiredFuel;
    }
}