using System;

namespace repairing_the_clock_tower;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Repairing the Clocktower";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        while (true)
        {
            Console.Write("Enter a number or 'q' to quit: ");
            string input = Console.ReadLine();

            // Break out if the user tries to quit
            if (input.Equals("q"))
            {
                Console.WriteLine("Quitting...");
                break;
            }

            // Check the number
            int number = Convert.ToInt32(input);
            if (number % 2 == 0)
            {
                // Even numbers
                Console.WriteLine("Tick");
            }
            else
            {
                // Odd numbers
                Console.WriteLine("Tock");
            }
        }
    }
}
