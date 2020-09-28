using System.Linq;

namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        const string errorMessage = "Coord values need to be between 0,0 & {0},{1}. Please try again.";
        public Result IsValid(int[][] board, int x, int y)
        {
            string resultString = string.Format(errorMessage, board.Length - 1, board.Last().Length - 1);
            Result result = new Result(!(x < 0 || x > board.Length - 1 || y < 0 || y > board.Length - 1), resultString);
            return result;
        }
    }
}