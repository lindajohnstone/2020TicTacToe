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
        [InlineData(0,0,true)]
        [InlineData(0,1,true)]
        [InlineData(2,0,true)]
        [InlineData(1,0,true)]
        public void Should_Occupy_Expected_Position_On_Board(int x, int y, bool expected)
        {
            // arrange
            var board = new GameBoard();
            // act
            var player = 1;
            board.Place(player, x, y);
            var isOccupied = board.IsOccupied(x, y);
            // assert
            Assert.Equal(expected, isOccupied);
        }
    }
}
