using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
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
		public static SplitString Split(this String text) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan());
		}

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Char[] text) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan());
		}

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
		public static SplitString Split(this ReadOnlySpan<Char> text) => Split(text, WhiteSpace);

		/// <summary>
		/// Splits a string into substrings based on whitespace separators.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split(Char* text, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Split(new ReadOnlySpan<Char>(text, length));
		}
		#endregion

		#region Split(Text, Char)
		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A character that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this String text, Char separator) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A character that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Char[] text, Char separator) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A character that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, Char separator) => Split((ReadOnlySpan<Char>)text, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A character that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, Char separator) {
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
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A character that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split(Char* text, Int32 length, Char separator) {
			Guard.NotNull(text, nameof(text));
			return Split(new ReadOnlySpan<Char>(text, length), separator);
		}
		#endregion

		#region Split(Text, Char[])
		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The characters that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this String text, params Char[] separators) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separators);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The characters that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Char[] text, params Char[] separators) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separators);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The characters that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, params Char[] separators) => Split((ReadOnlySpan<Char>)text, separators);

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separators">The characters that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, params Char[] separators) {
			(Int32 start, Int32 length)[] regions = new (Int32 start, Int32 length)[text.Occurrences(separators)];
			Int32 r = 0;
			Int32 start = 0;
			for (Int32 t = 0; t < text.Length; t++) {
				foreach (Char separator in separators) {
					if (text[t] == separator) {
						regions[r++] = (start, t - start);
						start = t + 1;
					}
				}
			}
			return new SplitString(text, regions);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided character separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separators">The characters that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split(Char* text, Int32 length, params Char[] separators) {
			Guard.NotNull(text, nameof(text));
			return Split(new ReadOnlySpan<Char>(text, length), separators);
		}
		#endregion

		#region Split(Text, Rune)
		#endregion

		#region Split(Text, Rune[])
		#endregion

		#region Split(Text, Category)
		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this String text, Category separator) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Char[] text, Category separator) {
			Guard.NotNull(text, nameof(text));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, Category separator) => Split((ReadOnlySpan<Char>)text, separator);

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, Category separator) {
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
		}

		/// <summary>
		/// Splits a string into substrings based on the provided categories.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A UNICODE category that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split(Char* text, Int32 length, Category separator) {
			Guard.NotNull(text, nameof(text));
			return Split(new ReadOnlySpan<Char>(text, length), separator);
		}
		#endregion

		#region Split(Text, String)
		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this String text, String separator) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(separator, nameof(separator));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Char[] text, String separator) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(separator, nameof(separator));
			return Split(text.AsSpan(), separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this Span<Char> text, String separator) {
			Guard.NotNull(separator, nameof(separator));
			return Split((ReadOnlySpan<Char>)text, separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		public static SplitString Split(this ReadOnlySpan<Char> text, String separator) {
			Guard.NotNull(separator, nameof(separator));
			List<(Int32 start, Int32 length)> regions = new List<(Int32 start, Int32 length)>();
			HorspoolTable table = new HorspoolTable(separator);
			Int32 start = -1;
			while ((start = Search.Horspool(text, table, start + 1)) >= 0) {
				regions.Add((start, text.Length));
			}
			return new SplitString(text, regions);
		}

		/// <summary>
		/// Splits a string into substrings based on the provided string separator.
		/// </summary>
		/// <param name="text">This text.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="separator">A string that delimits the substrings in this string.</param>
		/// <returns>A <see cref="SplitString"/> representing the chunks.</returns>
		[CLSCompliant(false)]
		public static unsafe SplitString Split(Char* text, Int32 length, String separator) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(separator, nameof(separator));
			return Split(new ReadOnlySpan<Char>(text, length), separator);
		}
		#endregion

		#region Split(Text, String[])
		#endregion
	}
}
