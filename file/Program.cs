Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("The File Class");

// Check if the file exists to read the message from last time
if (File.Exists("message.txt"))
{
    string previous = File.ReadAllText("message.txt");
    Console.WriteLine($"Last time the message was: {previous}");
}

Console.Write("What do you want to tell me next time? ");
string? message = Console.ReadLine();

File.WriteAllText("message.txt", message);