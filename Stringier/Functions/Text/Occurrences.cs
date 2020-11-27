using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class Text {
		#region Occurrences(Text, Char)
		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this Char[] text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Memory<Char> text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlyMemory<Char> text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Span<Char> text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlySpan<Char> text, Char element) => Occurrences(text, new Glyph(element));

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe nint Occurrences([AllowNull] Char* text, Int32 length, Char element) => Occurrences(text, length, new Glyph(element));
		#endregion

		#region Occurrences(Text, Char[])
		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this Char[] text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Memory<Char> text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlyMemory<Char> text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Span<Char> text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlySpan<Char> text, [AllowNull] params Char[] elements) => Occurrences(text, Batch.ToGlyph(elements));

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe nint Occurrences([AllowNull] Char* text, Int32 length, [AllowNull] params Char[] elements) => Occurrences(text, length, Batch.ToGlyph(elements));
		#endregion

		#region Occurrences(Text, Glyph)
		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String text, Glyph element) {
			if (text is not null) {
				return Occurrences(text.AsSpan(), element);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this Char[] text, Glyph element) {
			if (text is not null) {
				return Occurrences(text.AsSpan(), element);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Memory<Char> text, Glyph element) => Occurrences(text.Span, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlyMemory<Char> text, Glyph element) => Occurrences(text.Span, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Span<Char> text, Glyph element) => Occurrences((ReadOnlySpan<Char>)text, element);

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlySpan<Char> text, Glyph element) {
			nint count = 0;
			foreach (Glyph glyph in text.EnumerateGlyphs()) {
				count += glyph == element ? 1 : 0;
			}
			return count;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="element">The grapheme to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe nint Occurrences([AllowNull] Char* text, Int32 length, Glyph element) {
			if (text is not null) {
				return Occurrences(new ReadOnlySpan<Char>(text, length), element);
			} else {
				return 0;
			}
		}
		#endregion

		#region Occurrences(Text, Glyph[])
		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String text, [AllowNull] params Glyph[] elements) {
			if (text is not null && elements is not null) {
				return Occurrences(text.AsSpan(), elements);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this Char[] text, [AllowNull] params Glyph[] elements) {
			if (text is not null && elements is not null) {
				return Occurrences(text.AsSpan(), elements);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Memory<Char> text, [AllowNull] params Glyph[] elements) {
			if (elements is not null) {
				return Occurrences(text.Span, elements);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlyMemory<Char> text, [AllowNull] params Glyph[] elements) {
			if (elements is not null) {
				return Occurrences(text.Span, elements);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Span<Char> text, [AllowNull] params Glyph[] elements) {
			if (elements is not null) {
				return Occurrences((ReadOnlySpan<Char>)text, elements);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlySpan<Char> text, [AllowNull] params Glyph[] elements) {
			if (elements is not null) {
				nint c = 0;
				foreach (Glyph element in elements) {
					c += text.Occurrences(element);
				}
				return c;
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="elements"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="elements">The set of graphemes to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe nint Occurrences([AllowNull] Char* text, Int32 length, [AllowNull] params Glyph[] elements) {
			if (text is not null && elements is not null) {
				return Occurrences(new ReadOnlySpan<Char>(text, length), elements);
			} else {
				return 0;
			}
		}
		#endregion

		#region Occurrences(Text, Category)
		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this String text, [DisallowNull] Category category) {
			if (text is not null && category is not null) {
				return Occurrences(text.AsSpan(), category);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences([AllowNull] this Char[] text, [DisallowNull] Category category) {
			if (text is not null && category is not null) {
				return Occurrences(text.AsSpan(), category);
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Memory<Char> text, [DisallowNull] Category category) => Occurrences(text.Span, category);

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlyMemory<Char> text, [DisallowNull] Category category) => Occurrences(text.Span, category);

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this Span<Char> text, [DisallowNull] Category category) => Occurrences((ReadOnlySpan<Char>)text, category);

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static nint Occurrences(this ReadOnlySpan<Char> text, [DisallowNull] Category category) {
			if (category is not null) {
				nint count = 0;
				foreach (Glyph glyph in text.EnumerateGlyphs()) {
					count += category.Contains(glyph) ? 1 : 0;
				}
				return count;
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe nint Occurrences([AllowNull] Char* text, Int32 length, [DisallowNull] Category category) {
			if (text is not null && category is not null) {
				return Occurrences(new ReadOnlySpan<Char>(text, length), category);
			} else {
				return 0;
			}
		}
		#endregion
	}
}
