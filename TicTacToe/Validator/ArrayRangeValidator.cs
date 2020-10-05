using System.Linq;

namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        public Result IsValid(int[][] board, int x, int y)
        {
            string resultString = string.Format(Constants.RangeErrorMessage, board.Length, board.Last().Length);
            Result result = new Result(!(x < 0 || x > board.Length - 1 || y < 0 || y > board.Length - 1), resultString);
            return result;
        }
    }
}