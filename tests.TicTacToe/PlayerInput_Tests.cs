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
        public void Should_Receive_Input_Values_Test(string actual, int expectedX, int expectedY)
        {
            // arrange
            
            // act
            var position = new PlayerPosition(actual);
            // assert
            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }
        [Theory]
        [InlineData(0,0,1)]
        public void Should_Set_Input_Values(int actualX, int actualY, string expected)
        {
            // arrange
            var X = Convert.ToString(actualX);
            var Y = Convert.ToString(actualY);
            var input = String.Concat(X, ",", Y);
            var position = new PlayerPosition(input);
            // act
            // assert
            Assert.Equal(expected, X, Y);
        }
    }
}
