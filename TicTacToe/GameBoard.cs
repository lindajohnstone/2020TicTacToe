using System;

namespace TicTacToe
{
    public class GameBoard
    {
        private string coords;
        public void InitialiseBoard()
        {
            var board = new[] 
                {                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                            
            };
            Console.WriteLine("Here's the current board:");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }

        public void GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            coords = Console.ReadLine();
        }
    }
}