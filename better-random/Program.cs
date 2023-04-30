Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Better Random");

Random random = new Random();
Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("cat", "dog", "bird"));
Console.WriteLine(random.CoinFlip(0.01f));

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max)
    {
        return random.NextDouble() * max;
    }

    public static string NextString(this Random random, params string[] strings)
    {
        return strings[random.Next(strings.Length)];
    }

    public static bool CoinFlip(this Random random, float headsPercent = 0.5f)
    {
        return random.NextDouble() <= headsPercent ? true : false;
    }
}