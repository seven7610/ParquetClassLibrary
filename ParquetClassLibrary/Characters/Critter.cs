using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Characters
{
    public class Critter : Character
    {
        #region Characteristics
        /// <summary>The type of critter this is.</summary>
        public EntityID CritterType { get; private set; }

        /// <summary>Types of parquets this critter avoids.</summary>
        public readonly List<EntityID> Avoids = new List<EntityID>();

        /// <summary>Types of parquets this critter seeks out.</summary>
        public readonly List<EntityID> Seeks = new List<EntityID>();
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Characters.Critter"/> class.
        /// </summary>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this character is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this character acts.  Cannot be null.</param>
        /// <param name="in_currentLocation">Where this character currently is.</param>
        /// <param name="in_id">Unique identifier for the character.  If null, a new ID will be created.</param>
        /// <param name="in_critterType">The type of critter this is.</param>
        /// <param name="in_avoids">Any parquets this critter avoids.</param>
        /// <param name="in_seeks">Any parquets this critter seeks.</param>
        protected Critter(Biome in_nativeBiome, Behavior in_currentBehavior, Location in_currentLocation,
                          Guid? in_id = null, EntityID? in_critterType = null,
                          List<EntityID> in_avoids = null, List<EntityID> in_seeks = null)
            : base(in_nativeBiome, in_currentBehavior, in_currentLocation, in_id)
        {
            var nonNullCritterType = in_critterType ?? EntityID.None;
            if (!nonNullCritterType.IsValidForRange(AssemblyInfo.CritterIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_critterType));
            }
            foreach (var parquetID in in_avoids)
            {
                if (!parquetID.IsValidForRange(AssemblyInfo.FloorIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.BlockIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.FurnishingIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.CollectibleIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_avoids));
                }
            }
            foreach (var parquetID in in_seeks)
            {
                if (!parquetID.IsValidForRange(AssemblyInfo.FloorIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.BlockIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.FurnishingIDs)
                    && !parquetID.IsValidForRange(AssemblyInfo.CollectibleIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_seeks));
                }
            }

            CritterType = nonNullCritterType;
            Avoids.AddRange(in_avoids);
            Seeks.AddRange(in_seeks);
        }
        #endregion
    }
}
