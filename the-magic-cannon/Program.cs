namespace the_magic_cannon;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "The Magic Cannon";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 1; i <= 100; i++)
        {
            bool isFire = i % 3 == 0;
            bool isElectric = i % 5 == 0;

            if (isFire && isElectric)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i}: Electric + Fire");
            }
            else if (isFire)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{i}: Fire");
            }
            else if (isElectric)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i}: Electric");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{i}: Normal");
            }
        }
    }
}
