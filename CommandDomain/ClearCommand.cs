namespace BusyBoxEmulator;

public class ClearCommand : Command
{
    public ClearCommand(Environment environment) : base("clear", "Очищает консоль", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        Console.Clear();
        return "";
    }
}