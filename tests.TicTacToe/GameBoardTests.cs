using System.Collections;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace tests.TicTacToe
{
    public class GameBoardTests
    {
        [Fact]
        public void Should_Check_GameBoard_ShowsAWinningRow()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators, new IValidator[] {});

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
            IWinningBoard[] determinators = new [] {new ColumnDeterminator()};
            var board = new GameBoard(determinators, new IValidator[] {});

            // act
            board.Place(1,0,0);
            board.Place(1,1,0);
            board.Place(1,2,0);
            var result = board.IsThisAWin();
            // assert
            Assert.True(result);
        }
    }
}