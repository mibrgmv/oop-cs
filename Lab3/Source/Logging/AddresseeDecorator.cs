using Lab3.Source.Entities;

namespace Lab3.Source.Logging;

public class AddresseeDecorator : Addressee
{
    public AddresseeDecorator(Addressee addressee)
    {
        Addressee = addressee;
    }

    public Addressee Addressee { get; protected set; }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Addressee.ReceiveMessage(message);
    }
}