namespace TicTacToe
{
    public class LeftRightDiagonalDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            // loop through board
            // if board[i,j]=i=j
            // return true
            // return false
            /* if (row == null || row.Length == 0 || row[0] == 0 )
                
            {
                    return false;
            } */
            if (board[1][1] == 0)
            {
                return false;
            }
            var leftDiagonal = board[0][0] == board[1][1] && board[1][1] == board[2][2];
            var rightDiagonal = board[0][2] == board[1][1] && board[1][1] == board[2][0];
            return leftDiagonal || rightDiagonal;
            /* for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == i && board[i][j] == j)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false; */
        }
    }
}