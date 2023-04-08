namespace dominion_of_kings;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Dominion of Kings");

        // Point value for each holding type
        const int ESTATE = 1;
        const int DUCHY = 3;
        const int PROVINCE = 6;

        Console.WriteLine("How many estates do you own?");
        int estateCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How many duchys do you own?");
        int duchyCount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How many provinces do you own?");
        int provinceCount = Convert.ToInt32(Console.ReadLine());

        int pointTotal = (estateCount * ESTATE) + (duchyCount * DUCHY) + (provinceCount * PROVINCE);
        Console.WriteLine("Total points: " + pointTotal);
    }
}
