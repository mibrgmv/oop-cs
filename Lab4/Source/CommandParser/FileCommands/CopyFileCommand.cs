using Lab4.Source.Entities;

namespace Lab4.Source.CommandParser.FileCommands;

public class CopyFileCommand : Command
{
    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["file", "copy", _, _])
        {
            FileSystem.CopyFile(split[2], split[3]);
        }
        else
        {
            base.Execute(command);
        }
    }
}