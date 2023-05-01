Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The Potion Masters of Pattren");

Potion potion = Potion.Water;

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Potion: {potion}");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Select an ingredient to add: ");
    Console.WriteLine("[1] Star Dust");
    Console.WriteLine("[2] Snake Venom");
    Console.WriteLine("[3] Dragon Breath");
    Console.WriteLine("[4] Shadow Glass");
    Console.WriteLine("[5] Eyeshine Gem");
    int input = Convert.ToInt32(Console.ReadLine());

    Ingredient ingredient = input switch
    {
        1 => Ingredient.StarDust,
        2 => Ingredient.SnakeVenom,
        3 => Ingredient.DragonBreath,
        4 => Ingredient.ShadowGlass,
        5 => Ingredient.EyeshineGem
    };

    potion = ingredient switch
    {
        Ingredient.StarDust when potion == Potion.Water => Potion.Elixir,
        Ingredient.StarDust when potion == Potion.CloudyBrew => Potion.Wraith,
        Ingredient.SnakeVenom when potion == Potion.Elixir => Potion.Poison,
        Ingredient.DragonBreath when potion == Potion.Elixir => Potion.Flying,
        Ingredient.ShadowGlass when potion == Potion.Elixir => Potion.Invisibility,
        Ingredient.ShadowGlass when potion == Potion.NightSight => Potion.CloudyBrew,
        Ingredient.EyeshineGem when potion == Potion.Elixir => Potion.NightSight,
        Ingredient.EyeshineGem when potion == Potion.Invisibility => Potion.CloudyBrew,
        _ => Potion.Ruined
    };

    // Ruined potion
    if (potion == Potion.Ruined)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You ruined your potion. Lets try again!");
        potion = Potion.Water;
    }
    else
    {
        // Complete the potion?
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You just created a {potion} potion!");
        Console.Write("Would you like to continue adding ingredients (Y/n): ");
        if ((Console.ReadLine() ?? "Y") == "n") break;
    }
}

public enum Potion
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined
}

public enum Ingredient
{
    StarDust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem
}