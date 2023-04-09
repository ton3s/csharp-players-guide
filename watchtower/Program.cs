namespace watchtower;
class Program
{
    static void Main(string[] args)
    {
        // Setup console
        Console.Title = "Watchtower";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("x: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        // Determine enemies location
        string location = "?";
        if (x < 0 && y < 0) location = "SW";
        if (x < 0 && y == 0) location = "W";
        if (x < 0 && y > 0) location = "NW";
        if (x == 0 && y < 0) location = "N";
        if (x == 0 && y == 0) location = "!";
        if (x == 0 && y > 0) location = "S";
        if (x > 0 && y < 0) location = "NE";
        if (x > 0 && y == 0) location = "E";
        if (x > 0 && y > 0) location = "SE";

        if (location == "!")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The enemy is here!");
        }
        else if (location == "?")
        {
            Console.WriteLine("Something went wrong! We couldn't track the enemy!");
        }
        else
        {
            Console.WriteLine($"The enemy is to the {location}!");
        }
    }
}
