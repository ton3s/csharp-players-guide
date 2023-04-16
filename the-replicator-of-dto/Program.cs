namespace the_replicator_of_dto;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "The Replicator of D'To";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        // Create an array with a length of 5
        int[] numbers = new int[5];

        // Ask user for numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("A number between 1 and 100: ");
            int input = Convert.ToInt32(Console.ReadLine());
            numbers[i] = input;
        }

        // Make a copy of the original array above
        int[] numbersCopy = new int[5];
        for (int i = 0; i < numbersCopy.Length; i++)
        {
            numbersCopy[i] = numbers[i];
        }

        // Display the contents of both arrays
        DisplayArrayContents(numbers);
        DisplayArrayContents(numbersCopy);
    }

    static void DisplayArrayContents(int[] array)
    {
        Console.WriteLine("== Displaying contents of array ==");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}
