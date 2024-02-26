using Lab4.Tests.CommandMocks;
using Xunit;

namespace Lab4.Tests.ConsoleCommandParserTests;

public class ConsoleCommandParserTests
{
    [Fact]
    public void FileShowArgumentTest()
    {
        string command = "file show [path]";
        ShowFileCommandMock showFileCommandMock = new();

        showFileCommandMock.Execute(command);

        Assert.Contains("[path]", showFileCommandMock.Attributes);
    }

    [Fact]
    public void TreeListArgumentTest()
    {
        string command = "tree list";
        ListTreeCommandMock listTreeCommandMock = new();

        listTreeCommandMock.Execute(command);

        Assert.Empty(listTreeCommandMock.Attributes);
    }

    [Fact]
    public void TreeListFlagArgumentTest()
    {
        string command = "tree list -d [Depth]";
        ListTreeCommandMock listTreeCommandMock = new();

        listTreeCommandMock.Execute(command);

        Assert.Contains("[Depth]", listTreeCommandMock.Attributes);
    }
}