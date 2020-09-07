using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var determinator = new Determinator();
            var board = new GameBoard(determinator);
            board.Print();
            board.PlayGame();
        }
    }
}
