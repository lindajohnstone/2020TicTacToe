using Xunit;
using TicTacToe;

namespace tests.TicTacToe
{
    public class OutputTests
    {
        [Fact]
        public void ShouldTestValidatorOutput()
        {
            // arrange
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
            int x = 0;
            int y = 0;

            // act
            var result = position.IsValid(board, x, y);
            var errorMessage = result.OutputText();

            // assert
            Assert.Equal(result, errorMessage);
        }
        
    }
}
    
