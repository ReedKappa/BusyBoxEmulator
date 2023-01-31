namespace BusyBoxEmulator;

public abstract class Command
{
    public string Name { get; protected set; } 
    public string Description {  get; protected set; }
    protected Environment environment;

    protected Command(string name, string description, Environment environment)
    {
        Name = name;
        Description = description;
        this.environment = environment;
    }

    public abstract string Perform(CommandArguments command);
}