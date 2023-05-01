Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("operator Overloading");

Point a = new Point(2, 3);
Point b = new Point(1, 8);

// Addition
Console.WriteLine(a + b);

// Multiplication
Console.WriteLine(a * 2);

public record Point(double X, double Y)
{
    // Add points together
    public static Point operator +(Point a, Point b)
        => new Point(a.X + b.X, a.Y + b.Y);

    // Scalar multiplication
    public static Point operator *(Point p, double scalar)
        => new Point(p.X * scalar, p.Y * scalar);
    public static Point operator *(double scalar, Point p)
        => new Point(p.X * scalar, p.Y * scalar);
}
