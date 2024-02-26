using Lab3.Source.Exceptions.MessageExceptions;
using Lab3.Source.Models;

namespace Lab3.Source.Entities;

public class Message
{
    public Message(Text title, Text body, Priority priority)
    {
        Title = title;
        Body = body;
        Priority = priority;
    }

    public ICollection<User> ReadBy { get; private set; } = new List<User>();
    public Text Title { get; private set; }
    public Text Body { get; private set; }
    public Priority Priority { get; private set; }

    public void Read(User user)
    {
        if (user == null)
            throw new ArgumentException("Invalid Message");
        if (ReadBy.Contains(user))
            throw new MessageException("Message Already Read By User");
        else if (!ReadBy.Contains(user))
            ReadBy.Add(user);
    }
}