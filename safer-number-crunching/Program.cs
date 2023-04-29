Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Safer Number Crunching");

int intResult;
do
{
    Console.Write("Please enter a valid integer: ");
} while (!int.TryParse(Console.ReadLine(), out intResult));
Console.WriteLine($"The is valid int: {intResult}");

double doubleResult;
do
{
    Console.Write("Please enter a valid double: ");
} while (!double.TryParse(Console.ReadLine(), out doubleResult));
Console.WriteLine($"The is valid double: {doubleResult}");

bool boolResult;
do
{
    Console.Write("Please enter a boolean: ");
} while (!bool.TryParse(Console.ReadLine(), out boolResult));
Console.WriteLine($"The is valid boolean: {boolResult}");