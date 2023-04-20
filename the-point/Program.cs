namespace the_point;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Entering the Catacombs");
        
        // Points
        Console.ForegroundColor = ConsoleColor.Yellow;
        Point p1 = new Point(2, 3);
        Point p2 = new Point(-4, 0);
        Point p3 = new Point();

        displayPoint(p1);
        displayPoint(p2);
        displayPoint(p3);

        void displayPoint(Point p)
        {
            Console.WriteLine($"({p.X}, {p.Y})");
        }
    }

    public class Point {
        public float X { get; }
        public float Y { get; }

        public Point() : this(0, 0) {}

        public Point(float x, float y) {
            X = x;
            Y = y;
        }
    }
}
