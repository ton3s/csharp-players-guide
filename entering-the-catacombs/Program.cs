namespace entering_the_catacombs;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Entering the Catacombs");
        
        // Points
        Console.ForegroundColor = ConsoleColor.Yellow;
        Point p1 = new Point(2, 3);
        Point p2 = new Point(-4, 0);
        Point p3 = new Point();

        displayPoint(p1);
        displayPoint(p2);
        displayPoint(p3);

        void displayPoint(Point p)
        {
            Console.WriteLine($"({p.X}, {p.Y})");
        }

        // Colors
        Console.ForegroundColor = ConsoleColor.Magenta;
        Color customColor = new Color { R = 128, G = 255, B = 0 };
        Color green = Color.Green();
        
        displayColor(customColor);
        displayColor(green);

        void displayColor(Color c)
        {
            Console.WriteLine($"({c.R}, {c.G}, {c.B})");
        }

        // Cards
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string[] cardRanks = Enum.GetNames(typeof(CardRank));
        string[] cardColors = Enum.GetNames(typeof(CardColor));
        Card[] deck = new Card[cardColors.Length * cardRanks.Length];
        int cardCount = 0;

        // Create each card and add to the desk
        for (int i = 0; i < cardColors.Length; i++)
        {
            for (int j = 0; j < cardRanks.Length; j++)
            {
                // Convert string to enum
                CardColor cardColor = (CardColor)Enum.Parse(typeof(CardColor), cardColors[i], true);
                CardRank cardRank = (CardRank)Enum.Parse(typeof(CardRank), cardRanks[j], true);
                Card card = new Card(cardColor, cardRank);
                deck[cardCount] = card;
                cardCount++;
            }
        }

        // Display all the cards in the deck
        displayCards(deck);
       
        void displayCards(Card[] deck)
        {
            foreach (Card card in deck)
            {
                Console.WriteLine($"The {card.Color} {card.Rank}");
            }
        }
    }

    // Classes
    public class Point {
        public float X { get; }
        public float Y { get; }

        public Point() : this(0, 0) {}

        public Point(float x, float y) {
            X = x;
            Y = y;
        }
    }

    public class Color {
        public int R { get; init; }
        public int G { get; init; }
        public int B { get; init; }

        public Color(): this(0, 0, 0) {}

        public Color(int r, int g, int b) {
            R = r;
            G = g;
            B = b;
        }

        public static Color White() => new Color(255, 255, 255);
        public static Color Black() => new Color(0, 0, 0); 
        public static Color Red() => new Color(255, 0, 0);
        public static Color Orange() => new Color(255, 165, 0);
        public static Color Yellow() => new Color(255, 255, 0);
        public static Color Green() => new Color(0, 128, 0);
        public static Color Blue() => new Color(0, 0, 255);
        public static Color Purple() => new Color(128, 0, 128);
    }

    public class Card
    {
        public CardColor Color { get; init; }
        public CardRank Rank { get; init; }
        public bool IsSymbol { get; } = false;

        public Card(CardColor color, CardRank rank)
        {
            Color = color;
            Rank = rank;

            switch (rank) {
                case CardRank.Dollar:
                case CardRank.Percent:
                case CardRank.Carat:
                case CardRank.Ambersand:
                    IsSymbol = true;
                    break;
            }
        }
    }

    public class Door {
        private int _pin;
        private DoorState _doorState;

        public Door(int pin) {
            _pin = pin;
            _doorState = DoorState.Locked;
        }

        public void Open() {
            if (_doorState == DoorState.Closed) _doorState = DoorState.Open;
        }

        public void Close() {
            if (_doorState == DoorState.Open) _doorState = DoorState.Closed;
        }

        public void Lock() {
            if (_doorState == DoorState.Closed) _doorState = DoorState.Locked;
        }

        public void Unlock(int pin) {
            if (_doorState == DoorState.Locked && pin == _pin) _doorState = DoorState.Closed;
        }

        public void ChangePin(int oldPin, int newPin) {
            if (_pin == oldPin) _pin = newPin;
        }

        public void displayStatus() {
            Console.WriteLine($"Door is in a {_doorState} state.");
        }
    }

    public enum CardColor { Red, Green, Blue, Yellow };
    public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Carat, Ambersand };
    public enum DoorState { Open, Closed, Locked }
}