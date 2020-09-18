namespace TicTacToe
{
    public class ColumnDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            // TODO: needs refactoring for board > 3 x 3
            var columnZero = board[0][0] != 0 && board[0][0] == board[1][0] && board[1][0] == board[2][0];
            var columnOne = board[0][1] != 0 && board[0][1] == board[1][1] && board[1][1] == board[2][1];
            var columnTwo = board[0][2] != 0 && board[0][2] == board[1][2] && board[1][2] == board[2][2];
            return columnZero || columnOne || columnTwo;

        }
    }
}