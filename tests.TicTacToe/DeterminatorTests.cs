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
            var determinator = new Determinator();
            
            // act
        
            var result = determinator.CheckIfWinningRowOnBoard(board);
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
            var determinator = new Determinator(); 

            // act 
            var result = determinator.CheckIfWinningColumnOnBoard(board);

            // assert
            Assert.True(result);
        }

    }
    
}