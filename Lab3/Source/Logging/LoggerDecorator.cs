using System.Globalization;
using Lab3.Source.Entities;

namespace Lab3.Source.Logging;

public class LoggerDecorator : AddresseeDecorator
{
    public LoggerDecorator(Addressee addressee)
        : base(addressee)
    { }

    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        base.ReceiveMessage(message);
        Console.WriteLine(
            "Message[Title:{0}] Was Sent To {1} At {2}",
            message.Title.Value,
            Addressee.GetType().Name,
            DateTime.Now.ToString("G", new DateTimeFormatInfo()));
    }
}