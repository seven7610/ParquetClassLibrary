using System;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class Vector2IntUnitTest
    {
        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0, Vector2Int.ZeroVector.X);
            Assert.Equal(0, Vector2Int.ZeroVector.Y);
            Assert.Equal(0, Vector2Int.ZeroVector.Magnitude);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(-1, 1)]
        [InlineData(0,  0)]
        [InlineData(1, -1)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void NewVectorTest(int in_x, int in_y)
        {
            var testVector = new Vector2Int(in_x, in_y);

            Assert.Equal(in_x, testVector.X);
            Assert.Equal(in_y, testVector.Y);
            var magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(in_x * in_x + in_y * in_y)));
            Assert.Equal(magnitude, testVector.Magnitude);
        }
    }
}
