using Xunit;
using TicTacToe;
using System.Collections.Generic;
using System.Collections;
using Moq;

namespace tests.TicTacToe
{
    public class DeterminatorTests
    {
        // test winning row
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
        [Theory]
        [ClassData(typeof(RowDeterminatorData))]
        public void ShouldTestRowDeterminator(TestData data)
        {
            // arrange
            var mockDeterminator = new Mock<IWinningBoard>();
            mockDeterminator
            .Setup(_ => _.IsThisAWin(data.Input))
            .Returns(data.Expected);
 
            var mockDeterminators = new RowDeterminator();
 
            // act
            var result = mockDeterminators.IsThisAWin(data.Input);
 
            // assert
            Assert.Equal(data.Expected, result);
        }

        [Theory]
        [ClassData(typeof(RowDeterminatorData))]
        public void ShouldTestWinningRow_UsingClassData(TestData data)
        {
            // arrange
            var determinator = new RowDeterminator();

            // act
            var result = determinator.IsThisAWin(data.Input);
            // assert
            Assert.Equal(data.Expected, result);
        }
        public class RowDeterminatorData : IEnumerable<object[]>
        {
            private readonly List<object[]> _testData = new List<object[]>
            {
                new object[]
                {
                    new TestData
                    {
                        Input = new[]
                        {
                            new[] {1, 1, 1},
                            new[] {0, 0, 0},
                            new[] {0, 0, 0},
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
                            new[] {1, 1, 1},
                            new[] {0, 0, 0},
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
                            new[] {0, 1, 1},
                            new[] {0, 0, 0},
                            new[] {0, 0, 0},
                        },
                        Expected = false
                    },
                },
            };  
            public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        // test winning column
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

        [Theory]
        [ClassData(typeof(ColumnDeterminatorData))]
        public void ShouldTestColumnDeterminator(TestData data)
        {
            // arrange
            var mockDeterminator = new Mock<IWinningBoard>();
            mockDeterminator
            .Setup(_ => _.IsThisAWin(data.Input))
            .Returns(data.Expected);
            var mockDeterminators = new ColumnDeterminator();

            // act
            var result = mockDeterminators.IsThisAWin(data.Input);
            // assert
            Assert.Equal(data.Expected, result);
        }

        [Theory]
        [ClassData(typeof(ColumnDeterminatorData))]
        public void ShouldTestWinningColumn_UsingClassData(TestData data)
        {
            // arrange
            var determinator = new ColumnDeterminator();

            // act
            var result = determinator.IsThisAWin(data.Input);

            // assert
            Assert.Equal(data.Expected, result);
        }

        public class ColumnDeterminatorData : IEnumerable<object[]>
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
                            new[] {1, 0, 0},
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
                            new[] {0, 1, 0},
                            new[] {0, 1, 0},
                            new[] {0, 1, 0},
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
                            new[] {0, 0, 1},
                            new[] {1, 0, 0},
                        },
                        Expected = false
                    },
                },
                new object[]
                {
                    new TestData
                    {
                        Input = new[]
                        {
                            new[] {0, 1, 1},
                            new[] {0, 0, 0},
                            new[] {1, 0, 0},
                        },
                        Expected = false
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
                        Expected = false
                    },
                },
            };  
            public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        #region Diagonal Determinator
    
        [Theory]
        [ClassData(typeof(DiagonalDeterminatorTestData))]
        public void ShouldTestUsingClassData_WinningDiagonal(TestData data)
        {
            // arrange
            var determinator = new DiagonalDeterminator();

            // act
            var result = determinator.IsThisAWin(data.Input);

            // assert
            Assert.Equal(data.Expected, result);
        }
        [Theory]
        [ClassData(typeof(DiagonalDeterminatorTestData))]
        public void ShouldTestDiagonalDeterminator(TestData data)
        {
            // arrange
            var mockDeterminator = new Mock<IWinningBoard>();
            mockDeterminator
            .Setup(_ => _.IsThisAWin(data.Input))
            .Returns(data.Expected);
            var mockDeterminators = new DiagonalDeterminator();

            // act
            var result = mockDeterminators.IsThisAWin(data.Input);

            // assert
            Assert.Equal(data.Expected, result);
        }
        public class DiagonalDeterminatorTestData : IEnumerable<object[]>
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
        # endregion
        public class TestData
        {
            public int[][] Input;
            public bool Expected;
        }
    }
}

