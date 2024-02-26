using Lab4.Source.Entities;

namespace Lab4.Source.CommandParser.ConnectionCommands;

public class DisconnectCommand : Command
{
    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["disconnect"])
        {
            FileSystem.Disconnect();
        }
        else
        {
            base.Execute(command);
        }
    }
}