namespace Lab3.Source.Entities;

public abstract class Addressee
{
    public ICollection<Message> Messages { get; private set; } = new List<Message>();
    public abstract void ReceiveMessage(Message message);
}