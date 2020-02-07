using System;
using System.Collections.Generic;

namespace Stringier {
    public readonly partial struct Glyph {
        /// <summary>
        /// Represents the equivalence in <see cref="Glyph"/> sequences.
        /// </summary>
        internal class Equivalence : IEquatable<Glyph>, IEquatable<String> {
            /// <summary>
            /// The sequences which represent the <see cref="Glyph"/>.
            /// </summary>
            private readonly HashSet<String> Sequences;

            /// <summary>
            /// Initialize a new <see cref="Equivalence"/> from the given <paramref name="sequences"/>.
            /// </summary>
            /// <param name="sequences">The sequences which represent the <see cref="Glyph"/>.</param>
            internal Equivalence(params String[] sequences) => Sequences = new HashSet<String>(sequences);

			public Boolean Equals(Glyph other) {
				foreach (String sequence in Sequences) {
					if (String.Equals(sequence, other.Sequence, StringComparison.Ordinal)) {
						return true;
					}
				}
				return false;
			}

			public Boolean Equals(String other) {
				foreach (String sequence in Sequences) {
					if (String.Equals(sequence, other, StringComparison.Ordinal)) {
						return true;
					}
				}
				return false;
			}
        }
    }
}