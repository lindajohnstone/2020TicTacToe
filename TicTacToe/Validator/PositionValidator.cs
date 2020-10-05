namespace TicTacToe
{
    public class PositionValidator : IValidator
    {
        
        
        public Result IsValid(int[][] board, int x, int y)
        {
                Result result = new Result(board[x][y] == 0, Constants.PositionErrorMessage);
                return result;
        }
    }
}