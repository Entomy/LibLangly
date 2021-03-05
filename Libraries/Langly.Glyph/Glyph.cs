using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly {
	/// <summary>
	/// Represents a UNICODE Grapheme Cluster.
	/// </summary>
	/// <seealso cref="Char"/>
	/// <seealso cref="Rune"/>
	public readonly partial struct Glyph : IEquals<Char>, IEquals<Rune>, IEquals<Glyph> {
		/// <summary>
		/// The <see cref="Int32"/> code describing invariant equivalence rules.
		/// </summary>
		private readonly Int32 Code;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UTF-16 Code Unit.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Char @char) => Code = @char;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UNICODE Scalar Value.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Rune rune) => Code = unchecked(rune.Value);

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="code"/>.
		/// </summary>
		/// <param name="code">The <see cref="Int32"/> code describing invariant equivalence rules.</param>
		internal Glyph(Int32 code) => Code = code;

		public static implicit operator Glyph(Char @char) => new Glyph(@char);

		public static implicit operator Glyph(Rune rune) => new Glyph(rune);

		public static Boolean operator !=(Glyph left, Glyph right) => !left.Equals(right);

		public static Boolean operator ==(Glyph left, Glyph right) => left.Equals(right);

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to lowercase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The lowercase equivalent of value.</returns>
		public static Glyph ToLowerInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Lowercase);

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to titlecase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The titlecase equivalent of value.</returns>
		public static Glyph ToTitleInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Titlecase);

		/// <summary>
		/// Returns a copy of the specified <see cref="Glyph"/> converted to uppercase.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of value.</returns>
		public static Glyph ToUpperInvariant(Glyph glyph) => new Glyph(Table[glyph.Code].Uppercase);

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] System.Object obj) {
			switch (obj) {
			case Char @char:
				return Equals(@char);
			case Rune rune:
				return Equals(rune);
			case Glyph glyph:
				return Equals(glyph);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Char other) => Code == other;

		/// <inheritdoc/>
		public Boolean Equals(Rune other) => Code == other.Value;

		/// <inheritdoc/>
		public Boolean Equals(Glyph other) => Code == other.Code;

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Code;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Table[Code].Sequence;
	}
}
