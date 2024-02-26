using Lab4.Source.Entities;

namespace Lab4.Source.CommandParser.FileCommands;

public class RenameFileCommand : Command
{
    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["file", "rename", _, _])
        {
            FileSystem.RenameFile(split[2], split[3]);
        }
        else
        {
            base.Execute(command);
        }
    }
}