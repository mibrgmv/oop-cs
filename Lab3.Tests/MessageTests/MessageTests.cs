using Lab3.Source.Builders;
using Lab3.Source.Entities;
using Lab3.Source.Exceptions.MessageExceptions;
using Lab3.Source.Models;
using Lab3.Tests.Mocks;
using Xunit;

namespace Lab3.Tests.MessageTests;

public class MessageTests
{
    [Fact]
    public void UserReceivesMessageTest()
    {
        User user = new(new Name("Antoha"));
        Message message = new MessageBuilder()
            .BuildTitle("Lets have a coffee")
            .BuildBody("Wanna get a coffee? Give me a ring")
            .Build();
        Topic topic = new(new Name("Coffee"), user);

        topic.SendMessage(message);

        Assert.DoesNotContain(user, message.ReadBy);
    }

    [Fact]
    public void MarkAsReadTestSuccess()
    {
        User user = new(new Name("Antoha"));
        Message message = new MessageBuilder()
            .BuildTitle("Lets have a coffee")
            .BuildBody("Wanna get a coffee? Give me a ring")
            .Build();
        Topic topic = new(new Name("Coffee"), user);

        topic.SendMessage(message);
        message.Read(user);

        Assert.Contains(user, message.ReadBy);
    }

    [Fact]
    public void MarkAsReadTestFailure()
    {
        User user = new(new Name("Antoha"));
        Message message = new MessageBuilder()
            .BuildTitle("Lets have a coffee")
            .BuildBody("Wanna get a coffee? Give me a ring")
            .Build();
        Topic topic = new(new Name("Coffee"), user);

        topic.SendMessage(message);
        message.Read(user);

        MessageException messageException = Assert.Throws<MessageException>(() => message.Read(user));
        Assert.Equal("Message Already Read By User", messageException.Message);
    }

    [Fact]
    public void FilterTest()
    {
        User user = new(new Name("Antoha"));
        Message message = new MessageBuilder()
            .BuildTitle("Lets have a coffee")
            .BuildBody("Wanna get a coffee? Give me a ring")
            .Build();
        AddresseeProxy userProxy = new(user);
        userProxy.EnableFilter(Priority.High);
        Topic topic = new(new Name("Coffee"), userProxy);

        topic.SendMessage(message);

        Assert.DoesNotContain(message, user.Messages);
    }

    [Fact]
    public void LoggerTest()
    {
        User user = new(new Name("Antoha"));
        Message message1 = new MessageBuilder()
            .BuildTitle("Lets have a coffee")
            .BuildBody("Wanna get a coffee? Give me a ring")
            .Build();
        Message message2 = new MessageBuilder()
            .BuildTitle("Where are you?")
            .BuildBody("It's 10:40, why aren't you at your desk?")
            .Build();
        MockLogger loggedUser = new(user);
        Topic topic = new(new Name("Inbox"), loggedUser);

        topic.SendMessage(message1);
        topic.SendMessage(message2);

        Assert.True(loggedUser.EventCounter == 2);
    }

    [Fact]
    public void MessengerTest()
    {
        MockMessenger messenger = new();
        Message message1 = new MessageBuilder()
            .BuildTitle("Anybody wanna hang out?")
            .BuildBody("Anybody down to go get a bite or something?")
            .Build();
        Message message2 = new MessageBuilder()
            .BuildTitle("Where is everybody?")
            .BuildBody("We were supposed to meet at 10 sharp! Where y'all at?")
            .Build();
        Topic topic = new(new Name("Meetup"), messenger);

        topic.SendMessage(message1);
        messenger.PrintMessage();
        topic.SendMessage(message2);
        messenger.PrintMessage();

        Assert.True(messenger.MessageCounter == 2);
    }
}
