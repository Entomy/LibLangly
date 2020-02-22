using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public readonly partial struct Glyph {
		//! Please do not use graphemes in this table; use the fully escaped codepoints. The graphemes would be visually identical (that's the point }), and would be remarkably difficult to find and fix errors.

		private static readonly Object À = new Object();
		private static readonly Object Á = new Object();
		private static readonly Object Â = new Object();
		private static readonly Object Ã = new Object();
		private static readonly Object Ä = new Object();
		private static readonly Object Å = new Object();
		private static readonly Object Æ = new Object();
		private static readonly Object Ç = new Object();
		private static readonly Object È = new Object();
		private static readonly Object É = new Object();
		private static readonly Object Ê = new Object();
		private static readonly Object Ë = new Object();
		private static readonly Object Ì = new Object();
		private static readonly Object Í = new Object();
		private static readonly Object Î = new Object();
		private static readonly Object Ï = new Object();
		private static readonly Object Ñ = new Object();
		private static readonly Object Ò = new Object();
		private static readonly Object Ó = new Object();
		private static readonly Object Ô = new Object();
		private static readonly Object Õ = new Object();
		private static readonly Object Ö = new Object();
		private static readonly Object Ù = new Object();
		private static readonly Object Ú = new Object();
		private static readonly Object Û = new Object();
		private static readonly Object Ü = new Object();
		private static readonly Object Ý = new Object();
		private static readonly Object à = new Object();
		private static readonly Object á = new Object();
		private static readonly Object â = new Object();
		private static readonly Object ã = new Object();
		private static readonly Object ä = new Object();
		private static readonly Object å = new Object();
		private static readonly Object æ = new Object();
		private static readonly Object ç = new Object();
		private static readonly Object è = new Object();
		private static readonly Object é = new Object();
		private static readonly Object ê = new Object();
		private static readonly Object ë = new Object();
		private static readonly Object ì = new Object();
		private static readonly Object í = new Object();
		private static readonly Object î = new Object();
		private static readonly Object ï = new Object();
		private static readonly Object ñ = new Object();
		private static readonly Object ò = new Object();
		private static readonly Object ó = new Object();
		private static readonly Object ô = new Object();
		private static readonly Object õ = new Object();
		private static readonly Object ö = new Object();
		private static readonly Object ù = new Object();
		private static readonly Object ú = new Object();
		private static readonly Object û = new Object();
		private static readonly Object ü = new Object();
		private static readonly Object ý = new Object();
		private static readonly Object ÿ = new Object();

		/// <summary>
		/// Invariant equivalency table.
		/// </summary>
		/// <remarks>
		/// This intends to implement UAX#29 (https://unicode.org/reports/tr29/).
		/// </remarks>
		[SuppressMessage("Major Bug", "S3263:Static fields should appear in the order they must be initialized ", Justification = "It's almost like that's why this is at the bottom...")]
		internal static readonly Table InvariantTable = new Table(
			#region Latin-1 Supplement
			new KeyValuePair<String, Object>("\u00C0", À),
			new KeyValuePair<String, Object>("\u0041\u0300", À),
			new KeyValuePair<String, Object>("\u00C1", Á),
			new KeyValuePair<String, Object>("\u0041\u0301", Á),
			new KeyValuePair<String, Object>("\u00C2", Â),
			new KeyValuePair<String, Object>("\u0041\u0302", Â),
			new KeyValuePair<String, Object>("\u00C3", Ã),
			new KeyValuePair<String, Object>("\u0041\u0303", Ã),
			new KeyValuePair<String, Object>("\u00C4", Ä),
			new KeyValuePair<String, Object>("\u0041\u0308", Ä),
			new KeyValuePair<String, Object>("\u00C5", Å),
			new KeyValuePair<String, Object>("\u0041\u030A", Å),
			new KeyValuePair<String, Object>("\u00C6", Æ),
			new KeyValuePair<String, Object>("\u0041\u0045", Æ),
			new KeyValuePair<String, Object>("\u00C7", Ç),
			new KeyValuePair<String, Object>("\u0043\u0327", Ç),
			new KeyValuePair<String, Object>("\u00C8", È),
			new KeyValuePair<String, Object>("\u0045\u0300", È),
			new KeyValuePair<String, Object>("\u00C9", É),
			new KeyValuePair<String, Object>("\u0045\u0301", É),
			new KeyValuePair<String, Object>("\u00CA", Ê),
			new KeyValuePair<String, Object>("\u0045\u0302", Ê),
			new KeyValuePair<String, Object>("\u00CB", Ë),
			new KeyValuePair<String, Object>("\u0045\u0308", Ë),
			new KeyValuePair<String, Object>("\u00CC", Ì),
			new KeyValuePair<String, Object>("\u0049\u0300", Ì),
			new KeyValuePair<String, Object>("\u00CD", Í),
			new KeyValuePair<String, Object>("\u0049\u0301", Í),
			new KeyValuePair<String, Object>("\u00CE", Î),
			new KeyValuePair<String, Object>("\u0049\u0302", Î),
			new KeyValuePair<String, Object>("\u00CF", Ï),
			new KeyValuePair<String, Object>("\u0049\u0308", Ï),
			new KeyValuePair<String, Object>("\u00D1", Ñ),
			new KeyValuePair<String, Object>("\u004E\u0303", Ñ),
			new KeyValuePair<String, Object>("\u00D2", Ò),
			new KeyValuePair<String, Object>("\u004F\u0300", Ò),
			new KeyValuePair<String, Object>("\u00D3", Ó),
			new KeyValuePair<String, Object>("\u004F\u0301", Ó),
			new KeyValuePair<String, Object>("\u00D4", Ô),
			new KeyValuePair<String, Object>("\u004F\u0302", Ô),
			new KeyValuePair<String, Object>("\u00D5", Õ),
			new KeyValuePair<String, Object>("\u004F\u0303", Õ),
			new KeyValuePair<String, Object>("\u00D6", Ö),
			new KeyValuePair<String, Object>("\u004F\u0308", Ö),
			new KeyValuePair<String, Object>("\u00D9", Ù),
			new KeyValuePair<String, Object>("\u0055\u0300", Ù),
			new KeyValuePair<String, Object>("\u00DA", Ú),
			new KeyValuePair<String, Object>("\u0055\u0301", Ú),
			new KeyValuePair<String, Object>("\u00DB", Û),
			new KeyValuePair<String, Object>("\u0055\u0302", Û),
			new KeyValuePair<String, Object>("\u00DC", Ü),
			new KeyValuePair<String, Object>("\u0055\u0308", Ü),
			new KeyValuePair<String, Object>("\u00DD", Ý),
			new KeyValuePair<String, Object>("\u0059\u0301", Ý),
			new KeyValuePair<String, Object>("\u00E0", à),
			new KeyValuePair<String, Object>("\u0061\u0300", à),
			new KeyValuePair<String, Object>("\u00E1", á),
			new KeyValuePair<String, Object>("\u0061\u0301", á),
			new KeyValuePair<String, Object>("\u00E2", â),
			new KeyValuePair<String, Object>("\u0061\u0302", â),
			new KeyValuePair<String, Object>("\u00E3", ã),
			new KeyValuePair<String, Object>("\u0061\u0303", ã),
			new KeyValuePair<String, Object>("\u00E4", ä),
			new KeyValuePair<String, Object>("\u0061\u0308", ä),
			new KeyValuePair<String, Object>("\u00E5", å),
			new KeyValuePair<String, Object>("\u0061\u030A", å),
			new KeyValuePair<String, Object>("\u00E6", æ),
			new KeyValuePair<String, Object>("\u0061\u0065", æ),
			new KeyValuePair<String, Object>("\u00E7", ç),
			new KeyValuePair<String, Object>("\u0063\u0327", ç),
			new KeyValuePair<String, Object>("\u00E8", è),
			new KeyValuePair<String, Object>("\u0065\u0300", è),
			new KeyValuePair<String, Object>("\u00E9", é),
			new KeyValuePair<String, Object>("\u0065\u0301", é),
			new KeyValuePair<String, Object>("\u00EA", ê),
			new KeyValuePair<String, Object>("\u0065\u0302", ê),
			new KeyValuePair<String, Object>("\u00EB", ë),
			new KeyValuePair<String, Object>("\u0065\u0308", ë),
			new KeyValuePair<String, Object>("\u00EC", ì),
			new KeyValuePair<String, Object>("\u0069\u0300", ì),
			new KeyValuePair<String, Object>("\u00ED", í),
			new KeyValuePair<String, Object>("\u0069\u0301", í),
			new KeyValuePair<String, Object>("\u00EE", î),
			new KeyValuePair<String, Object>("\u0069\u0302", î),
			new KeyValuePair<String, Object>("\u00EF", ï),
			new KeyValuePair<String, Object>("\u0069\u0308", ï),
			new KeyValuePair<String, Object>("\u00F1", ñ),
			new KeyValuePair<String, Object>("\u006E\u0303", ñ),
			new KeyValuePair<String, Object>("\u00F2", ò),
			new KeyValuePair<String, Object>("\u006F\u0300", ò),
			new KeyValuePair<String, Object>("\u00F3", ó),
			new KeyValuePair<String, Object>("\u006F\u0301", ó),
			new KeyValuePair<String, Object>("\u00F4", ô),
			new KeyValuePair<String, Object>("\u006F\u0302", ô),
			new KeyValuePair<String, Object>("\u00F5", õ),
			new KeyValuePair<String, Object>("\u006F\u0303", õ),
			new KeyValuePair<String, Object>("\u00F6", ö),
			new KeyValuePair<String, Object>("\u006F\u0308", ö),
			new KeyValuePair<String, Object>("\u00F9", ù),
			new KeyValuePair<String, Object>("\u0075\u0300", ù),
			new KeyValuePair<String, Object>("\u00FA", ú),
			new KeyValuePair<String, Object>("\u0075\u0301", ú),
			new KeyValuePair<String, Object>("\u00FB", û),
			new KeyValuePair<String, Object>("\u0075\u0302", û),
			new KeyValuePair<String, Object>("\u00FC", ü),
			new KeyValuePair<String, Object>("\u0075\u0308", ü),
			new KeyValuePair<String, Object>("\u00FD", ý),
			new KeyValuePair<String, Object>("\u0079\u0301", ý),
			new KeyValuePair<String, Object>("\u00FE", ÿ),
			new KeyValuePair<String, Object>("\u0079\u0308", ÿ)
			#endregion
			);
	}
}
