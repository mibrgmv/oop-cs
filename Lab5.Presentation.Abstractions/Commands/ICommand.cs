namespace Lab5.Presentation.Abstractions.Commands;

public interface ICommand
{
    ICommand SetNextCommand(ICommand command);
    void Execute(string command);
}