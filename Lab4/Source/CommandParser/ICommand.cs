namespace Lab4.Source.CommandParser;

public interface ICommand
{
    ICommand SetNextCommand(ICommand command);
    void Execute(string command);
}