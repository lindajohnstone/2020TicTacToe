using TicTacToe;
using Xunit;
using Moq;

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
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
         public void ShouldTestArrayRangeValidator(bool expected)
        {
            // This test does not test any specific scenario
            // This test is just to implement and understand usage of Moq in xUnit
 
            // arrange
            int[][] board = new[]
             {
                new[] { 1, 1, 1 },
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
            }; 
            var x = 0;
            var y = 9;
 
            var mockValidator = new Mock<IValidator>();
            mockValidator
            .Setup(_ => _.IsValid(board, x, y))
            .Returns(new Result(expected, "Some errorMessage"));
 
            var mockValidators = new IValidator[] {mockValidator.Object};
 
            // act
            var position = new GameBoard(new IWinningBoard[] {}, mockValidators, new ConsoleOutput());
            var result = position.IsValid(board, x, y);
 
            // assert
            Assert.Equal(expected, result);
        } 
    }
}