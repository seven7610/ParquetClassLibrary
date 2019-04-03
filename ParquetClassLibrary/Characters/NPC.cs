using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Characters
{
    public class NPC : Character
    {
        #region Class Defaults
        /// <summary>Default name for new <see cref="NPC"/>s.</summary>
        internal const string DefaultName = "New Character";
        #endregion

        #region Characteristics
        /// <summary>The name the NPC is known by.</summary>
        // TODO Revisit this accessibility.
        public string Name { get; set; }

        /// <summary>The pronouns the NPC uses.</summary>
        // TODO This is just a place-holder, I am not sure yet how we will handle pronouns.
        // TODO Revisit this accessibility.
        public string Pronoun { get; set; }

        /// <summary>Types of parquets this NPC avoids.</summary>
        public readonly List<EntityID> Avoids = new List<EntityID>();

        /// <summary>Types of parquets this NPC seeks out.</summary>
        public readonly List<EntityID> Seeks = new List<EntityID>();

        /// <summary>Types of parquets this NPC avoids.</summary>
        public readonly List<EntityID> Quests = new List<EntityID>();

        /// <summary>Dialogue lines this NPC can say.</summary>
        // TODO This is just a place-holder, I am not at all sure how we will handle this.
        public readonly List<string> Dialogue = new List<string>();

        /// <summary>This NPC's belongings.</summary>
        // TODO This is just a place-holder, inventory may need its own class.
        public readonly List<EntityID> Inventory = new List<EntityID>();
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="NPC"/> class.
        /// </summary>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this character is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this character acts.  Cannot be null.</param>
        /// <param name="in_currentLocation">Where this character currently is.</param>
        /// <param name="in_id">Unique identifier for the character.  If null, a new ID will be created.</param>
        /// <param name="in_avoids">Any parquets this character avoids.</param>
        /// <param name="in_seeks">Any parquets this character seeks.</param>
        /// <param name="in_quests">Any quests this character has to offer.</param>
        /// <param name="in_dialogue">All dialogue this character may say.</param>
        /// <param name="in_inventory">Any items this character owns.</param>
        protected NPC(Biome in_nativeBiome, Behavior in_currentBehavior, Location in_currentLocation,
                      Guid? in_id = null, string in_name = DefaultName,
                      List<EntityID> in_avoids = null, List<EntityID> in_seeks = null,
                      List<EntityID> in_quests = null, List<string> in_dialogue = null,
                      List<EntityID> in_inventory = null)
            : base(in_nativeBiome, in_currentBehavior, in_currentLocation, in_id)
        {
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
            foreach (var questID in in_seeks)
            {
                if (!questID.IsValidForRange(AssemblyInfo.QuestIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_quests));
                }
            }
            foreach (var itemID in in_seeks)
            {
                if (!itemID.IsValidForRange(AssemblyInfo.ItemIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_inventory));
                }
            }

            Name = in_name;
            Avoids.AddRange(in_avoids);
            Seeks.AddRange(in_seeks);
            Quests.AddRange(in_quests);
            Dialogue.AddRange(in_dialogue);
            Inventory.AddRange(in_inventory);
        }
        #endregion
    }
}
