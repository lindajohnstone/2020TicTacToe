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
                    /* var coords = board.GetValue(i, j);
                    if ((bool)(coords = 2))
                    {
                        Console.Write("Y");
                    }
                    else
                    {
                        if ((bool)(coords = 1))
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                    } */
                    //Console.Write(board.GetValue(j));
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        public void GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            var position = new PlayerPosition(coords);

        }
    }
}