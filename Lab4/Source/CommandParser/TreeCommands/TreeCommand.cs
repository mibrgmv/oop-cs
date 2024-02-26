namespace Lab4.Source.CommandParser.TreeCommands;

public class TreeCommand : Command
{
    private ListTreeCommand _listTreeCommand = new();
    private GotoTreeCommand _gotoTreeCommand = new();

    public TreeCommand()
    {
        _listTreeCommand.SetNextCommand(_gotoTreeCommand);
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split[0] == "tree")
        {
            _listTreeCommand.Execute(command);
        }
        else
        {
            base.Execute(command);
        }
    }
}