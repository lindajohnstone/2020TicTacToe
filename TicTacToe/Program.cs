using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new GameBoard();
            board.Print();
            var position = board.GetPlayerInput();
            board.Place(1, position.X, position.Y);
            board.Print();
        }
    }
}
