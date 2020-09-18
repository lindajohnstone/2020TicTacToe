namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        public bool IsValid(int[][] board, int x, int y)
        {
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