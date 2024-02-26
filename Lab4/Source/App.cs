using Lab4.Source.CommandParser;
using Lab4.Source.Entities;
using Lab4.Source.Models;

namespace Lab4.Source;

public static class App
{
    public static void Run()
    {
        var parser = new Parser();
        FileSystem.SetEmojis("\ud83d\udc95", "💖");
        FileSystem.SetLogger(new ConsoleLogger());
        while (true)
        {
            string? command = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(command)) break;
            parser.Parse(new ConsoleCommand(command));
        }
    }
}