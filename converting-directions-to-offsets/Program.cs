Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Converting Directions to Offsets");

BlockOffset b = Direction.South;
Console.WriteLine(b);

public record BlockOffset(int RowOffset, int ColumnOffset)
{
    // Convert direction => block offset
    public static implicit operator BlockOffset(Direction d)
        => d switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.West => new BlockOffset(0, -1)
        };
}
public enum Direction { North, South, East, West }