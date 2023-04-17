namespace HelloWorld;

enum Season { Winter, Spring, Summer, Fall }

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Season current = Season.Winter;
        Console.WriteLine(current);

        var score = GetScore(); 
        Console.WriteLine(score.N);

        DisplayScore(score);

        (string N, int P, int L) GetScore() => ("R2-D2", 12420, 15);

        void DisplayScore((string Name, int Points, int Level) score)
        {
            Console.WriteLine($"Name:{score.Name} Level:{score.Level} Score:{score.Points}");
        }
    }
}
