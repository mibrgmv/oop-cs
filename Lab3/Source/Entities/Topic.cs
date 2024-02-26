using Lab3.Source.Models;

namespace Lab3.Source.Entities;

public class Topic
{
    public Topic(Name name, Addressee addressee)
    {
        Name = name;
        Addressee = addressee;
    }

    public Name Name { get; private set; }
    public Addressee Addressee { get; private set; }

    public void SendMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        Addressee.ReceiveMessage(message);
    }
}