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
            Player playerOne = new Player(1, "X");
            Player playerTwo = new Player(2, "O");
            var board = new GameBoard(determinators, validators);
            Console.WriteLine(Constants.Welcome);
            board.Print();
            board.PlayGame();
        }
    }
}
