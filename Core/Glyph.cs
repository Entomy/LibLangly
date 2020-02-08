using System;

namespace Stringier {
    /// <summary>
    /// Represents a glyph; a UNICODE Grapheme Cluster.
    /// </summary>
    public readonly partial struct Glyph : IEquatable<Glyph> {
        /// <summary>
        /// The sequence representing this <see cref="Glyph"/> as it was found or declared.
        /// </summary>
        private readonly String Sequence;

		/// <summary>
		/// The <see cref="Equivalence"/> instance describing invariant equivalence rules.
		/// </summary>
		/// <remarks>
		/// This is preloaded, not lazy loaded, because the semantics of <see cref="Glyph"/> are entirely built around this, so it will be used.
		/// </remarks>
		private readonly Equivalence? InvariantEquivalence;

        /// <summary>
        /// Initializes a new <see cref="Glyph"/> from the given <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The sequence representing this <see cref="Glyph"/> as it was declared.</param>
        public Glyph(String sequence) {
			Sequence = sequence;
			InvariantEquivalence = InvariantTable[sequence];
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="obj">The object to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="obj"/> is the same as this instance; otherwise, <see langword="false">. If <paramref name="obj"/> is <see langword="null"/>, the method returns <see langword="false">.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Glyph glyph:
				return Equals(glyph);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and another specified String object have the same value.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public Boolean Equals(Glyph other) => InvariantEquivalence?.Equals(other) ?? String.Equals(Sequence, other.Sequence, StringComparison.Ordinal);

		/// <summary>
		/// Returns the hash code for this glyph.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => InvariantEquivalence?.GetHashCode() ?? Sequence.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override String ToString() => Sequence;
    }
}