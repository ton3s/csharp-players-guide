// The Fountain of Objects
using System.Data.Common;

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

    // Room locations
    private Position _entrancePosition = new Position(0, 0);
    private Position _fountainPosition = new Position(0, 2);
    private Position[] _pitPositions;

    public GameManager()
    {
        Player = new Player(_entrancePosition);
    }

    public void StartGame()
    {
        // Query player for world size
        int worldSize = Player.GetWorldSize();
        _pitPositions = GetPitPositions(worldSize);

        RoomsManager = new RoomsManager(
            new WorldSize(worldSize, worldSize),
            _entrancePosition,
            _fountainPosition,
            _pitPositions);

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={Player.Position.Row}, Column={Player.Position.Column})");
            if (IsGameOver()) break;
            RoomsManager.DisplayRoomStatus(Player.Position);
            ProcessAction(Player.GetAction());
        } while (true);
    }

    private bool IsGameOver()
    {
        // Player won
        if (_isFountainActivated
            && Player.Position.Row == _entrancePosition.Row
            && Player.Position.Column == _entrancePosition.Column)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou Win!");
            return true;
        }

        // Pits
        foreach (Position pit in _pitPositions)
        {
            if (Player.Position.Row == pit.Row && Player.Position.Column == pit.Column)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh No! You have fallen into the deadly pit.");
                return true;
            }
        }

        return false;
    }

    private Position[] GetPitPositions(int worldSize)
    {
        return worldSize switch
        {
            4 => new Position[] { new Position(1, 2) },
            6 => new Position[] { new Position(1, 2), new Position(1, 0) },
            8 => new Position[] { new Position(1, 2), new Position(1, 0), new Position(1, 3) }
        };
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
    public Position[] Pits { get; }

    public RoomsManager(WorldSize worldSize, Position entrance, Position fountain, Position[] pits)
    {
        WorldSize = worldSize;
        Pits = pits;

        // Setup rooms
        Rooms = new Room[WorldSize.NumRows, WorldSize.NumCols];
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                // Empty Room
                Rooms[row, column] = new Room(new Position(row, column));
            }
        }

        // Entrance
        Rooms[entrance.Row, entrance.Column] = new Entrance(entrance);

        // Fountain
        Rooms[fountain.Row, fountain.Column] = new Fountain(fountain);

        // Pits
        foreach (Position pit in pits)
        {
            Rooms[pit.Row, pit.Column] = new Pit(pit);
        }
        
    }

    public void DisplayRoomStatus(Position position)
    {
        string? description = Rooms[position.Row, position.Column].GetDescription();
        if (description != null) Console.WriteLine(description);

        // Check if there is a pit room adjacent
        bool isAdjacent = false;
        foreach (Position pitPos in Pits)
        {
            Pit pit = (Pit)GetRoom(pitPos);
            if (pit.IsAdjacent(position)) isAdjacent = true;
        }
        if (isAdjacent)
        {
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        }
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

    public bool IsAdjacent(Position position)
    {
        bool isAjacent = false;

        // Check the row above
        if ((Position.Row - 1) == position.Row)
        {
            if (position.Column == Position.Column
                || position.Column == (Position.Column + 1)
                || position.Column == (Position.Column - 1)) isAjacent = true;
        }
        // Same Row
        else if (Position.Row == position.Row)
        {
            if (position.Column == (Position.Column + 1)
                || position.Column == (Position.Column - 1)) isAjacent = true;
        }
        // Bottom Row
        else if ((Position.Row + 1) == position.Row)
        {
            if (position.Column == Position.Column
                || position.Column == (Position.Column + 1)
                || position.Column == (Position.Column - 1)) isAjacent = true;
        }
        return isAjacent;
    }
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

public class Pit : Room
{
    public Pit(Position position) : base(position) { }
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

