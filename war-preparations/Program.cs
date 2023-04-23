// Setup the console
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("War Preparations");

Sword s1 = new Sword(Material.Iron, Gem.None, 50f, 10f);
Sword s2 = s1 with { Material = Material.Bronze, Width = 10f };
Sword s3 = s1 with { Material = Material.Binarium, Gem = Gem.Bitstone, Length = 90f };

Console.WriteLine(s1.ToString());
Console.WriteLine(s2.ToString());
Console.WriteLine(s3.ToString());

public record Sword(Material Material, Gem Gem, float Length, float Width);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gem { Emerald, Amber, Sapphire, Diamond, Bitstone, None }