using System;
using System.Collections.Generic;

namespace Stringier {
    public readonly partial struct Glyph {
        /// <summary>
        /// Represents an equivalency table used for <see cref="Glyph"/> equality and comparisons.
        /// </summary>
        internal class Table {
            /// <summary>
            /// The set of equivalencies in this table.
            /// </summary>
            private readonly Dictionary<String, Object> Equivalences;

			/// <summary>
			/// Initialize a new <see cref="Table"/> from the given <paramref name="equivalences"/>.
			/// </summary>
			/// <param name="equivalences">The set of equivalencies in this table.</param>
			internal Table(params KeyValuePair<String, Object>[] equivalences) {
				Equivalences = new Dictionary<String, Object>();
				foreach (KeyValuePair<String, Object> equivalence in equivalences) {
					Equivalences.Add(equivalence.Key, equivalence.Value);
				}
			}

			internal Object? this[String sequence] {
				get {
					_ = Equivalences.TryGetValue(sequence, out Object equivalence);
					return equivalence;
				}
			}
        }
    }
}
