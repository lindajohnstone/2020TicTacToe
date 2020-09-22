namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        public bool IsValid(int[][] board, int x, int y)
        {
            return !(x < 0 || x > board.Length - 1 || y < 0 || y > board.Length - 1);
        }
    }
}