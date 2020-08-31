using System;
using Xunit;

namespace tests.TicTacToe
{
    public class PlayerInput_Tests
    {
        [Theory]
        [InlineData("0,0","1,1")]// fails
        [InlineData("0,0","0,0")] // passes
        public void Should_Change_Player_Input_ToArray(string actual, string expected)
        {
            // arrange
            var value = new PlayerPosition();
            // act
            var input = value.SetPosition(actual);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
