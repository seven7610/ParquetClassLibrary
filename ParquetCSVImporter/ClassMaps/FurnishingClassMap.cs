using CsvHelper.Configuration;

// ReSharper disable InconsistentNaming

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.FurnishingShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class FurnishingClassMap : ClassMap<FurnishingShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.FurnishingClassMap"/> class.
        /// </summary>
        public FurnishingClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);

            Map(m => m.IsWalkable).Index(3);
            Map(m => m.ItemID).Index(4);
            Map(m => m.SwapID).Index(5);
        }
    }
}
