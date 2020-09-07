using System.Linq;

namespace TicTacToe
{
    public class Determinator : IWinningBoard
    {
        public bool CheckIfWinningRowOnBoard(int[][] board)
        {
            foreach (int[] row in board)
                {
                    if (row == null || row.Length == 0 || row[0] == 0 )
                    {
                        return false;
                    }
                    return !row.Distinct().Skip(1).Any();
                }
                return false;
        }
    }
}