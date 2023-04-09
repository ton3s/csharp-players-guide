namespace defense_of_consolas;
class Program
{
    static void Main(string[] args)
    {
        // Set console display
        Console.Title = "The Defense of Consolas";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
      
        Console.Write("Target Row? ");
        int row = Convert.ToInt32(Console.ReadLine());

        Console.Write("Target Column? ");
        int col = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Deploy to:");

        // Display Results
        Console.Beep(); 

        // Left
        Console.WriteLine($"({row}, {col-1})");
        // Top
        Console.WriteLine($"({row+1}, {col})");
        // Right
        Console.WriteLine($"({row}, {col+1})");
        // Bottom
        Console.WriteLine($"({row-1}, {col})");
    }
}
