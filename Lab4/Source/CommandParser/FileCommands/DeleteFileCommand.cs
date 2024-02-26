using Lab4.Source.Entities;

namespace Lab4.Source.CommandParser.FileCommands;

public class DeleteFileCommand : Command
{
    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["file", "delete", _])
        {
            FileSystem.DeleteFile(split[2]);
        }
        else
        {
            base.Execute(command);
        }
    }
}