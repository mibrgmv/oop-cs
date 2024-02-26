using Lab3.Source.Exceptions.AddresseeExceptions;

namespace Lab3.Source.Entities;

public class AddresseeGroup : Addressee
{
    public ICollection<Addressee> Addressees { get; private set; } = new List<Addressee>();
    public override void ReceiveMessage(Message message)
    {
        if (message == null)
            throw new ArgumentException("Invalid Message");
        foreach (Addressee addressee in Addressees)
            addressee.ReceiveMessage(message);
    }

    public void AddAddressee(Addressee element)
    {
        if (element == null)
            throw new ArgumentException("Invalid Element, Cannot Add");
        if (Addressees.Contains(element))
            throw new AddresseeException("Cannot Add Already Present Addressee");
        Addressees.Add(element);
    }

    public void RemoveAddressee(Addressee element)
    {
        if (element == null)
            throw new ArgumentException("Invalid Element, Cannot Add");
        if (!Addressees.Contains(element))
            throw new AddresseeException("Addressee Has Not Been Added Yet");
        Addressees.Remove(element);
    }
}