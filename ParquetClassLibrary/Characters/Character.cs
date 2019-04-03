using ParquetClassLibrary.Sandbox;
using System;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Models a character in the game.
    /// </summary>
    public abstract class Character : IEquatable<Character>
    {
        #region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        protected readonly string DataVersion = AssemblyInfo.SupportedDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }

        /// <summary>The character's unique identifier.</summary>
        public readonly Guid ID;

        /// <summary>The <see cref="Biome"/> in which this character is at home.</summary>
        public Biome NativeBiome { get; set; }

        /// <summary>The <see cref="Behavior"/> governing the way this character acts.</summary>
        public Behavior CurrentBehavior { get; set; }

        /// <summary>The <see cref="Location"/> of this character acts.</summary>
        public Location CurrentLocation { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used <see cref="Character"/> subtypes.
        /// </summary>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this character is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this character acts.  Cannot be null.</param>
        /// <param name="in_currentLocation">Where this character currently is.</param>
        /// <param name="in_id">Unique identifier for the character.  If null, a new ID will be created.</param>
        protected Character(Biome in_nativeBiome, Behavior in_currentBehavior, Location in_currentLocation,
                            Guid? in_id = null)
        {
            ID = in_id ?? Guid.NewGuid();
            NativeBiome = in_nativeBiome;
            CurrentBehavior = in_currentBehavior;
            CurrentLocation = in_currentLocation;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> struct.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Character"/> is equal to the current
        /// <see cref="Character"/>.
        /// </summary>
        /// <param name="in_character">The <see cref="Character"/> to compare against this one.</param>
        /// <returns><c>true</c> if the <see cref="Character"/>s are equal.</returns>
        public bool Equals(Character in_character)
        {
            return null != in_character && ID == in_character.ID;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Character"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with this <see cref="Character"/>.</param>
        /// <returns>
        /// <c>true</c> if the given <see cref="object"/> is equal to this <see cref="Character"/>; otherwise, <c>false</c>.
        /// </returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Character character)
            {
                result = Equals(character);
            }

            return result;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Character"/> is equal to
        /// another specified instance of <see cref="Character"/>.
        /// </summary>
        /// <param name="in_character1">The first <see cref="Character"/> to compare.</param>
        /// <param name="in_character2">The second <see cref="Character"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Character in_character1, Character in_character2)
        {
            if (ReferenceEquals(in_character1, in_character2)) return true;
            if (ReferenceEquals(in_character1, null)) return false;
            if (ReferenceEquals(in_character2, null)) return false;

            return in_character1.ID == in_character2.ID;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Character"/> is unequal
        /// to another specified instance of <see cref="Character"/>.
        /// </summary>
        /// <param name="in_character1">The first <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <param name="in_character2">The second <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_vector1</c> and <c>in_vector2</c> are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Character in_character1, Character in_character2)
        {
            if (ReferenceEquals(in_character1, in_character2)) return false;
            if (ReferenceEquals(in_character1, null)) return true;
            if (ReferenceEquals(in_character2, null)) return true;

            return in_character1.ID != in_character2.ID;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see cref="string"/> that represents this <see cref="Character"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return ID.ToString();
        }
        #endregion
    }
}
