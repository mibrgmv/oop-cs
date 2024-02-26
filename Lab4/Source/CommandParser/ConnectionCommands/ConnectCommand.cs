using Lab4.Source.Entities;

namespace Lab4.Source.CommandParser.ConnectionCommands;

public class ConnectCommand : Command
{
    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["connect", _, "-m", "local"])
        {
            FileSystem.Connect(split[1]);
        }
        else
        {
            base.Execute(command);
        }
    }
}