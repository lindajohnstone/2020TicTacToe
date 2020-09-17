using System;
using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class PlayerInput_Tests
    {
        [Theory]
        [InlineData("1,1",1,1)]
        [InlineData("0,0",0,0)]
        [InlineData("a,b",0,0)] 
        public void Should_Receive_Input_Values(string actual, int expectedX, int expectedY)
        {
            // arrange
            var position = new PlayerPosition(actual);
            // assert
            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }
        [Theory]
        [InlineData(0,0, true)]

        public void ShouldCheckValidUserInput(int x, int y, bool expected)
        {
            // arrange
            int[][] board = new[]
            {
                new[] {0, 0, 0},
                new[] {0, 0, 0},
                new[] {0, 0, 0},
            };
            IValidator[] validators = new [] {new InputValidator()};
            var position = new GameBoard(validators);

            // act
            var result = position.IsValid(board, x, y);

            // assert
            Assert.Equal(expected, result);
        }
    }
        
}
