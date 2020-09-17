namespace TicTacToe
{
    public interface IValidator
    {
        bool IsValid(int[][] board, int x, int y);
    }
}