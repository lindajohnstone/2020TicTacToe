using System;
using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class PlayerInput_Tests
    {
        [Theory]
        [InlineData("1,1",0,0)]
        [InlineData("3,3",2,2)]
        public void Should_Receive_Input_Values(string actual, int expectedX, int expectedY)
        {
            // arrange
            var position = new PlayerInput(actual);
            // assert
            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }
        
        [Theory]
        [InlineData("1,1",true)]
        [InlineData("0,0",true)]
        [InlineData("a,b",false)]
        [InlineData("0 0", false)] 
        [InlineData("abc,0", false)]
        public void Should_check_valid_user_input(string input, bool expected)
        {
            // act
            var actual = input.UserInputIsValid();

            // assert
            Assert.Equal(expected, actual);
        }
    }
        
}
