namespace hunting_the_manticore;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        const string title = "Hunting the Manticore";
        Console.Title = title;
        Console.WriteLine(title);

        // Initial state
        int healthManticore = 10;
        int healthCity = 15;
        int round = 1;

        // Player 1
        int enemyDistance = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore?", 0, 100);
        Console.Clear();

        // Player 2
        Console.WriteLine("Player 2, it is your turn.");

        // Game loop
        while (healthManticore > 0 && healthCity > 0)
        {
            int damage = Damage(round);

            // Display status
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"STATUS: Round: {round} City: {healthCity}/15 Manticore: {healthManticore}/10");
            Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

            // Prompt player
            int cannonRange = AskForNumber("Enter desired cannon range:");

            // Calculate results
            if (cannonRange == enemyDistance)
            {
                // Direct hit
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("That round was a DIRECT HIT!");
                healthManticore -= damage;
            }
            else
            {
                // Player missed
                Console.ForegroundColor = ConsoleColor.Red;
                if (cannonRange > enemyDistance) Console.WriteLine("That round OVERSHOT the target.");
                else Console.WriteLine("That round FELL SHORT of the target.");
                healthCity--;
            }

            // End of round
            round++;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        // Game ended
        if (healthManticore <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The city of Consolas has been destroyed by the Manticore!");
        }

        int Damage(int round)
        {
            bool isFire = round % 3 == 0;
            bool isElectric = round % 5 == 0;

            // Determine damage based on the round number
            if (isFire && isElectric) return 10;
            else if (isFire || isElectric) return 3;
            else return 1;
        }

        int AskForNumber(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{text} ");
            return Convert.ToInt32(Console.ReadLine());
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
