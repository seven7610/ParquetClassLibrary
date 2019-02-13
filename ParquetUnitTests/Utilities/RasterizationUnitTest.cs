using Xunit;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Utilities
{
    public class RasterizationUnitTest
    {
        [Fact]
        public void PlotLineCompletesStraightHorizontalLineTest()
        {
            const int leftBound = 1;
            const int rightBound = 10;
            var leftEnd = new Vector2Int(leftBound, 0);
            var rightEnd = new Vector2Int(rightBound, 0);
            var vectors = Rasterization.PlotLine(leftEnd, rightEnd, (a) => { return true; });

            for (var x = leftBound; x <= rightBound; x++)
            {
                var position = new Vector2Int(x, 0);
                Assert.True(vectors.Remove(position));
            }

            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotLineCompletesStraightVerticalLineTest()
        {
            const int upperBound = 1;
            const int lowerBound = 10;
            var top = new Vector2Int(0, upperBound);
            var bottom = new Vector2Int(0, lowerBound);
            var vectors = Rasterization.PlotLine(top, bottom, (a) => { return true; });

            for (var y = upperBound; y <= lowerBound; y++)
            {
                var position = new Vector2Int(0, y);
                Assert.True(vectors.Remove(position));
            }

            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotLineCompletesDiagonalLineWithUnitSlopeTest()
        {
            const int upperLeftBound = 1;
            const int lowerRightBound = 10;
            var upperLeftEnd = new Vector2Int(upperLeftBound, upperLeftBound);
            var lowerRightEnd = new Vector2Int(lowerRightBound, lowerRightBound);
            var vectors = Rasterization.PlotLine(upperLeftEnd, lowerRightEnd, (a) => { return true; });

            for (var i = upperLeftBound; i <= lowerRightBound; i++)
            {
                var position = new Vector2Int(i, i);
                Assert.True(vectors.Remove(position));
            }

            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotFilledRectangleCompletesSolidSquareTest()
        {
            const int upperLeftBound = 1;
            const int lowerRightBound = 9;
            var upperLeftCorner = new Vector2Int(upperLeftBound, upperLeftBound);
            var lowerRightCorner = new Vector2Int(lowerRightBound, lowerRightBound);
            var vectors = Rasterization.PlotFilledRectangle(upperLeftCorner, lowerRightCorner, (a) => { return true; });

            for (var x = upperLeftBound; x <= lowerRightBound; x++)
            {
                for (var y = upperLeftBound; y <= lowerRightBound; y++)
                {
                    var position = new Vector2Int(x, y);
                    Assert.True(vectors.Remove(position));
                }
            }

            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotEmptyRectangleCompletesSquareOutlineTest()
        {
            const int upperLeftBound = 1;
            const int lowerRightBound = 9;
            var upperLeftCorner = new Vector2Int(upperLeftBound, upperLeftBound);
            var lowerRightCorner = new Vector2Int(lowerRightBound, lowerRightBound);
            var vectors = Rasterization.PlotEmptyRectangle(upperLeftCorner, lowerRightCorner, (a) => { return true; });

            for (var x = upperLeftBound; x <= lowerRightBound; x++)
            {
                var position = new Vector2Int(x, upperLeftBound);
                Assert.True(vectors.Remove(position));
                position = new Vector2Int(x, lowerRightBound);
                Assert.True(vectors.Remove(position));
            }
            for (var y = upperLeftBound + 1; y < lowerRightBound; y++)
            {
                var position = new Vector2Int(upperLeftBound, y);
                Assert.True(vectors.Remove(position));
                position = new Vector2Int(lowerRightBound, y);
                Assert.True(vectors.Remove(position));
            }

            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotCircleCompletesMinimalFilledTest()
        {
            const int location = 3;
            const int radius = 1;
            var center = new Vector2Int(location, location);
            var aboveCenter = new Vector2Int(location, location - 1);
            var leftOfCenter = new Vector2Int(location - 1, location);
            var rightOfCenter = new Vector2Int(location + 1, location);
            var belowCenter = new Vector2Int(location, location + 1);

            var vectors = Rasterization.PlotCircle(center, radius, true, (a) => { return true; });

            Assert.True(vectors.Remove(center));
            Assert.True(vectors.Remove(aboveCenter));
            Assert.True(vectors.Remove(leftOfCenter));
            Assert.True(vectors.Remove(rightOfCenter));
            Assert.True(vectors.Remove(belowCenter));
            Assert.Empty(vectors);
        }

        [Fact]
        public void PlotCircleCompletesMinimalOutlineTest()
        {
            const int location = 3;
            const int radius = 1;
            var center = new Vector2Int(location, location);
            var aboveCenter = new Vector2Int(location, location - 1);
            var leftOfCenter = new Vector2Int(location - 1, location);
            var rightOfCenter = new Vector2Int(location + 1, location);
            var belowCenter = new Vector2Int(location, location + 1);

            var vectors = Rasterization.PlotCircle(center, radius, false, (a) => { return true; });

            Assert.False(vectors.Remove(center));
            Assert.True(vectors.Remove(aboveCenter));
            Assert.True(vectors.Remove(leftOfCenter));
            Assert.True(vectors.Remove(rightOfCenter));
            Assert.True(vectors.Remove(belowCenter));
            Assert.Empty(vectors);
        }
    }
}