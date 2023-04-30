Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The Sieve");

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;

Console.WriteLine("Please select a filter: ");
Console.WriteLine("1 - Is Even");
Console.WriteLine("2 - Is Positive");
Console.WriteLine("3 - Is Multiplier of Ten");
string? input = Console.ReadLine();

Sieve sieve = input switch
{
    "1" => new Sieve(IsEven),
    "2" => new Sieve(IsPositive),
    "3" => new Sieve(IsMultipleOfTen)
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