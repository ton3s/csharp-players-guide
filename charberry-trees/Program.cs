Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Charberry Trees");

CharberryTree tree = new CharberryTree();
new Notifier(tree);
new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class Notifier
{
    public CharberryTree Tree { get; }
    private int _count = 0;

    public Notifier(CharberryTree tree)
    {
        Tree = tree;
        Tree.Ripened += OnRipened;
    }

    public void OnRipened()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"[Notifier] A charberry fruit has ripened! [{_count}]");
        _count++;
    }
}

public class Harvester
{
    public CharberryTree Tree { get; }
    private int _count = 0;

    public Harvester(CharberryTree tree)
    {
        Tree = tree;
        Tree.Ripened += OnRipened;
    }

    public void OnRipened()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[Harvester] Harvesting charberry fruit! [{_count}]");
        Tree.Ripe = false;
        _count++;
    }
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

