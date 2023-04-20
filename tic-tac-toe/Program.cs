using static tic_tac_toe.Program;

namespace tic_tac_toe;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Tic Tac Toe");

        // Setup Game Manager
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }

    public class GameManager
    {
        Player _playerX, _playerO;
        Board _board;
        Player _currentPlayer;

        public GameManager()
        {
            _playerX = new Player(PlayerSymbol.X);
            _playerO = new Player(PlayerSymbol.O);
            _board = new Board();

            // Default first turn to 'X'
            _currentPlayer = _playerX;
        }

        public void StartGame()
        {
            // Setup game loop
            do
            {
                SetupConsole();

                Console.WriteLine($"It is {_currentPlayer.Symbol}'s turn.");
                Console.WriteLine(_currentPlayer.GetMove());

                // Switch current player
                SwitchPlayer();

            } while (true);

        }

        private void SwitchPlayer() => _currentPlayer = _currentPlayer == _playerX ? _playerO : _playerX;

        private void SetupConsole()
        {
            if (_currentPlayer == _playerX)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }

    public class Board
    {

    }

    public class Player
    {
        public PlayerSymbol Symbol { get; init; }

        public Player(PlayerSymbol symbol)
        {
            Symbol = symbol;
        }

        public int GetMove()
        {
            return Util.AskForNumberInRange("What square do you want to play in?", 1, 9);
        }
    }

    public class Util
    {
        public static int AskForNumberInRange(string text, int min, int max)
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
    public enum PlayerSymbol { X, O };
}
