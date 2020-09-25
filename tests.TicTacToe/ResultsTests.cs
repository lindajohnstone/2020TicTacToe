using Xunit;
using TicTacToe;

namespace tests.TicTacToe
{
    public class ResultsTests
    {
        [Theory]
        [InlineData(1,1, true)]
        [InlineData(2,0, true)]
        [InlineData(9,0, false)]
        public void ShouldReturnCorrectValidatorOutput(int x, int y, bool expected)
        {
            int[][] board = new[]
             {
                new[] { 1, 1, 1 },
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
            }; 
            var validators = new IValidator[]
            {
                new ArrayRangeValidator(),
                new PositionValidator()
            };
            ConsoleOutput userOutput = new ConsoleOutput();
            var position = new GameBoard(new IWinningBoard[] {}, validators, userOutput);
            
            // act
            var result = position.IsValid(board, x, y);

            // assert
            Assert.Equal(expected, result);
        }
    }
}