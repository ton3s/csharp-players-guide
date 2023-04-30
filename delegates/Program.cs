Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Delegates");

var results = ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, MultiplyTwo);

foreach (int result in results)
{
    Console.WriteLine(result);
}


// Delegate methods
int AddOne(int number) => number + 1;
int MultiplyTwo(int number) => number * 2;

int[] ChangeArrayElements(int[] numbers, Func<int, int> operation)
{
    int[] result = new int[numbers.Length];
    for (int index = 0; index < result.Length; index++)
        result[index] =  operation.Invoke(numbers[index]);
    return result;
}