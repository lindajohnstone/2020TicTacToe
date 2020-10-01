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
        public void PlayGame()
        {
            Console.WriteLine(Constants.Welcome);
            Print();
            var maxMoves = board.Sum(_ => _.Count());
            while (maxMoves != 0)
            {
                var currentPlayer = _players[(maxMoves + 1) % 2]; 
                var position = GetValidPlayerInput(currentPlayer);
                
                Place(currentPlayer.PlayerId, position.X, position.Y);
                Console.Write(Constants.MoveAccepted);
                Print();
                EndGame(currentPlayer);
                maxMoves--;
            } 
            _output.OutputTextWithNewLine(Constants.Draw);
        }
        public void Print()
        {
            _output.OutputTextWithNewLine(Constants.Print);
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
                _output.OutputText(Environment.NewLine);
            }
        }
        private PlayerInput GetValidPlayerInput(Player player)
        {
            string instruction = string.Format(Constants.PlayerInstruction, player.PlayerId, player.Marker);
            _output.OutputTextWithNewLine(instruction);
            var coords = Console.ReadLine();
            if (coords.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                _output.OutputTextWithNewLine(Constants.Quit);
                Environment.Exit(0);
            } 
            if (!coords.UserInputIsValid())
            {
                _output.OutputTextWithNewLine(Constants.IncorrectFormat);
                return GetValidPlayerInput(player);
            }
            var position = new PlayerInput(coords);
            if (!IsValid(board, position.X, position.Y))
            {
                return GetValidPlayerInput(player);
            }
            return position;
        }
        public bool IsValid(int[][] board, int x, int y)
        {
            var output = false;
            foreach (var result in from validator in _validators
                                   let result = validator.IsValid(board, x, y)
                                   select result
            )
            {
                if (result.Success)
                {
                    output = true;
                    continue;
                }
                else
                {
                    _output.OutputTextWithNewLine(result.ErrorMessage);
                    output = false;
                    break;
                }
            }
            return output;
        }
        public void Place(int player, int x, int y)
        {
                board[x][y] = player;
        }
        public void EndGame(Player player)
        {
            if (IsThisAWin())
            {
                string itsAWin = string.Format(Constants.WinMessage, player.PlayerId);
                _output.OutputText(Constants.MoveAccepted);
                _output.OutputTextWithNewLine(itsAWin);
                Environment.Exit(0);
            }
        }
        public bool IsThisAWin()
        {
            return _determinators.Any(_ => _.IsThisAWin(board));
        }
    }
}