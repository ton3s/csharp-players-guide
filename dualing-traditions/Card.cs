namespace the_card;

partial class Program
{
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
}
