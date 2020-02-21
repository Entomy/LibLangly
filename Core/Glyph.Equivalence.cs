using System;
using System.Collections.Generic;
using System.Text;
using Defender;

namespace Stringier {
    public readonly partial struct Glyph {
        /// <summary>
        /// Represents the equivalence in <see cref="Glyph"/> sequences.
        /// </summary>
        internal class Equivalence : IEquatable<Char>, IEquatable<Glyph>, IEquatable<Rune>, IEquatable<String> {
            /// <summary>
            /// The sequences which represent the <see cref="Glyph"/>.
            /// </summary>
            private readonly HashSet<String> Sequences;

			/// <summary>
			/// Initialize a new <see cref="Equivalence"/> from the given <paramref name="sequences"/>.
			/// </summary>
			/// <param name="sequences">The sequences which represent the <see cref="Glyph"/>.</param>
			internal Equivalence(params String[] sequences) {
				Guard.NotNull(sequences, nameof(sequences));
				Guard.GreaterThanOrEqualTo(sequences, nameof(sequences), 1);
				Sequences = new HashSet<String>(sequences);
			}

			public Boolean Equals(Char other) {
				foreach (String sequence in Sequences) {
					if (sequence.Length == 1 && Equals(sequence[0], other)) {
						return true;
					}
				}
				return false;
			}

			public Boolean Equals(Glyph other) {
				foreach (String sequence in Sequences) {
					if (String.Equals(sequence, other.Sequence, StringComparison.InvariantCulture)) {
						return true;
					}
				}
				return false;
			}

			public Boolean Equals(Rune other) {
				Span<Char> buffer = new Char[2];
				Int32 charsCount = other.EncodeToUtf16(buffer);
				foreach (String sequence in Sequences) {
					if (sequence.Length <= 2 && sequence.AsSpan().Slice(0, charsCount).Equals(buffer.Slice(0, charsCount), StringComparison.InvariantCulture)) {
						return true;
					}
				}
				return false;
			}

			public Boolean Equals(String other) {
				foreach (String sequence in Sequences) {
					if (String.Equals(sequence, other, StringComparison.InvariantCulture)) {
						return true;
					}
				}
				return false;
			}
        }
    }
}