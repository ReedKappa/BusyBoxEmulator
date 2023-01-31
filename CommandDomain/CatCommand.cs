namespace BusyBoxEmulator;

public class CatCommand : Command
{
    private bool _hasSpaceBar = false;

    public CatCommand(Environment environment) : base("cat", "Выводит на экран содержимое файла", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        List<string> arguments = command.ArgumentList();
        
        if (arguments.Count > 1)
            throw new ArgumentException("Команда cat может принимать только один аргумент.");
        if (!File.Exists(arguments[0]))
            throw new ArgumentException("Данный файл не существует.");

        IEnumerable<string> text = ReadFromFile(arguments[0]);

        return String.Join("\n", text);
    }

    private IEnumerable<string> ReadFromFile(string fileName)
    {
        return File.ReadAllLines(environment.CurrentPath + fileName);
    }
}