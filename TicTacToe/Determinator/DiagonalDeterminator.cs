namespace TicTacToe
{
    public class DiagonalDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            if (board[1][1] == 0) // TODO: if board > 3 x 3, cannot be hardcoded
            {
                return false;
            }
            // TODO: if board > 3 x 3, cannot be hardcoded
            var leftDiagonal = board[0][0] == board[1][1] && board[1][1] == board[2][2]; 
            var rightDiagonal = board[0][2] == board[1][1] && board[1][1] == board[2][0];
            return leftDiagonal || rightDiagonal;
        }
    }
}