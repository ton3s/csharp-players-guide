Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Navigating Operand City");

// Test operators
BlockCoordinate bc = new BlockCoordinate(4, 3);

// Add block offset
BlockOffset bo = new BlockOffset(2, 0);
Console.WriteLine(bo + bc);
Console.WriteLine(bc + bo);

// Add direction
Direction direction = Direction.East;
Console.WriteLine(bc + direction);
Console.WriteLine(direction + bc);

public record BlockCoordinate(int Row, int Column)
{
    // BlockCoordinate + BlockOffset
    public static BlockCoordinate operator +(BlockCoordinate bc, BlockOffset bo)
        => new BlockCoordinate(bc.Row + bo.RowOffset, bc.Column + bo.ColumnOffset);
    public static BlockCoordinate operator +(BlockOffset bo, BlockCoordinate bc)
        => new BlockCoordinate(bc.Row + bo.RowOffset, bc.Column + bo.ColumnOffset);

    // BlockCoordinate + Direction
    public static BlockCoordinate operator +(BlockCoordinate bc, Direction direction)
    {
        return direction switch
        {
            Direction.North => bc with { Row = bc.Row - 1 },
            Direction.South => bc with { Row = bc.Row + 1 },
            Direction.East => bc with { Column = bc.Column + 1},
            Direction.West => bc with { Column = bc.Column - 1 }
        };       
    }
    public static BlockCoordinate operator +(Direction direction, BlockCoordinate bc)
    {
        return direction switch
        {
            Direction.North => bc with { Row = bc.Row - 1 },
            Direction.South => bc with { Row = bc.Row + 1 },
            Direction.East => bc with { Column = bc.Column + 1 },
            Direction.West => bc with { Column = bc.Column - 1 }
        };
    }

}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, South, East, West }
