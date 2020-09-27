namespace TicTacToe
{
    public class PositionValidator : IValidator
    {
        const string errorMessage = "Coord is already occupied. Please try again.";
        const string rangeErrorMessage = "Values are out of range.";
        public Result IsValid(int[][] board, int x, int y)
        {
            try
            {
                Result result = new Result(board[x][y] == 0, errorMessage);
                return result;
            }
            catch
            {
                Result errorResult = new Result(false, rangeErrorMessage);
                return errorResult;
            }
        }
    }
}