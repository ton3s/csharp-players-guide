
// Setup the console
Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Packing Inventory");

// Setup items
Sword sword = new Sword();
Bow bow = new Bow();
Rope rope = new Rope();

// Setup Pack
Pack pack = new Pack(2, 10, 10);

// Prompt user
string input;
do {
    Console.Write("What item would you like to add to the pack? (sword, bow, rope, arrow, water, food, q): ");
    input = Console.ReadLine() ?? "q";
    switch (input)
    {
        case "sword":
            pack.Add(new Sword());
            break;
        case "bow":
            pack.Add(new Bow());
            break;
        case "rope":
            pack.Add(new Rope());
            break;
        case "arrow":
            pack.Add(new Arrow());
            break;
        case "water":
            pack.Add(new Water());
            break;
        case "food":
            pack.Add(new FoodRations());
            break;
        case "q":
            Console.WriteLine("Quitting...");
            break;
        default:
            Console.WriteLine("Invalid option specified.");
            break;
    }
    pack.displayPackContents();
} while (input != "q");


// Classes
public class InventoryItem {
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }  
}

public class Pack
{
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    public InventoryItem[] Items { get; private set; }
    public int ItemsCount { get; private set; } = 0;
    public float Weight { get; private set; } = 0;
    public float Volume { get; private set; } = 0;

    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        Items = new InventoryItem[MaxItems];
    }

    public bool Add(InventoryItem item)
    {
        // Check if there is space in the pack
        if (ItemsCount == Items.Length)
        {
            Console.WriteLine($"Pack cannot carry any more items. [{MaxItems}]");
            return false;
        }

        // Check if there is enough weight
        if ((item.Weight + Weight) > MaxWeight)
        {
            Console.WriteLine($"Adding the item will exceed the max weight limit. [{MaxWeight}]");
            return false;
        }

        // Check if there is enough volume
        if ((item.Volume + Volume) > MaxVolume)
        {
            Console.WriteLine($"Adding the item will exceed the max volume limit. [{MaxVolume}]");
            return false;
        }

        // Add the item to the pack
        Items[ItemsCount] = item;

        // Increment counters
        ItemsCount += 1;
        Weight += item.Weight;
        Volume += item.Volume;
        return true;
    }

    public void displayPackContents()
    {
        Console.WriteLine("----------");
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] != null)
            {
                Console.WriteLine($"{i}: {Items[i].GetType()}");
            }
        }
        Console.WriteLine($"Stats: items: {ItemsCount}/{MaxItems}, weight:  {Weight}/{MaxWeight}, volume: {Volume}/{MaxVolume}");
        Console.WriteLine("----------");
    }
}

// Arrow
// Bow
// Rope
// Water
// Food Rations
// Sword

public class Arrow: InventoryItem
{
  public Arrow(): base(0.1f, 0.05f) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, 0.5f) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
}