using System.Linq;

namespace TicTacToe
{
    public class RowDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            // TODO: if statement needs refactoring 
            /* if (row == null || row.Length == 0 || row[0] == 0)
                {
                    return false;
                } */
            foreach (int[] row in board)
            {
                return !row.Distinct().Skip(1).Any();
            }
            return false;
        }
    }
}