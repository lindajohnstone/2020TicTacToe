using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class GameBoardTests
    {
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
        [Fact]
        public void Should_Check_Win_Condition_Row()
        {
            // arrange
            var board = new GameBoard();
        
            //act
            bool result = board.RowPatternCheck(new [] {1,1,1});
            //assert
            Assert.Equal(true, result);
        }
    }
}