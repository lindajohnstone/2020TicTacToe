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
        private IWinningBoard[] _determinators;

        private IValidator[] _validators;
        private Player[] _players;
        public GameBoard(IWinningBoard[] determinators, IValidator[] validators)
        {
            _determinators = determinators;
            _validators = validators;
            _players = new[]
            {
                new Player (1, "X"),
                new Player (2, "O")
            };
        }

        public bool IsThisAWin()
        {
            return _determinators.Any(_ => _.IsThisAWin(board));
        }

        public bool IsValid(int[][] board, int x, int y)
        {
            var results =  _validators.Select(_ => _.IsValid(board, x, y)).ToArray();
            foreach(var result in results)
            {
                if (!result.Success)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            return results.All(_ => _.Success);
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

        public void PlayGame()
        {
            var maxMoves = board.Sum(_ => _.Count());
            while (maxMoves != 0)
            {
                var currentPlayer = _players[(maxMoves + 1) % 2]; 
                var position = GetValidPlayerInput(currentPlayer);
                
                Place(currentPlayer.PlayerId, position.X, position.Y);
                Console.Write(Constants.MoveAccepted);
                Print();
                EndGame();
                maxMoves--;
            } 
            Console.WriteLine(Constants.Draw);
        }
        
        private PlayerInput GetValidPlayerInput(Player player)
        {
            
            Console.WriteLine($"Player {player.PlayerId} enter a coord x,y to place your {player.Marker} or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            if (coords.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(Constants.Quit);
                Environment.Exit(0);
            } 
            if (!coords.UserInputIsValid())
            {
                Console.WriteLine("Incorrect format. Please try again. ");
                return GetValidPlayerInput(player);
            }
            var position = new PlayerInput(coords);
            if (!IsValid(board, position.X, position.Y))
            {
                return GetValidPlayerInput(player);
            }
            return position;
        }
        
        public void Place(int player, int x, int y)
        {
                board[x][y] = player;
        }

        private void EndGame()
        {
            if (IsThisAWin())
            {
                Console.Write(Constants.MoveAccepted);
                Console.WriteLine(Constants.IsAWin);
                Environment.Exit(0);
            }
        }
    }
}