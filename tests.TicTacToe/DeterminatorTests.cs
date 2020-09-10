using Xunit;
using TicTacToe;
using System.Collections.Generic;
using System.Collections;

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
        [Theory]
        [ClassData(typeof(DeterminatorTestData))]
        public void ShouldTestUsingClassData_WinningDiagonal(TestData data)
        {
            // arrange
            var determinator = new DiagonalDeterminator();

            // act
            var result = determinator.IsThisAWin(data.Input);

            // assert
            Assert.Equal(data.Expected, result);
        }
        public class DeterminatorTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _testData = new List<object[]>
            {
                new object[]
                {
                    new TestData
                    {
                        Input = new[]
                        {
                            new[] {1, 0, 0},
                            new[] {0, 1, 0},
                            new[] {0, 0, 1},
                        },
                        Expected = true
                    },
                },
                new object[]
                {
                    new TestData
                    {
                        Input = new[]
                        {
                            new[] {0, 0, 1},
                            new[] {0, 1, 0},
                            new[] {1, 0, 0},
                        },
                        Expected = true
                    },
                },
                new object[]
                {
                    new TestData
                    {
                        Input = new[]
                        {
                            new[] {0, 0, 0},
                            new[] {0, 0, 0},
                            new[] {0, 0, 0},
                        },
                        Expected = false
                    }
                }
            };

            public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class TestData
        {
            public int[][] Input;
            public bool Expected;
        }
    }
}

