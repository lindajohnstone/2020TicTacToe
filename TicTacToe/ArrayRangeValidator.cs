namespace TicTacToe
{
    public class ArrayRangeValidator : IValidator
    {
        public (bool, string) IsValid(int[][] board, int x, int y)
        {
            return (!(x < 0 || x > board.Length - 1 || y < 0 || y > board.Length - 1), "Please use numbers between 0 & 2");
            /* {
                return false;
            }
            return true; */
        }
    }
}