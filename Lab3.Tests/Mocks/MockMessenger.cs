using Lab3.Source.Entities;
using Lab3.Source.MessengerService;

namespace Lab3.Tests.Mocks;

public class MockMessenger : Addressee, IMessenger
{
    public int MessageCounter { get; private set; }
    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Messages.Add(message);
    }

    public void PrintMessage()
    {
        MessageCounter++;
    }
}
