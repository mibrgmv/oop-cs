using Lab3.Source.Entities;

namespace Lab3.Source.MessengerService;

public class Messenger : Addressee, IMessenger
{
    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Messages.Add(message);
    }

    public void PrintMessage()
    {
        Console.WriteLine("[Messenger]\n" + Messages.Last());
    }
}