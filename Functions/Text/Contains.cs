using Defender;
using Stringier.Encodings;
using System;
using System.Collections.Generic;
using System.Text;
using Stringier.Categories;

namespace Stringier {
	public static partial class Text {
		//NOTE: This function has additional overloads for types like Rune[], Span<Rune>, ReadOnlySpan<Rune>, and Rune*. These are not normal, and are provided because they have uses inside of this library. Typically function do not need to provide for this type.

		#region Contains(Text, Char)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String text, Char value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Char[] text, Char value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Rune[] text, Char value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Char> text, Char value) => Contains((ReadOnlySpan<Char>)text, value);

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Rune> text, Char value) => Contains((ReadOnlySpan<Rune>)text, value);

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Char> text, Char value) {
			foreach (Char @char in text) {
				if (@char == value) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Rune> text, Char value) {
			if (Utf16.IsSurrogate(value)) {
				foreach (Rune rune in text) {
					foreach (Char @char in Utf16.Encode(rune)!) {
						if (@char == value) {
							return true;
						}
					}
				}
			} else {
				foreach (Rune rune in text) {
					if (rune == new Rune(value)) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, Char value) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Char>(text, length), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Rune* text, Int32 length, Char value) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Rune>(text, length), value);
		}
		#endregion

		#region Contains(Text, Rune)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String text, Rune value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Char[] text, Rune value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Rune[] text, Rune value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Char> text, Rune value) => Contains((ReadOnlySpan<Char>)text, value);

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Rune> text, Rune value) => Contains((ReadOnlySpan<Rune>)text, value);

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Char> text, Rune value) {
			Rune rune;
			for (Int32 i = 0; i < text.Length; i += rune.Utf16SequenceLength) {
				rune = text.GetRuneAt(i);
				if (rune == value) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Rune> text, Rune value) {
			foreach (Rune rune in text) {
				if (rune == value) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, Rune value) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Char>(text, length), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Rune* text, Int32 length, Rune value) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Rune>(text, length), value);
		}
		#endregion

		#region Contains(Text, Category)
		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), category);
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Char[] text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), category);
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Rune[] text, Category category) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), category);
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Char> text, Category category) => Contains((ReadOnlySpan<Char>)text, category);

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Rune> text, Category category) => Contains((ReadOnlySpan<Rune>)text, category);

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Char> text, Category category) {
			if (category == Surrogate) { // Searching for a surrogate can be optimized through this path
				foreach (Char @char in text) {
					if (Utf16.IsSurrogate(@char)) {
						return true;
					}
				}
			} else { // This path has to be used for all other category. The reason being, if we try to get the category of a surrogate, we get that the category is a surrogate, not the category of the Rune it is a part of. Therefore, we have to enumerate the runes of the text instead.
				Rune rune;
				for (Int32 i = 0; i < text.Length; i += rune.Utf16SequenceLength) {
					rune = text.GetRuneAt(i);
					if (category.Contains(rune)) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Rune> text, Category category) {
			if (category == Surrogate) { // Since we're working with composed runes, there can't be a surrogate directly, and we need to instead calculate this differently.
				foreach (Rune rune in text) {
					if (rune.Utf16SequenceLength == 2) {
						// If the sequence length is 2, that means there's two characters to encode the rune, and by definition those are surrogate halves.
						return true;
					}
				}
			} else { 
				foreach (Rune rune in text) {
					if (category.Contains(rune)) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, Category category) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Char>(text, length), category);
		}

		/// <summary>
		/// Returns a value indicating whether a specified UNICODE category occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The category to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="category"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Rune* text, Int32 length, Category category) {
			Guard.NotNull(text, nameof(text));
			return Contains(new ReadOnlySpan<Rune>(text, length), category);
		}
		#endregion

		#region Contains(Text, String)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String text, String value) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(value, nameof(value));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Char[] text, String value) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(value, nameof(value));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Char> text, String value) {
			Guard.NotNull(value, nameof(value));
			return Contains((ReadOnlySpan<Char>)text, value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Char> text, String value) {
			Guard.NotNull(value, nameof(value));
			return Contains(text, value.AsSpan());
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, String value) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(value, nameof(value));
			return Contains(new ReadOnlySpan<Char>(text, length), value);
		}
		#endregion

		#region Contains(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String text, ReadOnlySpan<Char> value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Char[] text, ReadOnlySpan<Char> value) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), value);
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this Span<Char> text, ReadOnlySpan<Char> value) => Contains((ReadOnlySpan<Char>)text, value);

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this ReadOnlySpan<Char> text, ReadOnlySpan<Char> value) => Search.RabinKarp(text, value) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, ReadOnlySpan<Char> value) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return Contains(new ReadOnlySpan<Char>(text, length), value);
		}
		#endregion

		#region Contains(Text, Char*)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this String text, Char* value, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), new ReadOnlySpan<Char>(value, length));
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this Char[] text, Char* value, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Contains(text.AsSpan(), new ReadOnlySpan<Char>(value, length));
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this Span<Char> text, Char* value, Int32 length) => Contains((ReadOnlySpan<Char>)text, new ReadOnlySpan<Char>(value, length));

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this ReadOnlySpan<Char> text, Char* value, Int32 length) {
			Guard.Pointer(value, nameof(value), length, nameof(length));
			return Contains(text, new ReadOnlySpan<Char>(value, length));
		}

		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="valueLength">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(Char* text, Int32 length, Char* value, Int32 valueLength) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.Pointer(text, nameof(value), valueLength, nameof(valueLength));
			return Contains(new ReadOnlySpan<Char>(text, length), new ReadOnlySpan<Char>(value, valueLength));
		}
		#endregion

		#region Contains(Sequence<Char>, Char)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<Char> sequence, Char value) {
			Guard.NotNull(sequence, nameof(sequence));
			foreach (Char @char in sequence) {
				if (@char == value) {
					return true;
				}
			}
			return false;
		}
		#endregion

		#region Contains(Sequence<Text>, Char)
		/// <summary>
		/// Returns a value indicating whether a specified character occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The character to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<IEnumerable<Char>> sequence, Char value) {
			Guard.NotNull(sequence, nameof(sequence));
			foreach (IEnumerable<Char> seq in sequence) {
				if (seq.Contains(value)) {
					return true;
				}
			}
			return false;
		}
		#endregion

		#region Contains(Sequence<Text>, Rune)
		#endregion

		#region Contains(Sequence<Text>, Category)
		#endregion

		#region Contains(Sequence<Text>, String)
		/// <summary>
		/// Returns a value indicating whether a specified text occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> sequence, String value) => Contains(sequence, value, Case.Sensitive);
		#endregion

		#region Contains(Sequence<Text>, String, Case)
		/// <summary>
		/// Returns a value indicating whether a specified twxt occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> sequence, String value, Case casing) {
			Guard.NotNull(sequence, nameof(sequence));
			Guard.NotNull(value, nameof(value));
			return Contains(sequence, value.AsSpan(), casing);
		}
		#endregion

		#region Contains(Sequence<Text>, ReadOnlySpan<Char>)
		/// <summary>
		/// Returns a value indicating whether a specified text occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> sequence, ReadOnlySpan<Char> value) => Contains(sequence, value, Case.Sensitive);
		#endregion

		#region Contains(Sequence<Text>, ReadOnlySpan<Char>, Case)
		/// <summary>
		/// Returns a value indicating whether a specified text occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> sequence, ReadOnlySpan<Char> value, Case casing) {
			Guard.NotNull(sequence, nameof(sequence));
			foreach (String @string in sequence) {
				if (Equals(@string, value, casing)) {
					return true;
				}
			}
			return false;
		}
		#endregion

		#region Contains(Sequence<Text>, Char*)
		/// <summary>
		/// Returns a value indicating whether a specified text occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this IEnumerable<String> sequence, Char* value, Int32 length) => Contains(sequence, new ReadOnlySpan<Char>(value, length), Case.Sensitive);
		#endregion

		#region Contains(Sequence<Text>, Char*, Case)
		/// <summary>
		/// Returns a value indicating whether a specified text occurs within this sequence.
		/// </summary>
		/// <param name="sequence">The text sequence.</param>
		/// <param name="value">The string to seek.</param>
		/// <param name="length">The length of the <paramref name="value"/>.</param>
		/// <param name="casing">The casing of the comparison.</param>
		/// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this sequence; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean Contains(this IEnumerable<String> sequence, Char* value, Int32 length, Case casing) {
			Guard.Pointer(value, nameof(value), length, nameof(length));
			return Contains(sequence, new ReadOnlySpan<Char>(value, length), casing);
		}
		#endregion
	}
}
