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
        [InlineData(0,0,true)]
        [InlineData(0,1,true)]
        [InlineData(2,0,true)]
        [InlineData(1,0,true)]
        public void Should_Occupy_Expected_Position_On_Board(int x, int y, bool expected)
        {
            // arrange
            var board = new GameBoard();
            var player = 1;

            // act
            board.Place(player, x, y);
            var isOccupied = board.IsOccupied(x, y);

            // assert
            Assert.Equal(expected, isOccupied);
        }
        
        /* [Fact]
        public void Should_Be_A_Win()
        {
            // arrange
            var board = new GameBoard();
            var player = 1;
            var pos1 = 0;
            var pos2 = 1;
            var pos3 = 2;
            
            // act
            board.Place(player, pos1, pos1);
            board.Place(player, pos1,pos2);
            board.Place(player, pos1, pos3);
            board.IsOccupied(pos1, pos1);
            board.IsOccupied(pos1, pos2);
            board.IsOccupied(pos1, pos3);
            var win = board.IsThisAWin();

            // assert
            Assert.True(win);
        }  */

        [Theory]
        [InlineData("111", true)]
        public void Should_Be_A_Win_Theory_Test(string value, bool expected)
        {
            // arrange
            var board = new GameBoard();
            var player = 1;
            var pos1 = 0;
            var pos2 = 1;
            var pos3 = 2;
            
            // act
            board.Place(player, pos1, pos1);
            board.Place(player, pos1,pos2);
            board.Place(player, pos1, pos3);
            board.IsOccupied(pos1, pos1);
            board.IsOccupied(pos1, pos2);
            board.IsOccupied(pos1, pos3);
            value = board.IsThisAWin();

            // assert
            Assert.Equal(expected, value);
        }
    }
}
