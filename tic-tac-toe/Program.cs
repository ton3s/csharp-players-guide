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
        private Player _playerX, _playerO;
        private Board _board;
        private Player _currentPlayer;

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
                _board.DisplayBoard();

                // Get move
                bool isValidMove;
                do
                {
                    int position = _currentPlayer.GetMove();
                    isValidMove = _board.SubmitMove(_currentPlayer, position);
                } while (!isValidMove);

                // Check if a player has won
                if (_board.IsPlayerWin(_currentPlayer.Symbol))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{_currentPlayer.Symbol} WON!");
                    _board.DisplayBoard();
                    break;
                }

                // Check if we have a draw
                if (_board.IsDraw())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"We have a draw.");
                    _board.DisplayBoard();
                    break;
                }

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
        private PlayerSymbol[] _board = new PlayerSymbol[9];

        public Board()
        {
            // Initilize empty gameboard
            for (int i = 0; i < _board.Length; i++) _board[i] = PlayerSymbol.Empty;
        }

        public bool SubmitMove(Player player, int position)
        {
            // Adjust user selection with array position
            int gameIndex = position - 1;

            // Check if the spot is available
            if (_board[gameIndex] == PlayerSymbol.Empty) {
                _board[gameIndex] = player.Symbol;
                return true;
            }
            else
            {
                Console.WriteLine("Sorry that square is already taken.");
                return false;
            }
        }

        public void DisplayBoard()
        {
            Console.WriteLine($" {GetSymbolString(_board[6])} | {GetSymbolString(_board[7])} | {GetSymbolString(_board[8])} ");
            Console.WriteLine($"___+___+___");
            Console.WriteLine($" {GetSymbolString(_board[3])} | {GetSymbolString(_board[4])} | {GetSymbolString(_board[5])} ");
            Console.WriteLine($"___+___+___");
            Console.WriteLine($" {GetSymbolString(_board[0])} | {GetSymbolString(_board[1])} | {GetSymbolString(_board[2])} ");
        }

        public bool IsPlayerWin(PlayerSymbol symbol)
        {
            // Check if we have a winning pattern

            // Rows
            if ((_board[0] == symbol && _board[1] == symbol && _board[2] == symbol) ||
                (_board[3] == symbol && _board[4] == symbol && _board[5] == symbol) ||
                (_board[6] == symbol && _board[7] == symbol && _board[8] == symbol))
                return true;

            // Columns
            if ((_board[0] == symbol && _board[3] == symbol && _board[6] == symbol) ||
                (_board[1] == symbol && _board[4] == symbol && _board[7] == symbol) ||
                (_board[2] == symbol && _board[5] == symbol && _board[8] == symbol))
                return true;

            // Diagonals
            if ((_board[0] == symbol && _board[4] == symbol && _board[8] == symbol) ||
                (_board[2] == symbol && _board[4] == symbol && _board[6] == symbol))
                return true;

            return false;
        }

        public bool IsDraw()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                if (_board[i] == PlayerSymbol.Empty) return false;
            }
            return true;
        }

        private string GetSymbolString(PlayerSymbol symbol)
        {
            return symbol switch
            {
                PlayerSymbol.X => "X",
                PlayerSymbol.O => "O",
                _ => " "
            };
        }
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
    public enum PlayerSymbol { X, O, Empty };
}
