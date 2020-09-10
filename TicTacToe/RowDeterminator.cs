using System.Linq;

namespace TicTacToe
{
    public class RowDeterminator : IWinningBoard
    {
        public bool IsThisAWin(int[][] board)
        {
            foreach (int[] row in board)
            {
                /* if (row == null || row.Length == 0 || row[0] == 0)
                {
                    return false;
                } */
                return !row.Distinct().Skip(1).Any();
            }
            return false;
        }
    }
}