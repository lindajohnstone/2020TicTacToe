using System;
using System.Linq;

namespace TicTacToe
{
    public class GameBoard
    {
        int[][] board = new[] 
            {                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                            
            };
        IWinningBoard _winningBoard;

        public GameBoard(IWinningBoard winningBoard)
        {
            _winningBoard = winningBoard;

        }
        public void Print()
        {
            Console.WriteLine("Here's the current board:");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    var coords = board[i][j];
                    if (coords == 2)
                    {
                        Console.Write("O ");
                    }
                    else if (coords == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool CheckIfWinningRowOnBoard()
        {
            return _winningBoard.CheckIfWinningRowOnBoard(board);
        }
        public bool CheckIfWinningColumnOnBoard()
        {
            return _winningBoard.CheckIfWinningColumnOnBoard(board);
        }

        public bool CheckSingleColumn()
        {
            return _winningBoard.CheckSingleColumn(board);
        }

        /* public bool RowPatternCheck(int[] row)
{
   // loop through array
   // if not zero
   // check each variable against the next
   // return true if true
   // else return false
  // 
  // if (list.Any(o => o != list[0]))
   if (row == null || row.Length == 0 || row[0] == 0 )
   {
       return false;
   }
   // loop through rows
   return !row.Distinct().Skip(1).Any();

   for(int i = 0; i < row.Length - 1; i++)
   {
       if(row[i] == row[i+1]) 
       {
           result = true;
       }
       else 
       {
           result = false;
           break;
       }   
   } 
}
public bool CheckIfWinningRow()
{
   // loop through array
   // if not zero
   // check each variable against the next
   // return true if true
   // else return false
  // 
  // if (list.Any(o => o != list[0]))

       foreach (int[] row in board)
       {
           if (row == null || row.Length == 0 || row[0] == 0 )
           {
               return false;
           }
           return !row.Distinct().Skip(1).Any();
       }
       return false;
   loop through rows


   for(int i = 0; i < row.Length - 1; i++)
   {
       if(row[i] == row[i+1]) 
       {
           result = true;
       }
       else 
       {
           result = false;
           break;
       }   
   } 
} */

        public void PlayGame()
        {
            
            for (int i = 0; i < 3; i++)
            {
                var position = GetPlayerInput();
                Place(1, position.X, position.Y);
                Print();
            }
        }
        public PlayerPosition GetPlayerInput()
        {
            Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            var position = new PlayerPosition(coords);
            return position;
        }
        public void Place(int player, int x, int y)
        {
            /*
            symbol for player 
            allocate coords to board
            */
            if (player == 1)
            {
                board[x][y] = 1;
            } 
            else
            {
                board[x][y] = 2;
            }
        }
        public bool IsOccupied(int x, int y)
        {
            return board[x][y] != 0;
        }
        public bool IsThisAWin() 
        {
            // split responsibility // loop
            if(board[0][0] != 0 && board[0][0] == board[0][1] && board[0][1] == board[0][2])
            {
                return true;
            }
            if(board[1][0] != 0 && board[1][0] == board[1][1] && board[1][1] == board[1][2])
            {
                return true;
            }
            if(board[0][0] != 0 && board[0][0] == board[1][0] && board[1][0] == board[2][0])
            {
                return true;
            }
            return false;
            /* bool result = string.Concat(board[0].Select(_ => _.ToString())) == "111";
            return result; */
            //return board[0][0] == 1 && board[0][1] == 1 && board[0][2] == 1;
        }
        private void EndGame()
        {
            bool result = IsThisAWin();// does not know what this is??
            if (result)
            {
                Console.WriteLine("Move accepted, well done you've won the game! ");
            }
        }
    }
}