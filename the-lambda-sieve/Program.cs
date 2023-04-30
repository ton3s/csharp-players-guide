Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The Lambda Sieve");

Console.WriteLine("Please select a filter: ");
Console.WriteLine("1 - Is Even");
Console.WriteLine("2 - Is Positive");
Console.WriteLine("3 - Is Multiplier of Ten");
string? input = Console.ReadLine();

Sieve sieve = input switch
{
    "1" => new Sieve(n => n % 2 == 0),
    "2" => new Sieve(n => n > 0),
    "3" => new Sieve(n => n % 10 == 0)
};

// Ask user to test the delegate
while (true)
{
    int numberToTest = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{sieve.IsGood(numberToTest)}");
}

public class Sieve
{
    private Predicate<int> _operation;

    public Sieve(Predicate<int> operation)
    {
        _operation = operation;
    }

    public bool IsGood(int number) => _operation.Invoke(number);
}