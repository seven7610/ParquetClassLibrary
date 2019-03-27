using System.Collections.Generic;
using CsvHelper;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides extensions to the CSV Reader.
    /// </summary>
    public static class CsvReaderExtensions
    {
        /// <summary>
        /// Gets a set of records from the CSV Reader using the shim class that corresponds to the given type.
        /// </summary>
        /// <param name="in_csv">In CSV Reader.</param>
        /// <typeparam name="T">The type of the record.</typeparam>
        /// <returns>The records.</returns>
        public static IEnumerable<T> GetRecordsViaShim<T>(this CsvReader in_csv) where T : ParquetParent
        {
            var result = new List<T>();
            IEnumerable<ParquetParentShim> shims;

            if (typeof(T) == typeof(Floor))
            {
                shims = in_csv.GetRecords<FloorShim>();
            }
            else if (typeof(T) == typeof(Block))
            {
                shims = in_csv.GetRecords<BlockShim>();
            }
            else if (typeof(T) == typeof(Furnishing))
            {
                shims = in_csv.GetRecords<FurnishingShim>();
            }
            else if (typeof(T) == typeof(Collectable))
            {
                shims = in_csv.GetRecords<CollectableShim>();
            }
            else
            {
                shims = new List<ParquetParentShim>();
                Error.Handle($"No shim exists for {typeof(T).ToString()}");
            }

            foreach (var shim in shims)
            {
                result.Add(shim.To<T>());
            }

            return result;
        }
    }
}