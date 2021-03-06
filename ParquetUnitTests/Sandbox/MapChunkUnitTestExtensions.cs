﻿using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox
{
    /// <summary>
    /// Provides extension methods of <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> used in unit testing.
    /// </summary>
    internal static class MapChunkUnitTestExtensions
    {
        /// <summary>Fills the chunk with a test pattern.</summary>
        public static MapChunk FillTestPattern(this MapChunk in_mapChunk)
        {
            for (var x = 0; x < in_mapChunk.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < in_mapChunk.DimensionsInParquets.Y; y++)
                {
                    in_mapChunk.TrySetFloor(TestParquets.TestFloor.ID, new Vector2Int(x, y));
                }

                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, 0));
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, in_mapChunk.DimensionsInParquets.Y - 1));
            }
            for (var y = 0; y < in_mapChunk.DimensionsInParquets.Y; y++)
            {
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(0, y));
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(in_mapChunk.DimensionsInParquets.X - 1, y));
            }
            in_mapChunk.TrySetFurnishing(TestParquets.TestFurnishing.ID, new Vector2Int(1, 2));
            in_mapChunk.TrySetCollectible(TestParquets.TestCollectible.ID, new Vector2Int(3, 3));

            return in_mapChunk;
        }
    }
}
