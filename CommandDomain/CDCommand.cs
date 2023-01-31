namespace BusyBoxEmulator;

public class CDCommand : Command
{
    public CDCommand(Environment environment) : base("cd", "Меняет директорию, в которой вы находитесь", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        List<string> arguments = command.ArgumentList();

        if (arguments.Count > 1)
        {
            throw new ArgumentException("Команда cd принирмает только один аргумент.");
        }

        if (arguments[0] == "..")
        {
            environment.CurrentPath = new DirectoryInfo(environment.CurrentPath).Parent.FullName + "\\";
        }
        else
        {
            FileWalk(arguments[0]);
            environment.CurrentPath = environment.CurrentPath + arguments[0] + "\\";
        }

        return "";
    }

    public bool FileWalk(string directoryName)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(environment.CurrentPath);
        List<string> currentDirectories = directoryInfo.GetDirectories().Select(x => x.Name).ToList();
        if (!currentDirectories.Contains(directoryName))
            throw new ArgumentException("Данная директория не существует.");
        return true;
    }
}