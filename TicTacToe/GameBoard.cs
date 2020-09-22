using System;
using System.Linq;

namespace TicTacToe
{
    public class GameBoard
    {
        int[][] board = new[] 
            {                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                            
            };
        private IWinningBoard[] _determinators;

        private IValidator[] _validators;

        public GameBoard(IWinningBoard[] determinators, IValidator[] validators)
        {
            _determinators = determinators;
            _validators = validators;
        }

        public bool IsThisAWin()
        {
            return _determinators.Any(_ => _.IsThisAWin(board));
        }

        public bool IsValid(int[][] board, int x, int y)
        {
            return _validators.All(_ => _.IsValid(board, x, y));
        }

        public void Print()
        {
            Console.WriteLine("Here's the current board:");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    var coords = board[i][j];
                    if (coords == 2)
                    {
                        Console.Write("O ");
                    }
                    else if (coords == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PlayGame()
        {
            for (int i = 0; i < 3; i++)
            {
                var position = GetValidPlayerInput();
                Place(1, position.X, position.Y);
                Console.WriteLine(Constants.MoveAccepted);
                Print();
                EndGame();
            } 
        }
        
        private PlayerInput GetValidPlayerInput()
        {
            int player = 1;
            string token = "X";
            Console.WriteLine("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", player, token);
            var coords = Console.ReadLine();
            if (coords.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(Constants.Quit);
                Environment.Exit(0);
            } 
            if (!coords.UserInputIsValid())
            {
                Console.WriteLine("Incorrect format. Please try again. ");
                return GetValidPlayerInput();
            }
            var position = new PlayerInput(coords);
            if (!IsValid(board, position.X, position.Y))
            {
                return GetValidPlayerInput();
            }
            return position;
        }
        
        public void Place(int player, int x, int y)
        {
                board[x][y] = player;
        }

        private void EndGame()
        {
            if (IsThisAWin())
            {
                Console.Write(Constants.MoveAccepted);
                Console.WriteLine(Constants.IsAWin);
                Environment.Exit(0);
            }
        }
    }
}