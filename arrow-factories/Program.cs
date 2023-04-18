namespace arrow_factories;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Arrow Factories");

        // Prompt user
        Arrow arrow;
        string input;
        do
        {
            input = Ask("What type of arrow would you like (standard, custom):");
        } while (!(input == "standard" || input == "custom"));
        
        if (input == "custom") arrow = GetCustomArrow();
        else arrow = GetStandardArrow();
        
        // Display cost
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"A {arrow.ArrowHead.ToString().ToLower()} arrow head with {arrow.Fletching.ToString().ToLower()} fletching and a shaft length of {arrow.Length} costs {arrow.GetCost()} gold.");

        Arrow GetStandardArrow() 
        {
            do
            {
                input = Ask("What standard arrow would you like (elite, beginner, marksman):");
            } while (!(input == "elite" || input == "beginner" || input == "marksman"));
            return input switch
            {
                "elite" => Arrow.CreateEliteArrow(),
                "beginner" => Arrow.CreateBeginnerArrow(),
                "marksman" => Arrow.CreateMarksmanArrow()
            };
        }

        Arrow GetCustomArrow() => new Arrow { 
            ArrowHead = GetArrowHead(), 
            Fletching = GetFletching(), 
            Length = GetLength() 
        };
        
        ArrowHead GetArrowHead() {
            ArrowHead arrowHead;
            string input;
            do {
                input = Ask("Arrow Head (Steel, Wood, Obsidian):");
            } while (!Enum.TryParse<ArrowHead>(input, out arrowHead)); 
            return arrowHead;
        }

        Fletching GetFletching() {
            Fletching fletching;
            string input;
            do {
                input = Ask("Fletching (Plastic, TurkeyFeathers, GooseFeathers):");
            } while (!Enum.TryParse<Fletching>(input, out fletching)); 
            return fletching;
        }

        int GetLength() {
            int length = AskForNumberInRange("Length between 60 - 100:", 60, 100);
            return length;
        }

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
        public ArrowHead ArrowHead { get; init; }
        public Fletching Fletching { get; init; }
        public int Length { get; init; }

        public static Arrow CreateEliteArrow() => new Arrow
        {
            ArrowHead = ArrowHead.Steel,
            Fletching = Fletching.Plastic,
            Length = 95
        };

        public static Arrow CreateBeginnerArrow() => new Arrow
        {
            ArrowHead = ArrowHead.Wood,
            Fletching = Fletching.GooseFeathers,
            Length = 75
        };

        public static Arrow CreateMarksmanArrow() => new Arrow
        {
            ArrowHead = ArrowHead.Steel,
            Fletching = Fletching.GooseFeathers,
            Length = 65
        };

        public float GetCost() {
            float cost = 0f;

            // Arrow Head
            cost += ArrowHead switch {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5
            };

            // Fletching
            cost += Fletching switch {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            // Length
            cost += Length * 0.05f;
            return cost;
        }
    }

    enum ArrowHead { Steel, Wood, Obsidian };
    enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
}

