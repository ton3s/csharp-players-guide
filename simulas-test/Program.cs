namespace simulas_test;

enum ChestState { Open, Closed, Locked }

class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        const string title = "Simula's Test";
        Console.Title = title;
        Console.WriteLine(title);

        ChestState chestState = ChestState.Locked;

        while (true) {
            Console.Write($"This chest is {chestState}. What do you want to do? ");
            string transition = Console.ReadLine();

            switch (chestState) {
                case ChestState.Locked: {
                    if (transition == "unlock") chestState = ChestState.Closed;
                    break;
                }
                case ChestState.Closed: {
                    if (transition == "open") chestState = ChestState.Open;
                    else if (transition == "lock") chestState = ChestState.Locked;
                    break;
                }
                case ChestState.Open: {
                    if (transition == "close") chestState = ChestState.Closed;
                    break;
                }
            }
        }
    }
}
