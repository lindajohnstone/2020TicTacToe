using System.Collections;
using System.Collections.Generic;
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
            var board = new GameBoard(determinators, new IValidator[] {});
            var player = 1;

            // act
            board.Place(player, x, y);
            var isOccupied = board.IsOccupied(x, y);

            // assert
            Assert.Equal(expected, isOccupied);
        } 
    
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
        
        [Fact]
        public void Should_Be_A_Win()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators, new IValidator[] {});
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
        // Validate position
        [Fact]
        public void ShouldCheckIfPositionAlreadyFilled()
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators, new IValidator[] {});
            var x = 0;
            var y = 0;
            var player = 1;
            board.Place(player, 0, 0); // to ensure position has been filled

            // act
            board.Place(player, x, y);
            var result = board.IsAlreadyOccupied(x, y);

            //assert
            Assert.False(result);
        } 

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(1, 1, true)]
        [InlineData(2, 2, true)]
        public void ShouldCheckIfPositionAlreadyFilled_TheoryTest(int pos1, int pos2, bool expected)
        {
            // arrange
            IWinningBoard[] determinators = new [] {new RowDeterminator()};
            var board = new GameBoard(determinators, new IValidator[] {});
            var x = 0;
            var y = 0;
            var player = 1;
            board.Place(player, x, y); // to ensure position has been filled

            // act
            //board.Place(player, pos1, pos2);
            var result = board.IsAlreadyOccupied(pos1, pos2);

            //assert
            Assert.Equal(expected, result);
        }
        
    }
}