using Lab5.Presentation.Abstractions.Commands;
using Lab5.Presentation.ConsoleInterfaceExceptions;

namespace Lab5.Presentation.Commands;

public class Command : ICommand
{
    private ICommand? _nextCommand;

    public Command()
    {
        _nextCommand = null;
    }

    public ICommand SetNextCommand(ICommand command)
    {
        _nextCommand = command;
        return command;
    }

    public virtual void Execute(string command)
    {
        if (_nextCommand == null)
            throw new MissingNextCommandException("Ran Out Of Commands To Execute");
        _nextCommand.Execute(command);
    }
}