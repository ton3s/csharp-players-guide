namespace vin_fletchers_arrows;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("Vin Fletcher's Arrow");

        // Arrow Head
        ArrowHead arrowHead;
        string input;
        do {
            input = Ask("Arrow Head (Steel, Wood, Obsidian):");
        } while (!Enum.TryParse<ArrowHead>(input, out arrowHead)); 

        // Fletching
        Fletching fletching;
        do {
            input = Ask("Fletching (Plastic, TurkeyFeathers, GooseFeathers):");
        } while (!Enum.TryParse<Fletching>(input, out fletching)); 

        int length = AskForNumberInRange("Length between 60 - 100:", 60, 100);

        // Instantiate an Arrow based on the users responses
        Arrow arrow = new Arrow(arrowHead, fletching, length);

        // Display cost
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"A {arrow.arrowHead.ToString().ToLower()} arrow head with {arrow.fletching.ToString().ToLower()} fletching and a shaft length of {arrow.length} costs {arrow.GetCost()} gold.");

        string Ask(string text)
        {
            Console.Write($"{text} ");
            return Console.ReadLine();
        }

        int AskForNumberInRange(string text, int min, int max)
        {
            int input;
            do
            {
                Console.Write($"{text} ");
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < min || input > max);
            return input;
        }
    }

    class Arrow {
        public ArrowHead arrowHead;
        public Fletching fletching;
        public int length;

        public Arrow(ArrowHead arrowHead, Fletching fletching, int length) {
            this.arrowHead = arrowHead;
            this.fletching = fletching;
            this.length = length;
        }
        
        public float GetCost() {
            float cost = 0f;

            // Arrow Head
            cost += this.arrowHead switch {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5
            };

            // Fletching
            cost += this.fletching switch {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            // Length
            cost += length * 0.05f;

            return cost;
        }
    }

    enum ArrowHead { Steel, Wood, Obsidian };
    enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
}
