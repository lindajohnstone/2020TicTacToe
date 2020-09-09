using Xunit;
using TicTacToe;

namespace tests.TicTacToe
{
    public class DeterminatorTests
    {
        [Fact]
        public void ShouldTestWinningRow()
        {
            // arrange
           int[][] board = new[] 
            {                
                new[] { 1, 1, 1 },                
                new[] { 0, 0, 0 },                
                new[] { 0, 0, 0 },                            
            };
            var determinator = new RowDeterminator();
            
            // act
            var result = determinator.IsThisAWin(board);
            // assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldTestWinningColumn()
        {
            // arrange
            int[][] board = new[] 
            {                
                new[] { 1, 0, 0 },                
                new[] { 1, 0, 0 },                
                new[] { 1, 0, 0 },                            
            };
            var determinator = new ColumnDeterminator(); 

            // act 
            var result = determinator.IsThisAWin(board);

            // assert
            Assert.True(result);
        }
        [Fact]
        public void ShouldTestWinningLeftRightDiagonal()
        {
            // arrange
            int[][] board = new[] 
            {                
                new[] { 1, 0, 0 },                
                new[] { 0, 1, 0 },                
                new[] { 0, 0, 1 },                            
            };
            var determinator = new DiagonalDeterminator();

            // act
            var result = determinator.IsThisAWin(board);

            // assert
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(new[] { 1, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 1 }, true)]
        public void ShouldTestWinningDiagonal(int[] one, int[] two, int[] three, bool expected)
        {
            // arrange
            int[][] board = new[] 
            {                
                one, two, three                           
            };
            var determinator = new DiagonalDeterminator();

            // act
            var result = determinator.IsThisAWin(board);

            // assert
            Assert.Equal(expected, result);
        }
    }
}