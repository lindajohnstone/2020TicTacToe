namespace TicTacToe
{
    public class PositionValidator : IValidator
    {
        public (bool, string) IsValid(int[][] board, int x, int y)
        {
            
            return (board[x][y] == 0, "Oh no a piece is already at that position");
            /* tuple */
        }
    }
}