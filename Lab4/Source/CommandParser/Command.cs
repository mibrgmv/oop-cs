namespace Lab4.Source.CommandParser;

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
        _nextCommand?.Execute(command);
    }
}