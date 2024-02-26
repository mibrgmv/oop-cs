using Lab4.Source.Exceptions.FileSystemExceptions;

namespace Lab4.Source.Entities;

public static class FileSystem
{
    private static string? _currentDirectory;
    private static string? _fileEmoji;
    private static string? _directoryEmoji;
    private static ILogger? _logger;

    public static void SetLogger(ILogger logger)
    {
        _logger = logger;
    }

    public static void SetEmojis(string fileEmoji, string directoryEmoji)
    {
        _fileEmoji = fileEmoji ?? throw new ArgumentException("File Emoji Cannot Be Null");
        _directoryEmoji = directoryEmoji ?? throw new ArgumentException("Directory Emoji Cannot Be Null");
    }

    public static void Connect(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Cannot Connect With Null/Empty Path");
        if (!Directory.Exists(path))
        {
            _logger?.Log("Trying To Connect With Invalid Path");
            return;
        }

        _currentDirectory = path;
    }

    public static void Disconnect()
    {
        _currentDirectory = null;
    }

    public static void ShowFile(string filePath)
    {
        if (_currentDirectory == null)
            return;
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File Path Cannot Be Null Or Empty");
        if (File.Exists(filePath))
            Console.WriteLine(File.ReadAllText(filePath));
        else if (File.Exists(_currentDirectory + filePath))
            Console.WriteLine(File.ReadAllText(_currentDirectory + filePath));
        else
            _logger?.Log("Cannot Show - Invalid Path");
    }

    public static void MoveFile(string sourcePath, string destinationPath)
    {
        if (_currentDirectory == null)
            return;
        if (string.IsNullOrEmpty(sourcePath))
            throw new ArgumentException("Source Path Cannot Be Null Or Empty");
        if (string.IsNullOrEmpty(destinationPath))
            throw new ArgumentException("Destination Path Cannot Be Null Or Empty");
        if (File.Exists(destinationPath))
            throw new OccupiedDestinationException("Destination Already Occupied");
        if (File.Exists(sourcePath))
            File.Move(sourcePath, destinationPath);
        else if (File.Exists($@"{_currentDirectory}{sourcePath}"))
            File.Move($@"{_currentDirectory}{sourcePath}", $@"{_currentDirectory}{destinationPath}");
        else
            _logger?.Log("Cannot Move - Cannot Find Source Path");
    }

    public static void CopyFile(string sourcePath, string destinationPath)
    {
        if (_currentDirectory == null)
            return;
        if (string.IsNullOrEmpty(sourcePath))
            throw new ArgumentException("Source Path Cannot Be Null Or Empty");
        if (string.IsNullOrEmpty(destinationPath))
            throw new ArgumentException("Destination Path Cannot Be Null Or Empty");
        if (File.Exists(sourcePath))
            File.Copy(sourcePath, destinationPath);
        else if (File.Exists($@"{_currentDirectory}{sourcePath}"))
            File.Copy($@"{_currentDirectory}{sourcePath}", $@"{_currentDirectory}{destinationPath}");
        else
            _logger?.Log("Cannot Copy - Cannot Find Files");
    }

    public static void RenameFile(string filePath, string newName)
    {
        MoveFile(filePath, newName);
    }

    public static void DeleteFile(string filePath)
    {
        if (_currentDirectory == null)
            return;
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File Path Cannot Be Null Or Empty");
        if (File.Exists(filePath))
            File.Delete(filePath);
        else if (File.Exists(_currentDirectory + filePath))
            File.Delete(_currentDirectory + filePath);
        else
            _logger?.Log("Cannot Delete - Cannot Find File");
    }

    public static void GotoTree(string path)
    {
        if (_currentDirectory == null)
            return;
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path Cannot Be Null Or Empty");
        if (Directory.Exists(_currentDirectory + path))
            _currentDirectory += path;
        else if (Directory.Exists(path))
            _currentDirectory = path;
        else
            _logger?.Log("Cannot Goto Nonexistent Directory");
    }

    public static void ListTree(int depth = 1, int index = 0, DirectoryInfo? directory = null)
    {
        if (_currentDirectory == null)
            return;
        if (depth <= 0 || index == depth)
            return;
        directory ??= new DirectoryInfo(_currentDirectory);
        if (index == 0)
        {
            Console.Write(_fileEmoji);
            Console.WriteLine(directory.Name);
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            for (int i = 0; i < index + 1; ++i)
                Console.Write("  ");
            Console.Write(_directoryEmoji);
            Console.WriteLine(subDirectory.Name);
            foreach (FileInfo file in directory.GetFiles())
            {
                for (int i = 0; i < index + 2; ++i)
                    Console.Write("  ");
                Console.Write(_fileEmoji);
                Console.WriteLine(file.Name);
            }

            ListTree(depth, index + 1, subDirectory);
        }
    }
}