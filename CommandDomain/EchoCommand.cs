using System.IO.Enumeration;
using System.Reflection.PortableExecutable;

namespace BusyBoxEmulator;

public class EchoCommand : Command
{
    public EchoCommand(Environment environment) : base("echo", "Выводит текст в консоль", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        List<string> arguments = command.ArgumentList();
        
        if (WriteToFile(arguments, ">", File.WriteAllText) || WriteToFile(arguments, ">>",File.AppendAllText))
        {
            return "";
        }
        else
        {
            return String.Join(" ", arguments);
        }
    }

    private string GetFileName(List<string> list, string separator)
    {
        int index = list.IndexOf(separator);
        if (list.LastIndexOf(separator) != index) 
            throw new ArgumentException("Ошибка ввода, стрелка(двойная стрелка) может быть только в одном количестве.");
        
        if (index == list.Count - 1) 
            throw new ArgumentException("Ошибка ввода, вы не ввели название файла.");
        
        return String.Join(" ", list.Skip(index + 1));
    }

    private bool WriteToFile(List<string> list, string separator, Action<string, string> action)
    {
        if (list.Contains(separator))
        {
            string fileName = GetFileName(list, separator);
            IEnumerable<string> value = list.Take(list.IndexOf(separator));
            action(environment.CurrentPath + fileName, String.Join(" ", value));
            return true;
        }
        
        return false;
    }
}