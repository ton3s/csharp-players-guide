// The Fountain of Objects
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The Fountain of Objects");

GameManager gameManager = new GameManager();
gameManager.StartGame();

public class GameManager
{
    private RoomsManager RoomsManager { get; }
    private Player Player { get; }

    public GameManager()
    {
        RoomsManager = new RoomsManager();
        Player = new Player(new Position(0, 0));
    }

    public void StartGame()
    {
        RoomsManager.GetStatus();
    }
}


public class RoomsManager
{
    Room[,] Rooms { get; }

    public RoomsManager()
    {
        // Setup rooms
        Rooms = new Room[4, 4];
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                Rooms[row, column] = new Room(new Position(row, column));
            }
        }
    }

    public void GetStatus()
    {
        for (int row = 0; row < Rooms.GetLength(0); row++)
        {
            for (int column = 0; column < Rooms.GetLength(1); column++)
            {
                Console.WriteLine(Rooms[row, column].GetDescription());
            }
        }
    }
}

public class Room
{
    public Position Position { get; }

    public Room(Position position)
    {
        Position = position;
    }

    public string? GetDescription()
    {
        return Position.ToString();
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
        Console.Write("What do you want to do? ");
        return Console.ReadLine();
    }
}

public record Position(int Row, int Column);

