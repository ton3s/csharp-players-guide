Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Monster Scoring");

// Main
Dragon dragon = new Dragon(DragonType.Blue, LifePhase.Wyrnling);
Snake snake = new Snake(4);
Orc orc = new Orc(new Sword(SwordType.LongSword));

Console.WriteLine($"Dragon: {ScoreFor(dragon)}");
Console.WriteLine($"Snake: {ScoreFor(snake)}");
Console.WriteLine($"Orc: {ScoreFor(orc)}");

int ScoreFor(Monster monster)
{
    return monster switch
    {
        Snake { Length: >= 5 } => 5,
        Snake s when s.Length >= 10 => 10,
        Snake => 3,
        Dragon { LifePhase: LifePhase.Ancient or LifePhase.Adult } => 250,
        Dragon => 50,
        Orc { Sword.Type: SwordType.LongSword } => 25,
        _ => 5
    }; ;
}

// Monsters
public abstract record Monster();

public record Skeleton(): Monster;
public record Snake(double Length): Monster;

public record Dragon(DragonType Type, LifePhase LifePhase): Monster;
public enum DragonType { Black, Green, Red, Blue, Gold }
public enum LifePhase { Wyrnling, Young, Adult, Ancient }

public record Orc(Sword Sword): Monster;
public record Sword(SwordType Type);
public enum SwordType { WoodenStick, ArmingSword, LongSword }

