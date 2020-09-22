namespace TicTacToe
{
    public class PositionValidator : IValidator
    {
        public bool IsValid(int[][] board, int x, int y)
        {
            
            return board[x][y] == 0;
        }
    }
}