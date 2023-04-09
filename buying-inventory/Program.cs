namespace buying_inventory;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Buying Inventory";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        // Display menu
        Console.WriteLine("The following items are available: ");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");
        Console.Write("What number do you want to see the price of? ");

        // Get user input
        int choice = Convert.ToInt32(Console.ReadLine());
        string[] item = choice switch
        {
            1 => new string[]{ "Rope", "15" },
            2 => new string[] { "Torches", "15" },
            3 => new string[] { "Climbing Equipment", "24" },
            4 => new string[] { "Clean Water", "2" },
            5 => new string[] { "Machete", "20" },
            6 => new string[] { "Canoe", "200" },
            7 => new string[] { "Food Supplies", "2" },
            _ => new string[]{ "Not Valid" }
        };

        // Check if a valid item was returned
        if (item[0] == "Not Valid") Console.WriteLine("Sorry. A valid choice was not selected");
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{item[0]} costs {item[1]} gold.");
        }
    }
}
