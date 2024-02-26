using Lab3.Source.Models;

namespace Lab3.Source.Entities;

public class AddresseeProxy : Addressee
{
    private Addressee _addressee;
    private Priority _priority;

    public AddresseeProxy(Addressee addressee)
    {
        _addressee = addressee;
    }

    public void EnableFilter(Priority priority)
    {
        _priority = priority;
    }

    public void DisableFilter()
    {
        _priority = Priority.Low;
    }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        if (message.Priority >= _priority)
            _addressee.ReceiveMessage(message);
    }
}