using System.Linq;

namespace TicTacToe
{
    public class RowDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            /* int count = 0;
            for (int row = 0; row < 3; row++) */
            foreach (int[] row in board)
            {
                /* 
                    Count == 0
                    **For loop through rows
                    For loop through columns
                    If board[row][column] equals player.PlayerId
                    Count++
                    If count equals 3
                    Return true
                    Break
                    Else
                    Count = 0
                    Return false
                    End loop through columns
                    End loop through rows 
                */
                /* 
                for (int col = 0; col < 3; col++)
                {
                    if (board[row][col] == 1)
                    {
                        count++;
                    }
                    if (count == 3)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0; 
                    }  
                } */ 
                return !row.Distinct().Skip(1).Any();
            }
            return false;
        }
    }
}