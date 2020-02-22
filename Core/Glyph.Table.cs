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
            private readonly Dictionary<String, Char> Equivalences;

			/// <summary>
			/// Initialize a new <see cref="Table"/> from the given <paramref name="equivalences"/>.
			/// </summary>
			/// <param name="equivalences">The set of equivalencies in this table.</param>
			internal Table(params KeyValuePair<String, Char>[] equivalences) {
				Equivalences = new Dictionary<String, Char>();
				foreach (KeyValuePair<String, Char> equivalence in equivalences) {
					Equivalences.Add(equivalence.Key, equivalence.Value);
				}
			}

			internal Char this[String sequence] {
				get {
					_ = Equivalences.TryGetValue(sequence, out Char equivalence);
					return equivalence;
				}
			}
        }
    }
}
