namespace the_color;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("The Color");

        Color customColor = new Color { R = 128, G = 255, B = 0 };
        Color green = Color.Green();
        
        displayColor(customColor);
        displayColor(green);

        void displayColor(Color c)
        {
            Console.WriteLine($"({c.R}, {c.G}, {c.B})");
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
