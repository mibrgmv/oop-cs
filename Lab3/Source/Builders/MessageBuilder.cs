using Lab3.Source.Entities;
using Lab3.Source.Exceptions.MessageBuilderExceptions;
using Lab3.Source.Models;

namespace Lab3.Source.Builders;

public class MessageBuilder
{
    private Text? _title;
    private Text? _body;
    private Priority _priority = Priority.Low;

    public MessageBuilder BuildTitle(string title)
    {
        _title = new Text(title);
        return this;
    }

    public MessageBuilder BuildBody(string body)
    {
        _body = new Text(body);
        return this;
    }

    public MessageBuilder BuildPriority(Priority priority)
    {
        _priority = priority;
        return this;
    }

    public Message Build()
    {
        if (_title is null)
            throw new MessageBuilderException("Cannot Build Message Without Title");
        if (_body is null)
            throw new MessageBuilderException("Cannot Build Message Without Body");
        return new Message(_title, _body, _priority);
    }
}