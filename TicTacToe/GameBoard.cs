using System;

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
                    //Console.Write(board.GetValue(j));
                    //Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        public bool IsOccupied(int x, int y)
        {
            return board[x][y] != 0;
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

        public PlayerPosition GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            var position = new PlayerPosition(coords);
            return position;
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
    }
}