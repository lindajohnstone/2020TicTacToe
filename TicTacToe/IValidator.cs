namespace TicTacToe
{
    public interface IValidator
    {
        Result IsValid(int[][] board, int x, int y);
    }
}