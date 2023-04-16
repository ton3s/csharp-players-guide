namespace taking_a_number;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Taking a Number";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        int AskForNumber(string text)
        {
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
