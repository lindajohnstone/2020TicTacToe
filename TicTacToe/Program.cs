using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);
            board.Print();
            board.PlayGame();
        }
    }
}
