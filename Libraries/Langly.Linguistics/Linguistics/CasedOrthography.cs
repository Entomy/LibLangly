using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents an <see cref="Orthography"/> with casing.
	/// </summary>
	internal sealed class CasedOrthography : Orthography {
		/// <summary>
		/// The set up lower-upper case mappings.
		/// </summary>
		private readonly (Glyph Lower, Glyph Upper)[] Maps;

		/// <summary>
		/// Initializes a <see cref="CasedOrthography"/>.
		/// </summary>
		/// <param name="numbers">The set of numbers in this orthography.</param>
		/// <param name="characters">The set of characters in this orthography.</param>
		/// <param name="maps">The set up lower-upper case mappings.</param>
		internal CasedOrthography([DisallowNull] Predicate<Glyph> numbers, [DisallowNull] Predicate<Glyph> characters, params (Glyph Lower, Glyph Upper)[] maps) : base(numbers, characters) => Maps = maps;

		/// <inheritdoc/>
		public override Glyph ToLower(Char @char) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (@char == upper) {
					return lower;
				}
			}
			return Glyph.ToLowerInvariant(@char);
		}

		/// <inheritdoc/>
		public override Glyph ToLower(Rune rune) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (rune == upper) {
					return lower;
				}
			}
			return Glyph.ToLowerInvariant(rune);
		}

		/// <inheritdoc/>
		public override Glyph ToLower(Glyph glyph) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (glyph == upper) {
					return lower;
				}
			}
			return Glyph.ToLowerInvariant(glyph);
		}

		/// <inheritdoc/>
		public override Glyph ToTitle(Char @char) => Glyph.ToTitleInvariant(@char);

		/// <inheritdoc/>
		public override Glyph ToTitle(Rune rune) => Glyph.ToTitleInvariant(rune);

		/// <inheritdoc/>
		public override Glyph ToTitle(Glyph glyph) => Glyph.ToTitleInvariant(glyph);

		/// <inheritdoc/>
		public override Glyph ToUpper(Char @char) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (@char == lower) {
					return upper;
				}
			}
			return Glyph.ToUpperInvariant(@char);
		}

		/// <inheritdoc/>
		public override Glyph ToUpper(Rune rune) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (rune == lower) {
					return upper;
				}
			}
			return Glyph.ToUpperInvariant(rune);
		}

		/// <inheritdoc/>
		public override Glyph ToUpper(Glyph glyph) {
			foreach ((Glyph lower, Glyph upper) in Maps) {
				if (glyph == lower) {
					return upper;
				}
			}
			return Glyph.ToUpperInvariant(glyph);
		}
	}
}
