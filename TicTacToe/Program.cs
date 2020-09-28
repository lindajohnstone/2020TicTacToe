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
            var validators = new IValidator[]
            {
                new ArrayRangeValidator(),
                new PositionValidator()
            };
            var output = new ConsoleOutput();
            
            var board = new GameBoard(determinators, validators, output);
            
            board.PlayGame();
        }
    }
}
