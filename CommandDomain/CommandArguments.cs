using System.Text;

namespace BusyBoxEmulator;

public class CommandArguments
{
    private readonly List<string> _splittedCommand;
    private string _command;
    private bool _containsQuotes = false;
    private bool _inQuotes = false;

    public CommandArguments(string command)
    {
        _command = command;
        _splittedCommand = command.Split(" ").ToList();
    }

    public string GetCommandName()
    {
        return _splittedCommand[0];
    }

    public List<string> ArgumentList()
    {
        CommandCheck();
        return StringSplit(_splittedCommand).Skip(1).ToList();
    }

    private List<string> StringSplit(List<string> list)
    {
        StringBuilder sb = new StringBuilder();
        List<string> result = new List<string>();
        int count = 0;

        foreach (string s in list)
        {
            if (s == "\"\"")
            {
                continue;
            }

            if (s.Contains("\""))
            {
                _inQuotes = !_inQuotes;
                count += 1;
            }

            if (count == 2)
            {
                sb.Append(s);
                result.Add(sb.ToString().Trim());
                sb.Clear();
                count = 0;
                continue;
            }

            if (_inQuotes)
            {
                sb.Append(s + " ");
            }
            else
            {
                result.Add(s);
            }
        }

        return result;
    }

    private void CommandCheck()
    {
        int count = 0;

        foreach (string s in _splittedCommand)
        {
            if (s.Contains("\""))
            {
                count += 1;
            }
        }

        if (count > 2)
            throw new ArgumentException("Неккоректный ввод. Кавычек должно быть ровно две штуки.");
    }
}