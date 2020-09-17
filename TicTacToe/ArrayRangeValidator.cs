namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        public bool IsValid(int[][] board, int x, int y)
        {
            // logic
            // check that the index of board[x][y] is not less than zero
            // or greater than or equal to board.length
            // if it is, return false
            // if not, return true
            /* if (board[x][y] < 0 || board[x][y] > board.Length - 1)
            {
                return false;
            }
            return true;  */
            if (x < 0 || x > board.Length - 1)
            {
                return false;
            }
            if (y < 0 || y > board.Length - 1)
            {
                return false;
            }
            return true;
        }
    }
}