namespace HelloWorld;

enum Season { Winter, Spring, Summer, Fall }

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Season current = Season.Winter;
        Console.WriteLine(current);
    }
}
