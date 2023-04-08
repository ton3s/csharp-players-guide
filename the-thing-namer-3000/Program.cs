namespace the_thing_namer_3000;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What kind of thing are we talking about?");
        // Get input from user
        string a = Console.ReadLine();
        Console.WriteLine("How would you describe it? Big? Azure? Tattered?"); 
        // Ask the user for something that describes the object
        string b = Console.ReadLine();
        string c = "Doom";
        string d = "3000";
        Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!");
    }
}
