using System.Linq;

namespace TicTacToe
{
    public class Determinator : IWinningBoard
    {
        public bool CheckIfWinningColumnOnBoard(int[][] board)
        {
            // loop through row
            // use board.GetUpperBound(1)?? == does not work; throws out of bounds exception
            // if column x == 111
            // win
            int player = 1;
            int count = 0;
            if (board == null || board.Length == 0 || board[0][0] == 0 )
            {
                return false;
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] == 1)
                    {
                        count++;
                    }
                }
                if (count == player * board.Length)
                {
                    return true;
                }
            }
            return false;
        }

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