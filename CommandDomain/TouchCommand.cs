using System.Text;

namespace BusyBoxEmulator;

public class TouchCommand : Command
{
    public TouchCommand(Environment environment) : base("touch", "Создает файлы в текущей директории", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        List<string> arguments = command.ArgumentList();
        StringBuilder errorSb = new StringBuilder();

        foreach (string argument in arguments)
        {
            if (File.Exists(environment.CurrentPath + argument))
            {
                errorSb.Append(argument + " ");
                continue;
            }

            File.Create(environment.CurrentPath + argument);
        }

        if (errorSb.Length > 0)
        {
            throw new ArgumentException($"Файлы с данными названиями уже существуют: {errorSb}");
        }

        return "";
    }
}