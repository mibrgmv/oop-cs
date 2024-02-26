using Lab3.Source.Entities;

namespace Lab3.Source.DisplayService;

public class Display : Addressee, IDisplay
{
    private IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Messages.Clear();
        Messages.Add(message);
    }

    public void ColoredDisplay()
    {
        Console.ForegroundColor = _displayDriver.Color;
        _displayDriver.WriteText("Title: " + Messages.Last().Title.Value);
        _displayDriver.WriteText("Body: " + Messages.Last().Body.Value);
        Console.ForegroundColor = ConsoleColor.White;
    }
}