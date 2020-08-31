using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new GameBoard();
            board.Print();
            board.GetPlayerInput();
            board.Print();
        }
    }
}
