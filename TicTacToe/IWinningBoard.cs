namespace TicTacToe
{
    public interface IWinningBoard
    {
        public bool CheckIfWinningRowOnBoard(int[][] board);
        public bool CheckIfWinningColumnOnBoard(int[][] board);
        public bool CheckSingleColumn(int[][] board);
    }
}