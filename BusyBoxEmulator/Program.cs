using BusyBoxEmulator;
using Environment = BusyBoxEmulator.Environment;

class Program
{
    static Dictionary<string, Command> _commandPool = new Dictionary<string, Command>();
    static Environment environment = new Environment(System.Environment.CurrentDirectory + "\\");

    static void Main(string[] args)
    {
        string trashbin = Path.Combine(environment.MainDirectory, ".TRASHBIN");
        if (!Directory.Exists(trashbin))
        {
            Directory.CreateDirectory(trashbin);
        }
        
        Init();
        string currentPath;
        while (true)
        {
            if (environment.CurrentPath.Contains(environment.MainDirectory))
            {
                currentPath = environment.CurrentPath.Replace(environment.MainDirectory, "~\\");
            }
            else
            {
                currentPath = environment.CurrentPath;
            }
            Console.Write($"{environment.UserName}@{environment.MachineName}:{currentPath}$ ");
            string s = CommandInvoke(Console.ReadLine());
            Console.WriteLine(s);
        }
    }
    
    

    public static string CommandInvoke(string userInput)
    {
        CommandArguments command = new CommandArguments(userInput);
        string commandName = command.GetCommandName();
        Command currentCommand = _commandPool[commandName];
        return currentCommand.Perform(command);
        ;
    }

    public static void Init()
    {
        RegisterCommand(new CatCommand(environment));
        RegisterCommand(new EchoCommand(environment));
        RegisterCommand(new CDCommand(environment));
        RegisterCommand(new LsCommand(environment));
        RegisterCommand(new ClearCommand(environment));
        RegisterCommand(new MkdirCommand(environment));
        RegisterCommand(new PwdCommand(environment));
        RegisterCommand(new TouchCommand(environment));
    }

    public static void RegisterCommand(Command command)
    {
        _commandPool.Add(command.Name, command);
    }
}