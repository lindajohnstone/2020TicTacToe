using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var determinators = new IWinningBoard[] 
            {
                new RowDeterminator(),
                new ColumnDeterminator(),
                new DiagonalDeterminator(),
            };
            var board = new GameBoard(determinators);
            Console.WriteLine(Constants.Welcome);
            board.Print();
            board.PlayGame();
        }
    }
}
