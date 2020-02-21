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
            private readonly Dictionary<String, Equivalence> Equivalences;

			/// <summary>
			/// Initialize a new <see cref="Table"/> from the given <paramref name="equivalences"/>.
			/// </summary>
			/// <param name="equivalences">The set of <see cref="Equivalence"/> in this table.</param>
			internal Table(params KeyValuePair<String, Equivalence>[] equivalences) {
				Equivalences = new Dictionary<String, Equivalence>();
				foreach (KeyValuePair<String, Equivalence> equivalence in equivalences) {
					Equivalences.Add(equivalence.Key, equivalence.Value);
				}
			}

			internal Equivalence? this[String sequence] {
				get {
					_ = Equivalences.TryGetValue(sequence, out Equivalence equivalence);
					return equivalence;
				}
			}
        }
    }
}
