namespace TicTacToe
{
    public class PositionValidator : IValidator
    {
        const string errorMessage = "Coord is already occupied. Please try again.";
        public Result IsValid(int[][] board, int x, int y)
        {
            
            Result result = new Result(board[x][y] == 0, errorMessage);
            return result;
        }
    }
}