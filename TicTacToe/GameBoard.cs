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

        public bool IsThisAWin()
        {
            return _determinators.Any(_ => _.IsThisAWin(board));
        }

        public void PlayGame()
        {
            for (int i = 0; i < 3; i++)
            {
                var position = GetPlayerInput();
                
                Place(1, position.X, position.Y);
                Print();
                EndGame();
            }
            
        }

        private PlayerInput GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            if (coords.Equals("q", StringComparison.CurrentCultureIgnoreCase))
                Environment.Exit(0);
            if (!coords.UserInputIsValid())
            {
                Console.WriteLine("Incorrect format. Please try again. ");
                return GetPlayerInput();
            }
            var position = new PlayerInput(coords);
            if (!IsValid(board, position.X, position.Y))
            {
                return GetPlayerInput();
            }
            return position;
        }
        
        public void Place(int player, int x, int y)
        {
                board[x][y] = player;
        }
        public bool IsOccupied(int x, int y)// no longer required
        {
            return board[x][y] != 0;
        }

        private void EndGame()
        {
            // logic:
            // if this is a win
            // write message
            // end game
            if (IsThisAWin())
            {
                Console.WriteLine("Move accepted, well done you've won the game!");
            }
        }

        public bool IsAlreadyOccupied(int x, int y) // no longer required
        {
            // logic:
            // check using IsOccupied() if board[x][y] is filled
            // if it is, return false
            // if not, place the coords
            //int player = 1;
            if (IsOccupied(x, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}