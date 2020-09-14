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

        public GameBoard(IWinningBoard[] determinators)
        {
            _determinators = determinators;
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
            }
        }

        public PlayerPosition GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            var position = new PlayerPosition(coords);
            return position;
        }

        public void Place(int player, int x, int y)
        {
            if (player == 1)
            {
                board[x][y] = 1;
            } 
            else
            {
                board[x][y] = 2;
            }
        }
        public bool IsOccupied(int x, int y)
        {
            return board[x][y] != 0;
        }

        private void EndGame()
        {
            bool result = IsThisAWin();// does not know what this is??
            if (result)
            {
                Console.WriteLine("Move accepted, well done you've won the game! ");
            }
        }

        public bool IsAlreadyOccupied(int x, int y)
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