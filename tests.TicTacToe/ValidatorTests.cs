using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(0,1, true)]
        [InlineData(0,0, false)]
        public void ShouldCheckIfPositionOccupied(int x, int y, bool expected)
        {
            // arrange
            int[][] board = new[] 
            {                
                new[] { 1, 0, 0 },                
                new[] { 0, 1, 0 },                
                new[] { 0, 0, 1 },                            
            };

            IValidator[] validators = new [] {new PositionValidator()};
            var position = new GameBoard(new IWinningBoard[] {}, validators, new ConsoleOutput());

            // act
            var result = position.IsValid(board, x, y);

            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(0,1, true)]
        [InlineData(2,2, true)]
        [InlineData(3,0, false)]
        [InlineData(0,7, false)]
        [InlineData(-1,-2, false)]
        public void ShouldCheckUserInputWithinValidRange(int x, int y, bool expected)
        {
            // arrange
            int[][] board = new[] 
            {                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                            
            };
            IValidator[] validators = new [] {new ArrayRangeValidator()};
            var position = new GameBoard(new IWinningBoard[] {}, validators, new ConsoleOutput());

            // act
            var result = position.IsValid(board, x, y);

            // assert
            Assert.Equal(expected, result);
        }
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