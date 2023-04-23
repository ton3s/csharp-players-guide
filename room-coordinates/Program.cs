// Setup the console
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Room Coordinates");

Coordinates c1 = new Coordinates { Row = 1, Column = 1 };
c1.IsAdjacent(1, 2);
c1.IsAdjacent(2, 2);

Coordinates c2 = new Coordinates { Row = 2, Column = 2 };
c2.IsAdjacent(3, 3);
c2.IsAdjacent(3, 2);
c2.IsAdjacent(2, 1);

public struct Coordinates
{
    public int Row { get; init; }
    public int Column { get; init; }

    public bool IsAdjacent(int row, int column)
    {
        bool isAjacent = false;

        // If row is the same
        if (Row == row)
        {
            if (column == (Column + 1) || column == (Column - 1))
            {
                isAjacent = true;
            }
        }
        else if (Column == column)
        {
            if (row == (Row + 1) || row == (Row - 1))
            {
                isAjacent = true;
            }
        }

        // Display results
        if (isAjacent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{Display(row, column)}] is adjacent to [{Display(Row, Column)}]");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{Display(row, column)}] is NOT adjacent to [{Display(Row, Column)}]");
        }
        return isAjacent;
    }

    private string Display(int row, int column)
    {
        return $"Row: {row}, Column: {column}";
    }
}



