using System.Text;

namespace BusyBoxEmulator;

public class MkdirCommand : Command
{
    public MkdirCommand(Environment environment) : base("mkdir", "Создает директорию в папке, в которой вы сейчас находитесь", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        List<string> arguments = command.ArgumentList();
        StringBuilder errorList = new StringBuilder();
        foreach (string argument in arguments)
        {
            if (Directory.Exists(environment.CurrentPath + argument) || File.Exists(environment.CurrentPath + argument))
            {
                errorList.Append(argument + " ");
                continue;
            }

            Directory.CreateDirectory(environment.CurrentPath + argument);
        }

        if (errorList.Length > 0)
        {
            throw new ArgumentException($"Папки с данными названиями уже существуют: {errorList}");
        }
        return "";
    }
}