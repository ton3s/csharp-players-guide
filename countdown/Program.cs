namespace countdown;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Countdown";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        int number = AskForNumber("Enter a number to countdown from:");
        Countdown(number);

        void Countdown(int number)
        {
            Console.WriteLine(number);
            if (number == 1) return;
            Countdown(number - 1);
        }

        int AskForNumber(string text)
        {
            Console.Write($"{text} ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
