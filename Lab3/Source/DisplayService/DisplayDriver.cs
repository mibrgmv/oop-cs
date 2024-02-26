namespace Lab3.Source.DisplayService;

public class DisplayDriver : IDisplayDriver
{
    public DisplayDriver(ConsoleColor color)
    {
        Color = color;
    }

    public ConsoleColor Color { get; init; }

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void WriteText(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentException("Invalid Text. Cannot Write To Console");
        Console.WriteLine(text);
    }
}