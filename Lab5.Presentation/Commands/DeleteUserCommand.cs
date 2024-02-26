using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Presentation.Commands;

public class DeleteUserCommand : Command
{
    private IUserRepository _userRepository;

    public DeleteUserCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override void Execute(string command)
    {
        if (command == null)
            throw new ArgumentException("Command To Execute Cannot Be Null");
        string[] split = command.Split(" ");
        if (split is ["delete", "user", _, _, _])
        {
            _userRepository.DeleteUser(
                Convert.ToInt32(split[2], null),
                split[3],
                split[4]);
        }
        else
        {
            base.Execute(command);
        }
    }
}