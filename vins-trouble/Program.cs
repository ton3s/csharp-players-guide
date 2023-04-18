namespace vins_trouble;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("Vin's Trouble");

        // Instantiate an Arrow based on the users responses
        Arrow arrow = GetArrow();

        // Display cost
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"A {arrow.GetArrowHead().ToString().ToLower()} arrow head with {arrow.GetFletching().ToString().ToLower()} fletching and a shaft length of {arrow.GetLength()} costs {arrow.GetCost()} gold.");

        Arrow GetArrow() => new Arrow(GetArrowHead(), GetFletching(), GetLength());
        
        ArrowHead GetArrowHead() {
            // Arrow Head
            ArrowHead arrowHead;
            string input;
            do {
                input = Ask("Arrow Head (Steel, Wood, Obsidian):");
            } while (!Enum.TryParse<ArrowHead>(input, out arrowHead)); 
            return arrowHead;
        }

        Fletching GetFletching() {
            // Fletching
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
        private ArrowHead _arrowHead;
        private Fletching _fletching;
        private int _length;

        public Arrow(ArrowHead arrowHead, Fletching fletching, int length) {
            _arrowHead = arrowHead;
            _fletching = fletching;
            _length = length;
        }
        
        public string GetArrowHead() => _arrowHead.ToString();
        public string GetFletching() => _fletching.ToString();
        public int GetLength() => _length;

        public float GetCost() {
            float cost = 0f;

            // Arrow Head
            cost += _arrowHead switch {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5
            };

            // Fletching
            cost += _fletching switch {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            // Length
            cost += _length * 0.05f;

            return cost;
        }
    }

    enum ArrowHead { Steel, Wood, Obsidian };
    enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
}

