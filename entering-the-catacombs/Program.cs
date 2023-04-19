namespace entering_the_catacombs;
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

        void displayPoint(Point p) {
            Console.WriteLine($"({p.X}, {p.Y})");
        }

        // Color
        Console.ForegroundColor = ConsoleColor.Magenta;
        Color customColor = new Color { R = 128, G = 255, B = 0 };
        Color green = Color.Green();
        
        displayColor(customColor);
        displayColor(green);

        void displayColor(Color c) {
            Console.WriteLine($"({c.R}, {c.G}, {c.B})");
        }
    }

    // Classes
    public class Point {
        public float X { get; }
        public float Y { get; }

        public Point() : this(0, 0) {}

        public Point(float x, float y) {
            X = x;
            Y = y;
        }
    }

    public class Color {
        public int R { get; init; }
        public int G { get; init; }
        public int B { get; init; }

        public Color(): this(0, 0, 0) {}

        public Color(int r, int g, int b) {
            R = r;
            G = g;
            B = b;
        }

        public static Color White() => new Color(255, 255, 255);
        public static Color Black() => new Color(0, 0, 0); 
        public static Color Red() => new Color(255, 0, 0);
        public static Color Orange() => new Color(255, 165, 0);
        public static Color Yellow() => new Color(255, 255, 0);
        public static Color Green() => new Color(0, 128, 0);
        public static Color Blue() => new Color(0, 0, 255);
        public static Color Purple() => new Color(128, 0, 128);
    }
}
