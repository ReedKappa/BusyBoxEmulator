namespace BusyBoxEmulator;

public class LsCommand : Command
{
    public LsCommand(Environment environment) : base("ls", "Отображает на экране содержимое текущей дериктории", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        
        bool haveArguments = command.ArgumentList().Count > 0;
        bool isMainDirectory = environment.CurrentPath == environment.MainDirectory;
        List<string> result = new List<string>();
        List<string> list = new List<string>();
        string temp;
        
        string s = environment.CurrentPath;
        list = Directory.GetFileSystemEntries(s).ToList();
        foreach (string s1 in list)
        {
            if (s1.Split("\\").Last() == ".TRASHBIN" && isMainDirectory && haveArguments) continue;
            temp = s1.Split("\\").Last();
            if (!haveArguments && temp.StartsWith('.')) continue;
            result.Add(temp);
        }
        return String.Join("\n", result);
    }
}