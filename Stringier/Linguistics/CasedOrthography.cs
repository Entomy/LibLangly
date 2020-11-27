using System;
using System.Text;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents an <see cref="Orthography"/> with casing.
	/// </summary>
	internal sealed class CasedOrthography : Orthography<Map> {
		/// <inheritdoc/>
		internal CasedOrthography(Part numbers, Part characters, params Map[] maps) : base(numbers, characters, maps) { }

		/// <inheritdoc/>
		protected internal override Char ToLower(Char @char) {
			foreach (Map map in Graphemes) {
				if (@char == map.Upper) {
					return (Char)map.Lower.Code;
				}
			}
			return @char.ToLower();
		}

		/// <inheritdoc/>
		protected internal override Rune ToLower(Rune rune) {
			foreach (Map map in Graphemes) {
				if (rune == map.Upper) {
					return new Rune(map.Lower.Code);
				}
			}
			return rune.ToLower();
		}

		/// <inheritdoc/>
		protected internal override Glyph ToLower(Glyph glyph) {
			foreach (Map map in Graphemes) {
				if (glyph == map.Upper) {
					return map.Lower;
				}
			}
			return glyph.ToLower();
		}

		/// <inheritdoc/>
		protected internal override Char ToTitle(Char @char) => @char.ToTitle();

		/// <inheritdoc/>
		protected internal override Rune ToTitle(Rune rune) => rune.ToTitle();

		/// <inheritdoc/>
		protected internal override Glyph ToTitle(Glyph glyph) => glyph.ToTitle();

		/// <inheritdoc/>
		protected internal override Char ToUpper(Char @char) {
			foreach (Map map in Graphemes) {
				if (@char == map.Lower) {
					return (Char)map.Upper.Code;
				}
			}
			return @char.ToUpper();
		}

		/// <inheritdoc/>
		protected internal override Rune ToUpper(Rune rune) {
			foreach (Map map in Graphemes) {
				if (rune == map.Lower) {
					return new Rune(map.Upper.Code);
				}
			}
			return rune.ToUpper();
		}

		/// <inheritdoc/>
		protected internal override Glyph ToUpper(Glyph glyph) {
			foreach (Map map in Graphemes) {
				if (glyph == map.Lower) {
					return map.Upper;
				}
			}
			return glyph.ToUpper();
		}
	}
}
