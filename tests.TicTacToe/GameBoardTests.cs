using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class GameBoardTests
    {
        /* [Theory]
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
        } */
        /* [Theory]
        [InlineData(1,1,1, true)]
        [InlineData(1,2,2, false)]
        [InlineData(0,0,0, false)]
        public void Should_Check_Win_Condition_Row(int one, int two, int three, bool expected)
        {
            // arrange
            var board = new GameBoard();
        
            //act
            bool result = board.RowPatternCheck(new [] {one, two, three});

            //assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_CheckIfAWin()
        {
            // arrange
            var board = new GameBoard();
            board.Place(1,0,0);
            board.Place(1,0,1);
            board.Place(1,0,2);
            // act
            //bool result = board.CheckIfWinningRow();
            // assert
            Assert.True(result);
        } */
        [Fact]
        public void Should_Check_GameBoard_ShowsAWinningRow()
        {
            // arrange
            IWinningBoard determinator = new Determinator();
            var board = new GameBoard(determinator);

            // act
            board.Place(1,0,0);
            board.Place(1,0,1);
            board.Place(1,0,2);
            //board.Print();
            var result = board.CheckIfWinningRowOnBoard();

            // assert
            Assert.True(result);
        }
        [Fact]
        public void Should_Check_GameBoard_ShowsAWinningColumn()
        {
            // arrange
            IWinningBoard determinator = new Determinator();
            var board = new GameBoard(determinator);

            // act
            board.Place(1,0,0);
            board.Place(1,1,0);
            board.Place(1,2,0);
            var result = board.CheckIfWinningColumnOnBoard();
            // assert
            Assert.True(result);
        }
        [Theory]
        [InlineData(0,0,0, false)]
        [InlineData(0,1,2, true)]
        public void Should_Check_GameBoard_ShowsAColumnWin(int one, int two, int three, bool expected)
        {
            // arrange
            IWinningBoard determinator = new Determinator();
            var board = new GameBoard(determinator);

            // act
            bool result = board.CheckSingleColumn();

            // assert
            Assert.Equal(expected, result);
        }
    }
}