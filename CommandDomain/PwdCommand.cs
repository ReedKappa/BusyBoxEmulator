namespace BusyBoxEmulator;

public class PwdCommand : Command
{
    public PwdCommand(Environment environment) : base("pwd", "Выводит на экран текущую дерикторию", environment)
    {
    }

    public override string Perform(CommandArguments command)
    {
        return environment.CurrentPath;
    }
}