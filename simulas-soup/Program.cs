namespace simulas_soup;

enum Type { Soup, Stew, Gumbo };
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes };
enum Seasoning { Spicy, Salty, Sweet };

class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("Simula's Soup!");

        // Prompt user
        // Type
        Type type;
        string input;
        do {
            input = Ask("Type (Soup, Stew, Gumbo):"); 
        } while (!Enum.TryParse<Type>(input, out type)); 

        // Ingredient
        Ingredient ingredient;
        do {
            input = Ask("Ingredient (Mushrooms, Chicken, Carrots, Potatoes):");
        } while (!Enum.TryParse<Ingredient>(input, out ingredient)); 

        // Seasoning
        Seasoning seasoning;
        do {
            input = Ask("Seasoning (Spicy, Salty, Sweet):"); 
        } while (!Enum.TryParse<Seasoning>(input, out seasoning)); 

        // Initialize tuple
        ( Type, Ingredient, Seasoning ) soup = (type, ingredient, seasoning);

        Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}");

        string Ask(string text)
        {
            Console.Write($"{text} ");
            return Console.ReadLine();
        }
    }
}
