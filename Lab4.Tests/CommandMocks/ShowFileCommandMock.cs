using Lab4.Source.CommandParser;

namespace Lab4.Tests.CommandMocks;

public class ShowFileCommandMock : Command
{
    public ICollection<string> Attributes { get; private set; } = new List<string>();

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["file", "show", _])
        {
            Attributes.Add(split[2]);
        }
        else if (split is ["file", "show", _, "-m", "console"])
        {
            Attributes.Add(split[2]);
        }
        else
        {
            base.Execute(command);
        }
    }
}