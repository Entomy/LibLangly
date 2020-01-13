using System;

namespace Stringier.Internals {
	/// <summary>
	/// Helper class for tabular formatting.
	/// </summary>
	/// <remarks>
	/// This is essentially a semantic wrapper around what is conceptually a 2-dimensional array. The exact implementation will vary. Regardless, it provides the means to calculate things like maximal column width, and other useful properties when formatting.
	/// </remarks>
	internal sealed class FormatTable {
		/// <summary>
		/// The backing fields of the table.
		/// </summary>
		private readonly String[,] Fields;

		public FormatTable(String[,] fields) => Fields = fields;
	}
}
