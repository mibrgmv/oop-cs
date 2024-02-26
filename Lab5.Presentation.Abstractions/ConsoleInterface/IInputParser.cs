namespace Lab5.Presentation.Abstractions.ConsoleInterface;

public interface IInputParser
{
    public void ParseAdminCommand(string command);

    public void ParseCustomerCommand(string command);

    public void ParseLoginCommand(string command);
}