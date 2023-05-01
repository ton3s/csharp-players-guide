Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The Long Game");

// Ask for the username
Console.Write("What is your username? ");
string? username = Console.ReadLine();

// Check if previous score exists
int score = 0;
if (File.Exists($"{username}.txt"))
{
    score = Convert.ToInt32(File.ReadAllText($"{username}.txt"));
}

// Incremet score for each key press
while (!(Console.ReadKey().Key == ConsoleKey.Enter)) {
    score++;
    Console.WriteLine($" - Keys Pressed: {score}");
}

// Write the score in the file
File.WriteAllText($"{username}.txt", score.ToString());
