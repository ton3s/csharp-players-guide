Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Colored Items");

ColoredItem<Sword> sword = new ColoredItem<Sword> { Color = ConsoleColor.Blue };
sword.Display();

ColoredItem<Bow> bow = new ColoredItem<Bow> { Color = ConsoleColor.Red };
bow.Display();

ColoredItem<Axe> axe = new ColoredItem<Axe> { Color = ConsoleColor.Green };
axe.Display();

public class Sword { }

public class Bow { }

public class Axe { }

public class ColoredItem<T> where T: new()
{
    public T Item { get; } = new T();
    public ConsoleColor Color { get; init; }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);
    }
}