using System;

namespace LR12
{
    internal interface IPlayer
    {
        char Symbol { get; }
        void MakeMove(Board board);
    }

    internal class Player : IPlayer
    {
        public char Symbol { get; }
        
        public Player(char symbol)
        {
            Symbol = symbol;
        }

        public void MakeMove(Board board)
        {
            while (true) {
                Console.Write($"Player {Symbol}, enter your move: ");
                
                int choice;
                
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice < 1 || choice > 9)
                    {
                        Console.WriteLine("Please pick a number from 1 to 9.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }

                var row = (choice - 1) / 3;
                var col = (choice - 1) % 3;

                if (board.PlaceSymbol(row, col, Symbol)) return;

                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

    internal class Board
    {
        private readonly char[,] _grid;

        public Board()
        {
            _grid = new char[3, 3];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            var counter = 0;
            for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                _grid[row, col] = Convert.ToChar((++counter).ToString());
        }

        public void DisplayBoard()
        {
            Console.Clear();
            for (var row = 0; row < 3; row++) {
                for (var col = 0; col < 3; col++) {
                    Console.Write($" {_grid[row, col]} ");
                    if (col < 2) Console.Write("|");
                }

                Console.WriteLine();
                if (row < 2) Console.WriteLine("-----------");
            }
        }

        private bool IsEmpty(int row, int col) => char.IsNumber(_grid[row, col]);

        public bool PlaceSymbol(int row, int col, char symbol)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || !IsEmpty(row, col))
                return false;

            _grid[row, col] = symbol;
            return true;
        }

        public enum GameState { Going, Over, Tie }

        public GameState CheckGameState()
        {
            // Check rows, columns, and diagonals
            for (var i = 0; i < 3; i++) {
                if (!IsEmpty(i, 0) && _grid[i, 0] == _grid[i, 1] && _grid[i, 0] == _grid[i, 2])
                    return GameState.Over;
                if (!IsEmpty(0, i) && _grid[0, i] == _grid[1, i] && _grid[0, i] == _grid[2, i])
                    return GameState.Over;
            }

            if (!IsEmpty(0, 0) && _grid[0, 0] == _grid[1, 1] && _grid[0, 0] == _grid[2, 2])
                return GameState.Over;
            if (!IsEmpty(0, 2) && _grid[0, 2] == _grid[1, 1] && _grid[0, 2] == _grid[2, 0])
                return GameState.Over;

            // Check for a tie
            for (var row = 0; row < 3; row++) {
                for (var col = 0; col < 3; col++) {
                    if (IsEmpty(row, col)) {
                        return GameState.Going;
                    }
                }
            }

            return GameState.Tie; // It's a tie
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            IPlayer playerX = new Player('X');
            IPlayer playerO = new Player('@');
            var currentPlayer = playerX;

            while (true) {
                board.DisplayBoard();
                currentPlayer.MakeMove(board);

                var state = board.CheckGameState();
                if (state != Board.GameState.Going) {
                    board.DisplayBoard();
                    Console.WriteLine("Game over!");
                    Console.WriteLine(state == Board.GameState.Tie
                        ? "It's a tie!"
                        : $"Player {currentPlayer.Symbol} wins!");

                    break;
                }

                currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
            }
        }
    }
}