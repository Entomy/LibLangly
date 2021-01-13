using System;
using System.Text;

namespace Langly {
	/// <summary>
	/// Represents a UNICODE Grapheme Cluster.
	/// </summary>
	/// <seealso cref="Char"/>
	/// <seealso cref="Rune"/>
	public readonly struct Glyph {
		/// <summary>
		/// The <see cref="UInt32"/> code describing invariant equivalence rules.
		/// </summary>
		private readonly UInt32 Code;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UTF-16 Code Unit.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Char @char) => Code = @char;

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given UNICODE Scalar Value.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> representing this <see cref="Glyph"/> as it was declared.</param>
		public Glyph(Rune rune) => Code = unchecked((UInt32)rune.Value);

		/// <summary>
		/// Initializes a new <see cref="Glyph"/> from the given <paramref name="code"/>.
		/// </summary>
		/// <param name="code">The <see cref="UInt32"/> code describing invariant equivalence rules.</param>
		internal Glyph(UInt32 code) => Code = code;
	}
}
