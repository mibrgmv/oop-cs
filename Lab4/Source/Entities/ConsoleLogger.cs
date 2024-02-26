namespace Lab4.Source.Entities;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Console.WriteLine(message);
    }
}