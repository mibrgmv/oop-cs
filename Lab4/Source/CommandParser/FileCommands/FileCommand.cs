namespace Lab4.Source.CommandParser.FileCommands;

public class FileCommand : Command
{
    private ShowFileCommand _showFileCommand = new();
    private CopyFileCommand _copyFileCommand = new();
    private MoveFileCommand _moveFileCommand = new();
    private DeleteFileCommand _deleteFileCommand = new();
    private RenameFileCommand _renameFileCommand = new();

    public FileCommand()
    {
        _showFileCommand
            .SetNextCommand(_copyFileCommand)
            .SetNextCommand(_moveFileCommand)
            .SetNextCommand(_deleteFileCommand)
            .SetNextCommand(_renameFileCommand);
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split[0] == "file")
        {
            _showFileCommand.Execute(command);
        }
        else
        {
            base.Execute(command);
        }
    }
}