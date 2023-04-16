namespace buying_inventory;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Buying Inventory";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        // Ask for the customers name
        Console.Write("What is your name? ");
        string name = Console.ReadLine().ToLower();

        // Display menu
        Console.WriteLine("The following items are available: ");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");

        // Get user input
        int choice = AskForNumberInRange("What number do you want to see the price of?", 1, 7);
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
        else if (name == "antonio")
        {
            // Its you! Get a 50% discount!
            float discountedPrice = Convert.ToSingle(item[1]) / 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Its my favorite customer! You get 50 percent off everything!");
            Console.WriteLine($"{item[0]} costs {discountedPrice:#.#} gold.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{item[0]} costs {item[1]} gold.");
        }

        int AskForNumberInRange(string text, int min, int max)
        {
            int input;
            do
            {
                Console.Write($"{text} ");
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < min || input > max);
            return input;
        }
    }
}
