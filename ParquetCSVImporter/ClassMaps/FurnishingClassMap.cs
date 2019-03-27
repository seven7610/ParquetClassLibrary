﻿using CsvHelper.Configuration;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.FurnishingShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public class FurnishingClassMap : ClassMap<FurnishingShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.FurnishingClassMap"/> class.
        /// </summary>
        public FurnishingClassMap()
        {
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);
        }
    }
}