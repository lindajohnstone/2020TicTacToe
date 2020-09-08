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
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);
            var player = 1;

            // act
            board.Place(player, x, y);
            var isOccupied = board.IsOccupied(x, y);

            // assert
            Assert.Equal(expected, isOccupied);
        } 
        [Theory]
        [InlineData(1,1,1, true)]
        [InlineData(1,2,2, false)]
        [InlineData(0,0,0, false)]
        public void Should_Check_Win_Condition_Row(int one, int two, int three, bool expected)
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);
        
            //act
            bool result = board.RowPatternCheck(new [] {one, two, three});

            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_CheckIfAWin()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);
            board.Place(1,0,0);
            board.Place(1,0,1);
            board.Place(1,0,2);
            // act
            bool result = board.CheckIfWinningRow();
            // assert
            Assert.True(result);
        }  
        [Fact]
        public void Should_Check_GameBoard_ShowsAWinningRow()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);

            // act
            board.Place(1,0,0);
            board.Place(1,0,1);
            board.Place(1,0,2);
            //board.Print();
            var result = board.IsThisAWin();

            // assert
            Assert.True(result);
        }
        [Fact]
        public void Should_Check_GameBoard_ShowsAWinningColumn()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);

            // act
            board.Place(1,0,0);
            board.Place(1,1,0);
            board.Place(1,2,0);
            var result = board.IsThisAWin();
            // assert
            Assert.True(result);
        }
        [Fact]
        public void Should_Be_A_Win()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators);
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
        } 
    }
}