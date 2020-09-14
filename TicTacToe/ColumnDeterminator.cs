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
            string columnCheck = "";
            // TODO: hardcoded - only works for 1st column
            /* if (board == null || board.Length == 0 || board[0][0] == 0 )
            {
                return false;
            } */
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)// need to keep note of column!!
                {
                    // while j = 0
                    if (board[i][j] == 1)// TODO: only for 1 player; need to work for 2 players
                    {
                        columnCheck = string.Concat(columnCheck, i, j);
                    }
                    if (columnCheck == "001020")
                    {
                        return true;
                    }
                    if (columnCheck == "011121")
                    {
                        return true;
                    }
                    if (columnCheck == "021222")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}