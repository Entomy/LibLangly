using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Tables;
using Langly;
using Defender;
using Stringier.Categories;

namespace Stringier {
	public static partial class Text {
		#region Split(Text)
		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text) {
			if (text is not null) {
				return Split(text.AsSpan());
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text) {
			if (text is not null) {
				return Split(text.AsSpan());
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Memory<Char> text) => Split(text.Span);

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlyMemory<Char> text) => Split(text.Span);

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text) => Split((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text) => Split(text, Category.WhiteSpace);

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Glyph* text, Int32 length) {
			if (text is not null) {
				return Split(new ReadOnlySpan<Char>(text, length));
			} else {
				return new SplitString();
			}
		}
		#endregion

		#region Split(Text, Char)
		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, Char separator) => Split(text, new Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, Char separator) => Split(text, new Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Memory<Char> text, Char separator) => Split(text, new  Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this ReadOnlyMemory<Char> text, Char separator) => Split(text, new Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, Char separator) => Split(text, new Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, Char separator) => Split(text, new Glyph(separator));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Char* text, Int32 length, Char separator) => Split(text, length, new Glyph(separator));
		#endregion

		#region Split(Text, Char[])
		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, [DisallowNull] params Char[] separators) => Split(text, Batch.ToGlyph(separators));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, [DisallowNull] params Char[] separators) => Split(text, Batch.ToGlyph(separators));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, [DisallowNull] params Char[] separators) => Split(text, Batch.ToGlyph(separators));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, [DisallowNull] params Char[] separators) => Split(text, Batch.ToGlyph(separators));

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Char* text, Int32 length, [DisallowNull] params Char[] separators) => Split(text, length, Batch.ToGlyph(separators));
		#endregion

		#region Split(Text, Glyph)
		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, Glyph separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, Glyph separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Memory<Char> text, Glyph separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this ReadOnlyMemory<Char> text, Glyph separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, Glyph separator) => Split((ReadOnlySpan<Char>)text, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, Glyph separator) {
			(Int32 start, Int32 length)[] regions = new (Int32 start, Int32 length)[text.Occurrences(separator)];
			Int32 r = 0;
			Int32 start = 0;
			for (Int32 t = 0; t < text.Length; t++) {
				if (text[t] == separator) {
					regions[r++] = (start, t - start);
					start = t + 1;
				}
			}
			return new SplitString(text, regions);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A grapheme that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Char* text, Int32 length, Glyph separator) {
			if (text is not null) {
				return Split(new ReadOnlySpan<Char>(text, length), separator);
			} else {
				return new SplitString();
			}
		}
		#endregion

		#region Split(Text, Glyph[])
		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, [DisallowNull] params Glyph[] separators) {
			if (text is not null) {
				return Split(text.AsSpan(), separators);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, [DisallowNull] params Glyph[] separators) {
			if (text is not null) {
				return Split(text.AsSpan(), separators);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, [DisallowNull] params Glyph[] separators) => Split((ReadOnlySpan<Char>)text, separators);

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, [DisallowNull] params Glyph[] separators) {
			if (separators is not null) {
				(Int32 start, Int32 length)[] regions = new (Int32 start, Int32 length)[text.Occurrences(separators)];
				Int32 r = 0;
				Int32 start = 0;
				for (Int32 t = 0; t < text.Length; t++) {
					foreach (Glyph separator in separators) {
						if (text[t] == separator) {
							regions[r++] = (start, t - start);
							start = t + 1;
						}
					}
				}
				return new SplitString(text, regions);
			} else {
				// The signature disallows null, but we can safely handle this still. Returns a SplitString with 1 region of the entire original string.
				return new SplitString(text, new[] { (0, text.Length) });
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided grapheme separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separators">The graphemes that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Char* text, Int32 length, [DisallowNull] params Glyph[] separators) {
			if (text is not null) {
				return Split(new ReadOnlySpan<Char>(text, length), separators);
			} else {
				return new SplitString();
			}
		}
		#endregion

		#region Split(Text, Category)
		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, [DisallowNull] Category separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, [DisallowNull] Category separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Memory<Char> text, [DisallowNull] Category separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlyMemory<Char> text, [DisallowNull] Category separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, [DisallowNull] Category separator) => Split((ReadOnlySpan<Char>)text, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, [DisallowNull] Category separator) {
			if (separator is not null) {
				(Int32 start, Int32 length)[] regions = new (Int32 start, Int32 length)[text.Occurrences(separator)];
				Int32 r = 0;
				Int32 start = 0;
				for (Int32 t = 0; t < text.Length; t++) {
					if (separator.Contains(text[t])) {
						regions[r++] = (start, t - start);
						start = t + 1;
					}
				}
				return new SplitString(text, regions);
			} else {
				// The signature disallows null, but we can safely handle this still. Returns a SplitString with 1 region of the entire original string.
				return new SplitString(text, new[] { (0, text.Length) });
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Glyph* text, Int32 length, [DisallowNull] Category separator) {
			if (text is not null) {
				return Split(new ReadOnlySpan<Char>(text, length), separator);
			} else {
				return new SplitString();
			}
		}
		#endregion

		#region Split(Text, String)
		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this String text, [DisallowNull] String separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split([AllowNull] this Char[] text, [DisallowNull] String separator) {
			if (text is not null) {
				return Split(text.AsSpan(), separator);
			} else {
				return new SplitString();
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Memory<Char> text, [DisallowNull] String separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlyMemory<Char> text, [DisallowNull] String separator) => Split(text.Span, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, [DisallowNull] String separator) => Split((ReadOnlySpan<Char>)text, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, [DisallowNull] String separator) {
			if (separator is not null) {
				List<(Int32 start, Int32 length)> regions = new List<(Int32 start, Int32 length)>();
				HorspoolTable table = new HorspoolTable(separator);
				Int32 start = -1;
				while ((start = Search.Horspool(text, table, start + 1)) >= 0) {
					regions.Add((start, text.Length));
				}
				return new SplitString(text, regions);
			} else {
				// The signature disallows null, but we can safely handle this still. Returns a SplitString with 1 region of the entire original string.
				return new SplitString(text, new[] { (0, text.Length) });
			}
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split([AllowNull] Glyph* text, Int32 length, [DisallowNull] String separator) {
			if (text is not null) {
				return Split(new ReadOnlySpan<Char>(text, length), separator);
			} else {
				return new SplitString();
			}
		}
		#endregion

		#region Split(Text, String[])
		#endregion
	}
}
