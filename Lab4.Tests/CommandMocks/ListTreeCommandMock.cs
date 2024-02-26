using Lab4.Source.CommandParser;

namespace Lab4.Tests.CommandMocks;

public class ListTreeCommandMock : Command
{
    public ICollection<string> Attributes { get; private set; } = new List<string>();

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["tree", "list", "-d", _])
        {
            Attributes.Add(split[3]);
        }
        else
        {
            base.Execute(command);
        }
    }
}