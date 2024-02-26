namespace Lab2.Source.Entities;

public class Bios
{
    public Bios(string type, int versionYear, ICollection<string> supportedProcessors)
    {
        Type = type;
        VersionYear = versionYear;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; private set; }
    public int VersionYear { get; private set; }
    public ICollection<string> SupportedProcessors { get; private set; }
}