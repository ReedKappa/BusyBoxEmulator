namespace BusyBoxEmulator;

public class Environment
{
    public string CurrentPath { get; internal set; }
    public readonly string MainDirectory;
    public readonly string MachineName;
    public readonly string UserName;

    public Environment(string currentPath)
    {
        CurrentPath = currentPath;
        MainDirectory = currentPath;
        MachineName = System.Environment.MachineName;
        UserName = System.Environment.UserName;
    }
}