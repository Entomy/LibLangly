using System;
using System.Collections.Generic;
using System.Text;

namespace Generators {
	public static partial class GlyphTables {
		/// <summary>
		/// Splits the <paramref name="entry"/> into its individual sequences.
		/// </summary>
		/// <param name="entry">The data entry.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of the individual sequences.</returns>
		private static IEnumerable<String> Sequences(String entry) {
			StringBuilder result = new StringBuilder();
			foreach (String sequence in entry.Split(',')) {
				_ = result.Clear();
				foreach (String part in sequence.Split(' ')) {
					_ = result.Append("\\u").Append(part);
				}
				yield return result.ToString();
			}
		}
	}
}
