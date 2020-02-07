using System;

namespace Stringier {
	public readonly partial struct Glyph {
		//! Please do not use graphemes in this table; use the fully escaped codepoints. The graphemes would be visually identical (that's the point), and would be remarkably difficult to find and fix errors.

		/// <summary>
		/// Invariant equivalency table.
		/// </summary>
		/// <remarks>
		/// This intends to implement UAX#29 (https://unicode.org/reports/tr29/).
		/// </remarks>
		internal static readonly Table InvariantTable = new Table(
			new Equivalence("\u00C0", "\u0041\u0300") // À
			);
	}
}