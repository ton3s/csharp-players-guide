namespace the_prototype;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "The Prototype";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Ask user 1
        int numberToGuess = -1;
        do
        {
            Console.Write("User 1, enter a number between 0 and 100: ");
            int input = Convert.ToInt32(Console.ReadLine());
            numberToGuess = input >= 0 && input <= 100 ? input : numberToGuess;
        } while (numberToGuess == -1);

        // Reset console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        // Ask user 2
        Console.WriteLine("User 2, guess the number.");
        int guess;
        do
        {
            Console.Write("What is your next guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
            if (guess > numberToGuess)
            {
                Console.WriteLine($"{guess} is too high.");
            }
            else if (guess < numberToGuess)
            {
                Console.WriteLine($"{guess} is too low.");
            }
            else
            {
                Console.WriteLine($"You guessed the number!");
            }
        } while (guess != numberToGuess);
    }
}
