namespace TicTacToe
{
    public interface IValidator
    {
        (bool, string) IsValid(int[][] board, int x, int y);
    }
}