namespace the_triangle_farmer;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Triangle Farmer");
        int baseSize = AskForNumber("What is the triangle's base size?");
        int height = AskForNumber("What is the triangle's height?");

        int area = baseSize * height / 2;
        Console.WriteLine("The area of the triange with a base size of " + baseSize + " and a height of " + height + " is " + area);
    
        int AskForNumber(string text)
        {
            Console.Write($"{text} ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
