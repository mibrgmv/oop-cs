using System.Globalization;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Banking;
using Lab5.Application.Exceptions;
using Lab5.Infrastructure.DataAccess.DataAccessExceptions;
using Lab5.Presentation.Abstractions.ConsoleInterface;
using Lab5.Presentation.ConsoleInterfaceExceptions;
using Spectre.Console;

namespace Lab5.Presentation.ConsoleInterface;

public class UserInterface : IUserInterface
{
    private static readonly string[] Modes = { "Admin", "Customer", "Quit" };
    private static readonly Padding Padding = new Padding(5, 1, 5, 1);
    private string _systemPassword;
    private InputParser _inputParser;

    public UserInterface(string systemPassword, IBankingService bankingService, IUserRepository userRepository, IAccountRepository accountRepository)
    {
        _systemPassword = systemPassword;
        _inputParser = new InputParser(bankingService, userRepository, accountRepository);
    }

    public void Run()
    {
        while (true)
        {
            string mode = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select Operating Mode")
                .AddChoices(Modes));
            switch (mode)
            {
                case "Admin":
                    AdminModeRun();
                    break;
                case "Customer":
                    CustomerModeRun();
                    break;
                case "Quit":
                    return;
            }
        }
    }

    private static void ShowAdminHelp()
    {
        AnsiConsole.Write(new Panel(
                "add user {id} {username} {password}\n" +
                "delete user {id} {username} {password}\n" +
                "add account {number} {user_id} {password}\n" +
                "delete account {number} {user_id} {password}")
            .Header("Available Admin Commands")
            .Padding(Padding)
            .Expand());
    }

    private static void ShowCustomerHelp()
    {
        AnsiConsole.Write(new Panel(
                "put {account number} {password} {amount}\n" +
                "withdraw {account number} {password} {amount}\n" +
                "show balance {account number} {password}")
            .Header("Available Customer Commands")
            .Padding(Padding)
            .Expand());
    }

    private void AdminModeRun()
    {
        while (true)
        {
            string inputPassword = AnsiConsole.Prompt(new TextPrompt<string>("Enter Admin Password:").Secret());
            switch (inputPassword == _systemPassword)
            {
                case true:
                    HandleAdminInput();
                    break;
                case false:
                    AnsiConsole.MarkupLine("[red]Incorrect Admin Password[/]");
                    break;
            }

            break;
        }
    }

    private void CustomerModeRun()
    {
        HandleLogin();
        HandleCustomerInput();
    }

    private void HandleLogin()
    {
        while (true)
        {
            AnsiConsole.WriteLine("Enter Login Information");
            string username = AnsiConsole.Ask<string>("Enter Username:");
            string password = AnsiConsole.Ask<string>("Enter Password:");
            try
            {
                _inputParser.ParseLoginCommand(username + " " + password);
                break;
            }
            catch (InvalidLoginException e)
            {
                AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
            }
            catch (PasswordException e)
            {
                AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
            }
            catch (MissingNextCommandException)
            {
                AnsiConsole.MarkupLine("[red]Incorrect Input Format[/]");
            }
        }
    }

    private void HandleAdminInput()
    {
        while (true)
        {
            string command = AnsiConsole.Ask<string>("Enter Admin Command:");
            switch (command)
            {
                case "\\help" or "\\h":
                    ShowAdminHelp();
                    continue;
                case "\\quit" or "\\q":
                    break;
                case not null:
                    try
                    {
                        _inputParser.ParseAdminCommand(command);
                    }
                    catch (CollisionException e)
                    {
                        AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
                    }
                    catch (NonexistentContentException e)
                    {
                        AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
                    }
                    catch (MissingNextCommandException)
                    {
                        AnsiConsole.MarkupLine("[red]Could Not Perform Command[/]");
                    }
                    catch (FormatException)
                    {
                        AnsiConsole.MarkupLine("[red]Incorrect Command Parameters[/]");
                    }

                    continue;
            }

            break;
        }
    }

    private void HandleCustomerInput()
    {
        while (true)
        {
            string command = AnsiConsole.Ask<string>("Enter Customer Command:");
            switch (command)
            {
                case "\\help" or "\\h":
                    ShowCustomerHelp();
                    continue;
                case "\\quit" or "\\q":
                    break;
                default:
                    try
                    {
                        _inputParser.ParseCustomerCommand(command);
                    }
                    catch (DepositException e)
                    {
                        AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
                    }
                    catch (AccountUserRegistrationException e)
                    {
                        AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
                    }
                    catch (PasswordException e)
                    {
                        AnsiConsole.MarkupLineInterpolated(CultureInfo.InvariantCulture, $"[red]{e.Message}[/]");
                    }
                    catch (MissingNextCommandException)
                    {
                        AnsiConsole.MarkupLine("Could Not Perform Command");
                    }
                    catch (FormatException)
                    {
                        AnsiConsole.MarkupLine("Incorrect Command Parameters");
                    }

                    continue;
            }

            break;
        }
    }
}