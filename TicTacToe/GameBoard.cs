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
        private IOutput _output;

        public GameBoard(IWinningBoard[] determinators, IValidator[] validators, ConsoleOutput output)
        {
            _determinators = determinators;
            _validators = validators;
            _output = output;
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
                    _output.OutputTextWithNewLine(result.ErrorMessage);
                }
            }
            return results.All(_ => _.Success);
        }

        public void Print()
        {
            _output.OutputTextWithNewLine("Here's the current board:");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    var coords = board[i][j];
                    if (coords == 2)
                    {
                        _output.OutputText("O ");
                    }
                    else if (coords == 1)
                    {
                        _output.OutputText("X ");
                    }
                    else
                    {
                        _output.OutputText(". ");
                    }
                }
                _output.OutputTextWithNewLine(Environment.NewLine);
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
            _output.OutputTextWithNewLine(Constants.Draw);
        }
        
        private PlayerInput GetValidPlayerInput(Player player)
        {
            
            _output.OutputTextWithNewLine($"Player {player.PlayerId} enter a coord x,y to place your {player.Marker} or enter 'q' to give up: ");
            var coords = Console.ReadLine();
            if (coords.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                _output.OutputTextWithNewLine(Constants.Quit);
                Environment.Exit(0);
            } 
            if (!coords.UserInputIsValid())
            {
                _output.OutputTextWithNewLine("Incorrect format. Please try again. ");
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
                _output.OutputText(Constants.MoveAccepted);
                _output.OutputTextWithNewLine(Constants.IsAWin);
                Environment.Exit(0);
            }
        }
    }
}