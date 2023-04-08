namespace the_triangle_farmer;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Triangle Farmer");
        Console.WriteLine("What is the triangle's base size?");
        int baseSize = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("What is the triangle's height?");
        int height = Convert.ToInt32(Console.ReadLine());

        int area = baseSize * height / 2;
        Console.WriteLine("The area of the triange with a base size of " + baseSize + " and a height of " + height + " is " + area);
    }
}
