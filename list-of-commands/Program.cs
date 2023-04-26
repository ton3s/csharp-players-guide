// Setup the console
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("List of Commands");

Robot robot = new Robot();

// Prompt user for commands then run commands on "stop"
while (true)
{
    string? input = Console.ReadLine();
    if (input == "stop") break;
    if (!String.IsNullOrEmpty(input))
    {
        RobotCommand command = GetRobotCommand(input);
        robot.Commands.Add(command);
    }
} 

robot.RunProgram();

RobotCommand GetRobotCommand(string command) {
    return command switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand()
    };
}

// Classes
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<RobotCommand> Commands { get; } = new List<RobotCommand>();

    public void RunProgram()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[X:{X} Y:{Y} IsPowered:{IsPowered}]");
        }
    }
}

public interface RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand: RobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : RobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : RobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}