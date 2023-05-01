Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Indexing Operand City");

BlockCoordinate bc = new BlockCoordinate(2, 3);
Console.WriteLine($"Row: {bc[0]} Column: {bc[1]}");
Console.WriteLine($"Row: {bc.Row} Column: {bc.Column}");

public record BlockCoordinate(int Row, int Column)
{
    public int this[int index]
    {
        get => index == 0 ? Row : Column;
    }
}