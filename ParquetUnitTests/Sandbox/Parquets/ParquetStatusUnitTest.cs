using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class ParquetStatusUnitTest
    {
        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var validStack = new ParquetStack(TestParquets.TestFloor, TestParquets.TestBlock,
                                              TestParquets.TestFurnishing, TestParquets.TestCollectible);
            var testStatus = new ParquetStatus(validStack);

            testStatus.Toughness = int.MinValue;

            Assert.Equal(Block.LowestPossibleToughness, testStatus.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var validStack = new ParquetStack(TestParquets.TestFloor, TestParquets.TestBlock,
                                              TestParquets.TestFurnishing, TestParquets.TestCollectible);
            var testStatus = new ParquetStatus(validStack);

            var priorToughness = testStatus.Toughness;

            testStatus.Toughness = int.MaxValue;

            Assert.Equal(priorToughness, testStatus.Toughness);
        }
    }
}
