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
			#region Latin-1 Extended
			new Equivalence("\u00C0", "\u0041\u0300"), // À
			new Equivalence("\u00C1", "\u0041\u0301"), // Á
			new Equivalence("\u00C2", "\u0041\u0302"), // Â
			new Equivalence("\u00C3", "\u0041\u0303"), // Ã
			new Equivalence("\u00C4", "\u0041\u0304"), // Ä
			new Equivalence("\u00C5", "\u0041\u030A"), // Å
			new Equivalence("\u00C6", "\u0041\u0045"), // Æ
			new Equivalence("\u00C7", "\u0043\u0327"), // Ç
			new Equivalence("\u00C8", "\u0045\u0300"), // È
			new Equivalence("\u00C9", "\u0045\u0301"), // É
			new Equivalence("\u00CA", "\u0045\u0302"), // Ê
			new Equivalence("\u00CB", "\u0045\u0304"), // Ë
			new Equivalence("\u00CC", "\u0049\u0300"), // Ì
			new Equivalence("\u00CD", "\u0049\u0301"), // Í
			new Equivalence("\u00CE", "\u0049\u0302"), // Î
			new Equivalence("\u00CF", "\u0049\u0304"), // Ï
			new Equivalence("\u00D1", "\u004E\u0303"), // Ñ
			new Equivalence("\u00D2", "\u004F\u0300"), // Ò
			new Equivalence("\u00D3", "\u004F\u0301"), // Ó
			new Equivalence("\u00D4", "\u004F\u0302"), // Ô
			new Equivalence("\u00D5", "\u004F\u0303"), // Õ
			new Equivalence("\u00D6", "\u004F\u0304"), // Ö
			new Equivalence("\u00D9", "\u0055\u0300"), // Ù
			new Equivalence("\u00DA", "\u0055\u0301"), // Ú
			new Equivalence("\u00DB", "\u0055\u0302"), // Û
			new Equivalence("\u00DC", "\u0055\u0304"), // Ü
			new Equivalence("\u00DD", "\u0059\u0301"), // Ý
			new Equivalence("\u00E0", "\u0061\u0300"), // à
			new Equivalence("\u00E1", "\u0061\u0301"), // á
			new Equivalence("\u00E2", "\u0061\u0302"), // â
			new Equivalence("\u00E3", "\u0061\u0303"), // ã
			new Equivalence("\u00E4", "\u0061\u0304"), // ä
			new Equivalence("\u00E5", "\u0061\u030A"), // å
			new Equivalence("\u00E6", "\u0061\u0065"), // æ
			new Equivalence("\u00E7", "\u0063\u0327"), // ç
			new Equivalence("\u00E8", "\u0065\u0300"), // è
			new Equivalence("\u00E9", "\u0065\u0301"), // é
			new Equivalence("\u00EA", "\u0065\u0302"), // ê
			new Equivalence("\u00EB", "\u0065\u0304"), // ë
			new Equivalence("\u00EC", "\u0069\u0300"), // ì
			new Equivalence("\u00ED", "\u0069\u0301"), // í
			new Equivalence("\u00EE", "\u0069\u0302"), // î
			new Equivalence("\u00EF", "\u0069\u0304"), // ï
			new Equivalence("\u00F1", "\u006E\u0303"), // ñ
			new Equivalence("\u00F2", "\u006F\u0300"), // ò
			new Equivalence("\u00F3", "\u006F\u0301"), // ó
			new Equivalence("\u00F4", "\u006F\u0302"), // ô
			new Equivalence("\u00F5", "\u006F\u0303"), // õ
			new Equivalence("\u00F6", "\u006F\u0304"), // ö
			new Equivalence("\u00F9", "\u0075\u0300"), // ù
			new Equivalence("\u00FA", "\u0075\u0301"), // ú
			new Equivalence("\u00FB", "\u0075\u0302"), // û
			new Equivalence("\u00FC", "\u0075\u0304"), // ü
			new Equivalence("\u00FD", "\u0079\u0301"), // ý
			new Equivalence("\u00FE", "\u0079\u0304") // ÿ
			#endregion
			);
	}
}