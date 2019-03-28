﻿using CsvHelper.Configuration;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.CollectableShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public class CollectableClassMap : ClassMap<CollectableShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.CollectableClassMap"/> class.
        /// </summary>
        public CollectableClassMap()
        {
            // Properties are ordered by index to facility a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);

            Map(m => m.Effect).Index(3);
            Map(m => m.EffectAmount).Index(4);
            Map(m => m.ItemID).Index(5);
        }
    }
}
