Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Exepti's Game");

Random random = new Random();

// Game will select a random number from 0-9
int raisinCookieTarget = random.Next(10);
Console.WriteLine($"Selected number is {raisinCookieTarget}");

string player = "One";
List<int> numbers = new List<int>();

try
{
    while (true)
    {
        int guess;
        do
        {
            Console.Write($"Player {player}, please guess a number from 0-9: ");
        } while (!int.TryParse(Console.ReadLine(), out guess));

        if (numbers.Contains(guess))
        {
            Console.WriteLine($"Number {guess} has already been used.");
        }
        else if (guess == raisinCookieTarget)
        {
            throw new Exception($"Player {player} selected the oatmeal raisin cookie!");
        }
        else
        {
            numbers.Add(guess);
            if (player == "One")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                player = "Two";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                player = "One";
            }
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
    

