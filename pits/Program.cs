// The Fountain of Objects
Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("Pits");

GameManager gameManager = new GameManager();
gameManager.StartGame();

public class GameManager
{
    private RoomsManager? RoomsManager { get; set; }
    private Player Player { get; set; }
    private bool _isFountainActivated = false;
    private Position _entrancePosition = new Position(0, 0);
    private Position _fountainPosition = new Position(0, 2);

    public GameManager()
    {
        Player = new Player(_entrancePosition);
    }

    public void StartGame()
    {
        // Query player for world size
        int worldSize = Player.GetWorldSize();
        RoomsManager = new RoomsManager(new WorldSize(worldSize, worldSize), _entrancePosition, _fountainPosition);
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={Player.Position.Row}, Column={Player.Position.Column})");
            if (IsGameOver()) break;
            RoomsManager.DisplayRoomStatus(Player.Position);
            string action = Player.GetAction();
            ProcessAction(action);
        } while (true);
    }

    private bool IsGameOver()
    {
        if (_isFountainActivated
            && Player.Position.Row == _entrancePosition.Row
            && Player.Position.Column == _entrancePosition.Column)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou Win!");
            return true;
        }
        return false;
    }

    private void ProcessAction(string action)
    {
        // Process movement
        switch (action)
        {
            case "move north":
                if (Player.Position.Row == 0) DisplayEndOfMapErrorMessage();
                else Player.Position = Player.Position with { Row = Player.Position.Row - 1 };
                break;

            case "move south":
                if (Player.Position.Row == RoomsManager.WorldSize.NumRows - 1) DisplayEndOfMapErrorMessage();
                else Player.Position = Player.Position with { Row = Player.Position.Row + 1 };
                break;

            case "move east":
                if (Player.Position.Column == RoomsManager.WorldSize.NumCols - 1) DisplayEndOfMapErrorMessage();
                else Player.Position = Player.Position with { Column = Player.Position.Column + 1 };
                break;

            case "move west":
                if (Player.Position.Column == 0) DisplayEndOfMapErrorMessage();
                else Player.Position = Player.Position with { Column = Player.Position.Column - 1 };
                break;

            case "enable fountain":
                // Check if we are in the fountain room
                Room room = RoomsManager.GetRoom(Player.Position);
                if (room.GetType().ToString() == "Fountain")
                {
                    ((Fountain)room).IsFountainActivated = true;
                    _isFountainActivated = true;
                }
                else
                {
                    DisplayErrorMessage("Sorry. You can only perform this action in the fountain room.");
                }
                break;
        }

        void DisplayErrorMessage(string error)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = prevColor;
        }

        void DisplayEndOfMapErrorMessage() => DisplayErrorMessage("Sorry. You cannot moved in this direction!");
    }
}

public class RoomsManager
{
    public Room[,] Rooms { get; }
    public WorldSize WorldSize { get; }

    public RoomsManager(WorldSize worldSize, Position entrance, Position fountain)
    {
        WorldSize = worldSize;

        // Setup rooms
        Rooms = new Room[WorldSize.NumRows, WorldSize.NumCols];
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                if (row == entrance.Row && column == entrance.Column)
                {
                    // Entrance
                    Rooms[row, column] = new Entrance(new Position(row, column));
                }
                else if (row == fountain.Row && column == fountain.Column)
                {
                    // Fountain
                    Rooms[row, column] = new Fountain(new Position(row, column));
                }
                else
                {
                    // Empty Room
                    Rooms[row, column] = new Room(new Position(row, column));
                }
            }
        }
    }

    public void DisplayRoomStatus(Position position)
    {
        string? description = Rooms[position.Row, position.Column].GetDescription();
        if (description != null) Console.WriteLine(description);
    }

    public Room GetRoom(Position position) => Rooms[position.Row, position.Column];
}

public class Room
{
    public Position Position { get; }

    public Room(Position position)
    {
        Position = position;
    }

    public virtual string? GetDescription() => null;
}

public class Entrance : Room
{
    public Entrance(Position position) : base(position) { }

    public override string GetDescription()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        return "You see light coming from the cavern entrance.";
    }
}

public class Fountain : Room
{
    public bool IsFountainActivated { get; set; }

    public Fountain(Position position) : base(position)
    {
        IsFountainActivated = false;
    }

    public override string GetDescription()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        return IsFountainActivated
            ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
            : "You hear water dripping in this room. The Fountain of Objects is here!";
    }
}

public class Player
{
    public Position Position { get; set; }

    public Player(Position position)
    {
        Position = position;
    }

    public string GetAction()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("What do you want to do? ");
        return Console.ReadLine();
    }

    public int GetWorldSize()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Would size game would you like to play? (small, medium, large): ");
        string input = Console.ReadLine();
        return input switch
        {
            "small" => 4,
            "medium" => 6,
            "large" => 8
        };
    }
}

public record Position(int Row, int Column);
public record WorldSize(int NumRows, int NumCols);

