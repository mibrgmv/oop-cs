using Lab3.Source.Entities;
using Lab3.Source.Logging;

namespace Lab3.Tests.Mocks;

public class MockLogger : AddresseeDecorator
{
    public MockLogger(Addressee addressee)
        : base(addressee)
    { }

    public int EventCounter { get; private set; }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        EventCounter++;
    }
}
