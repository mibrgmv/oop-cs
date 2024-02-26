namespace Lab3.Source.DisplayService;

public interface IDisplayDriver
{
    public ConsoleColor Color { get; protected init; }
    public void ClearOutput();
    public void WriteText(string text);
}