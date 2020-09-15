namespace TicTacToe
{
    public class ColumnDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            // loop through row
            // use board.GetUpperBound(1)?? == does not work; throws out of bounds exception
            // if column x == 111
            // win
            
            var columnZero = board[0][0] != 0 && board[0][0] == board[1][0] && board[1][0] == board[2][0];
            var columnOne = board[0][1] != 0 && board[0][1] == board[1][1] && board[1][1] == board[2][1];
            var columnTwo = board[0][2] != 0 && board[0][2] == board[1][2] && board[1][2] == board[2][2];
            return columnZero || columnOne || columnTwo;

        }
    }
}