namespace the_card;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Card");

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

    public enum CardColor { Red, Green, Blue, Yellow };
    public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Carat, Ambersand };
}
