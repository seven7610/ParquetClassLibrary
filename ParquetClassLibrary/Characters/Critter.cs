using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Characters
{
    public class Critter : Character
    {
        #region Class Defaults
        ///<summary>Dimensions in parquets.  Defined by child classes.</summary>
        //public abstract Vector2Int DimensionsInParquets { get; }
        #endregion

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
        /// Used <see cref="Character"/> subtypes.
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

            CritterType = nonNullCritterType;
            Avoids.AddRange(in_avoids);
            Seeks.AddRange(in_seeks);
        }
        #endregion
    }
}
