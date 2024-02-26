using Lab3.Source.Models;

namespace Lab3.Source.Entities;

public class User : Addressee
{
    public User(Name name)
    {
        Name = name;
    }

    public Name Name { get; private set; }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Messages.Add(message);
    }
}