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

		private readonly Equivalence? InvariantEquivalence;

        /// <summary>
        /// Initializes a new <see cref="Glyph"/> from the given <paramref name="sequence"/>.
        /// </summary>
        /// <param name="sequence">The sequence representing this <see cref="Glyph"/> as it was declared.</param>
        public Glyph(String sequence) {
			Sequence = sequence;
			InvariantEquivalence = InvariantTable[sequence];
		}

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Glyph glyph:
				return Equals(glyph);
			default:
				return false;
			}
		}

		public Boolean Equals(Glyph other) => InvariantEquivalence?.Equals(other) ?? String.Equals(Sequence, other.Sequence, StringComparison.Ordinal);

		public override Int32 GetHashCode() => InvariantEquivalence?.GetHashCode() ?? Sequence.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override String ToString() => Sequence;
    }
}