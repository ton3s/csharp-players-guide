using System;

namespace the_laws_of_freach;
class Program
{
    static void Main(string[] args)
    {
        Console.Title = "The Laws of Freach";

        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;

        int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

        // Compute the smallest value
        int currentSmallest = int.MaxValue; // Start higher than anything in the array.
        foreach (int value in array)
        {
            if (value < currentSmallest)
                currentSmallest = value;
        }
        Console.WriteLine($"Smallest: {currentSmallest}");

        // Compute the average value
        int total = 0;
        foreach (int value in array) { 
            total += value;
        }
        float average = (float)total / array.Length;
        Console.WriteLine($"Average: {average}");
    }
}
