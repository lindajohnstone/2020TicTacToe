using Xunit;
using TicTacToe;

namespace tests.TicTacToe
{
    public class OutputTests
    {
        [Fact]
        public void ShouldTestValidatorOutputFact() // will be deleted
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
            var errorMessage = "Coord values need to be between 1,1 & 3,3. Please try again.";
            int x = 0;
            int y = 0;

            // act
            var actual = position.IsValid(board, x, y);
            Result result = new Result(actual, errorMessage);
            
            // assert
            Assert.False(result.Success);
        }
        [Theory]
        [InlineData(0,0, "Coord is already occupied. Please try again.")]
        [InlineData(0,9, "Coord values need to be between 1,1 & 3,3. Please try again.")]
        public void ShouldTestValidatorOutput(int x, int y, string expected)
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

            // act
            Result result = new Result(position.IsValid(board, x, y), expected);
            
            // assert
            Assert.False(result.Success);
        }
    }
}
    
