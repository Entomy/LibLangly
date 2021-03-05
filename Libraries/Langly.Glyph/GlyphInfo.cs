using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Contains various information about a <see cref="Glyph"/>.
	/// </summary>
	internal readonly struct GlyphInfo {
		/// <summary>
		/// The lowercase code of the associated <see cref="Glyph"/>.
		/// </summary>
		public readonly Int32 Lowercase;

		/// <summary>
		/// The normal sequence of this <see cref="Glyph"/>.
		/// </summary>
		public readonly String Sequence;

		/// <summary>
		/// The titlecase code of the associated <see cref="Glyph"/>.
		/// </summary>
		public readonly Int32 Titlecase;

		/// <summary>
		/// The uppercase code of the associated <see cref="Glyph"/>.
		/// </summary>
		public readonly Int32 Uppercase;

		/// <summary>
		/// The length of this <see cref="Glyph"/> encoded in UTF-16.
		/// </summary>
		public readonly Int32 UTF16SequenceLength;

		/// <summary>
		/// The length of this <see cref="Glyph"/> encoded in UTF-8.
		/// </summary>
		public readonly Int32 UTF8SequenceLength;

		/// <summary>
		/// Initializes a new <see cref="GlyphInfo"/>.
		/// </summary>
		/// <param name="sequence">The normal sequence of this <see cref="Glyph"/>.</param>
		/// <param name="lower">The lowercase code of the associated <see cref="Glyph"/>.</param>
		/// <param name="title">The titlecase code of the associated <see cref="Glyph"/>.</param>
		/// <param name="upper">The uppercase code of the associated <see cref="Glyph"/>.</param>
		/// <param name="utf8Length">The length of this <see cref="Glyph"/> encoded in UTF-8.</param>
		/// <param name="utf16Length">The length of this <see cref="Glyph"/> encoded in UTF-16.</param>
		public GlyphInfo([DisallowNull] String sequence, Int32 lower, Int32 title, Int32 upper, Int32 utf8Length, Int32 utf16Length) {
			Sequence = sequence;
			Lowercase = lower;
			Titlecase = title;
			Uppercase = upper;
			UTF8SequenceLength = utf8Length;
			UTF16SequenceLength = utf16Length;
		}
	}
}
