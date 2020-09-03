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
            var board = new GameBoard();
            
            for (int i = 0; i < 3; i++)
            {
                var position = board.GetPlayerInput();
                board.Place(1, position.X, position.Y);
                board.Print();
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
            /*
            symbol for player 
            allocate coords to board
            */
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
        public bool IsThisAWin() 
        {
            /*
            loop through array to check which is occupied
            pattern = 0,0 0,1 0,2
            if all 1 or all 2, we have a win
            pass to another method to print and end game
            */
            /* string winCheck = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsOccupied(i, j))
                    {
                        winCheck = string.Concat(board[0].Select(_ => _.ToString()));
                    }
                }
            }
            return winCheck; */
            //return string.Concat(board[0].Select(_ => _.ToString())) == "111";
            return board[0][0] == 1 && board[0][1] == 1 && board[0][2] == 1;
        }
        public void EndGame()
        {
            Console.WriteLine("Move accepted, well done you've won the game! ");
        }
    }
}