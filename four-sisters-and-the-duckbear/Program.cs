namespace four_sisters_and_the_duckbear;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Four Sisters and the Duckbear");
        Console.WriteLine("How many eggs were gathered today?");
        int eggsGathered = Convert.ToInt32(Console.ReadLine());

        int numberOfSisters = 4;
        int eggsPerSister = eggsGathered / numberOfSisters;
        int eggsForDuckbear = eggsGathered % numberOfSisters;

        Console.WriteLine("Eggs gathered: " + eggsGathered);
        Console.WriteLine("Eggs per Sister: " + eggsPerSister);
        Console.WriteLine("Eggs for Duckbear: " + eggsForDuckbear);
    }
}
