using Lab4.Source.CommandParser.ConnectionCommands;
using Lab4.Source.CommandParser.FileCommands;
using Lab4.Source.CommandParser.TreeCommands;
using Lab4.Source.Models;

namespace Lab4.Source.CommandParser;

public class Parser
{
    private ConnectCommand _connectCommand = new();
    private DisconnectCommand _disconnectCommand = new();
    private FileCommand _fileCommand = new();
    private TreeCommand _treeCommand = new();

    public Parser()
    {
        _connectCommand
            .SetNextCommand(_disconnectCommand)
            .SetNextCommand(_fileCommand)
            .SetNextCommand(_treeCommand);
    }

    public void Parse(ConsoleCommand command)
    {
        if (command == null)
            throw new ArgumentException("Console Command Cannot Be Null");
        _connectCommand.Execute(command.Value);
    }
}