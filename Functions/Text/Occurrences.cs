using System;
using System.Collections.Generic;
using System.Text;
using Defender;
using Stringier.Categories;

namespace Stringier {
	public static partial class Text {
		#region Occurrences(Text, Char)
		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this String text, Char countChar) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), countChar);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Char[] text, Char countChar) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), countChar);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Span<Char> text, Char countChar) => Occurrences((ReadOnlySpan<Char>)text, countChar);

		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this ReadOnlySpan<Char> text, Char countChar) {
			Int32 c = 0;
			foreach (Char @char in text) {
				c += @char == countChar ? 1 : 0;
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe Int32 Occurrences(Char* text, Int32 length, Char countChar) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(new ReadOnlySpan<Char>(text, length), countChar);
		}
		#endregion

		#region Occurrences(Text, Char[])
		/// <summary>
		/// Count all occurrences of the <paramref name="countChars"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this String text, params Char[] countChars) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countChars, nameof(countChars));
			return Occurrences(text.AsSpan(), countChars);
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countChars"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Char[] text, params Char[] countChars) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countChars, nameof(countChars));
			return Occurrences(text.AsSpan(), countChars);
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countChars"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Span<Char> text, params Char[] countChars) => Occurrences((ReadOnlySpan<Char>)text, countChars);

		/// <summary>
		/// Count all occurrences of the <paramref name="countChars"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this ReadOnlySpan<Char> text, params Char[] countChars) {
			Guard.NotNull(countChars, nameof(countChars));
			Int32 c = 0;
			foreach (Char countChar in countChars) {
				c += text.Occurrences(countChar);
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countChars"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe Int32 Occurrences(Char* text, Int32 length, params Char[] countChars) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countChars, nameof(countChars));
			return Occurrences(new ReadOnlySpan<Char>(text, length), countChars);
		}
		#endregion

		#region Occurrences(Text, Rune)
		/// <summary>
		/// Count all occurrences of <paramref name="countRune"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRune">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this String text, Rune countRune) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), countRune);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countRune"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRune">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Char[] text, Rune countRune) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), countRune);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countRune"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRune">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Span<Char> text, Rune countRune) => Occurrences((ReadOnlySpan<Char>)text, countRune);

		/// <summary>
		/// Count all occurrences of <paramref name="countRune"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRune">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this ReadOnlySpan<Char> text, Rune countRune) {
			Int32 c = 0;
			foreach (Rune rune in text.EnumerateRunes()) {
				c += rune == countRune ? 1 : 0;
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countRune"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="countRune">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe Int32 Occurrences(Char* text, Int32 length, Rune countRune) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(new ReadOnlySpan<Char>(text, length), countRune);
		}
		#endregion

		#region Occurrences(Text, Rune[])
		/// <summary>
		/// Count all occurrences of the <paramref name="countRunes"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRunes">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this String text, params Rune[] countRunes) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countRunes, nameof(countRunes));
			return Occurrences(text.AsSpan(), countRunes);
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countRunes"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRunes">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Char[] text, params Rune[] countRunes) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countRunes, nameof(countRunes));
			return Occurrences(text.AsSpan(), countRunes);
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countRunes"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRunes">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Span<Char> text, params Rune[] countRunes) => Occurrences((ReadOnlySpan<Char>)text, countRunes);

		/// <summary>
		/// Count all occurrences of the <paramref name="countRunes"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="countRunes">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this ReadOnlySpan<Char> text, params Rune[] countRunes) {
			Guard.NotNull(countRunes, nameof(countRunes));
			Int32 c = 0;
			foreach (Rune countRune in countRunes) {
				c += text.Occurrences(countRune);
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of the <paramref name="countRunes"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="countRunes">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe Int32 Occurrences(Char* text, Int32 length, params Rune[] countRunes) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(countRunes, nameof(countRunes));
			return Occurrences(new ReadOnlySpan<Char>(text, length), countRunes);
		}
		#endregion

		#region Occurrences(Text, Category)
		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this String text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), category);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Char[] text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(text.AsSpan(), category);
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this Span<Char> text, Category category) => Occurrences((ReadOnlySpan<Char>)text, category);

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this ReadOnlySpan<Char> text, Category category) {
			Guard.NotNull(category, nameof(category));
			Int32 c = 0;
			if (category == Surrogate) {
				foreach (Char @char in text) {
					c += Surrogate.Contains(@char) ? 1 : 0;
				}
			} else {
				foreach (Rune rune in text.EnumerateRunes()) {
					c += category.Contains(rune) ? 1 : 0;
				}
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="category"/> in the <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The text to scan.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The category to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		[CLSCompliant(false)]
		public static unsafe Int32 Occurrences(Char* text, Int32 length, Category category) {
			Guard.NotNull(text, nameof(text));
			return Occurrences(new ReadOnlySpan<Char>(text, length), category);
		}
		#endregion

		#region Occurrences(Sequence<Char>, Char)
		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this IEnumerable<Char> sequence, Char countChar) {
			Int32 c = 0;
			foreach (Char item in sequence) {
				if (item == countChar) {
					c++;
				}
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countChar"/> in the <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence to scan.</param>
		/// <param name="countChar">The character to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this IEnumerable<IEnumerable<Char>> sequence, Char countChar) {
			Int32 c = 0;
			foreach (IEnumerable<Char> seq in sequence) {
				c += seq.Occurrences(countChar);
			}
			return c;
		}
		#endregion

		#region Occurrences(Sequence<Char>, Char[])
		/// <summary>
		/// Count all occurrences of <paramref name="countChars"/> in the <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this IEnumerable<Char> sequence, params Char[] countChars) {
			Int32 c = 0;
			foreach (Char countChar in countChars) {
				c += sequence.Occurrences(countChar);
			}
			return c;
		}

		/// <summary>
		/// Count all occurrences of <paramref name="countChars"/> in the <paramref name="sequence"/>.
		/// </summary>
		/// <param name="sequence">The sequence to scan.</param>
		/// <param name="countChars">The set of characters to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public static Int32 Occurrences(this IEnumerable<IEnumerable<Char>> sequence, params Char[] countChars) {
			Int32 c = 0;
			foreach (Char countChar in countChars) {
				c += sequence.Occurrences(countChar);
			}
			return c;
		}
		#endregion

		#region Occurrences(Sequence<Char>, Rune)
		#endregion

		#region Occurrences(Sequence<Char>, Rune[])
		#endregion

		#region Occurrences(Sequence<Char>, Category)
		#endregion
	}
}
