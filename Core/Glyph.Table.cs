using System;
using System.Collections.Generic;

namespace Stringier {
    public readonly partial struct Glyph {
        /// <summary>
        /// Represents an <see cref="Equivalence"/> table used for <see cref="Glyph"/> equality and comparisons.
        /// </summary>
        internal class Table {
            /// <summary>
            /// The set of <see cref="Equivalence"/> in this table.
            /// </summary>
            private readonly HashSet<Equivalence> Equivalences;

            /// <summary>
            /// Initialize a new <see cref="Table"/> from the given <paramref name="equivalences"/>.
            /// </summary>
            /// <param name="equivalences">The set of <see cref="Equivalence"/> in this table.</param>
            internal Table(params Equivalence[] equivalences) => Equivalences = new HashSet<Equivalence>(equivalences);

			internal Equivalence? this[Glyph glyph] {
				get {
					foreach (Equivalence equivalence in Equivalences) {
						if (equivalence.Equals(glyph)) {
							return equivalence;
						}
					}
					return null;
				}
			}

			internal Equivalence? this[String sequence] {
				get {
					foreach (Equivalence equivalence in Equivalences) {
						if (equivalence.Equals(sequence)) {
							return equivalence;
						}
					}
					return null;
				}
			}
        }
    }
}
