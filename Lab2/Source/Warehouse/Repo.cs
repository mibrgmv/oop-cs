namespace Lab2.Source.Warehouse;

public abstract class Repo<T>
{
    public abstract IReadOnlyCollection<T> Stock { get; }

    public abstract T? FindItem(string name);
    public abstract T GetItem(string name);
    public abstract void AddItem(T item);
}
