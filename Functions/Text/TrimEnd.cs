using Defender;
using System;
using System.Globalization;
using System.Text;
using Stringier.Categories;

namespace Stringier {
	public static partial class Text {
		//NOTE: This function has to do the odd thing of returning String for anything with a String as the receiver, but ReadOnlySpan<Char> otherwise, this is to remain consistent with existing .NET APIs. This is not an error, but a forced decision.

		#region TrimEnd(Text)
		/// <summary>
		/// Removes all the trailing white-space characters from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static String TrimEnd(this String text) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan()).ToString();
		}

		/// <summary>
		/// Removes all the trailing white-space characters from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan());
		}

		/// <summary>
		/// Removes all the trailing white-space characters from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text) => TrimEnd((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Removes all the trailing white-space characters from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text) {
			Int32 end = 0;
			while (WhiteSpace.Contains(text[end])) {
				end++;
			}
			return text.Slice(end);
		}

		/// <summary>
		/// Removes all the trailing white-space characters from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(new ReadOnlySpan<Char>(text, length));
		}
		#endregion

		#region TrimEnd(Text, Char)
		/// <summary>
		/// Removes all the trailing occurrences of a specified character from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChar">The Unicode character to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static String TrimEnd(this String text, Char trimChar) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimChar).ToString();
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified character from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChar">The Unicode character to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text, Char trimChar) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimChar);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified character from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChar">The Unicode character to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text, Char trimChar) => TrimEnd((ReadOnlySpan<Char>)text, trimChar);

		/// <summary>
		/// Removes all the trailing occurrences of a specified character from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChar">The Unicode character to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text, Char trimChar) {
			Int32 end = 0;
			while (text[end] == trimChar) {
				end++;
			}
			return text.Slice(end);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified character from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="trimChar">The Unicode character to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="trimChar"/> character are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length, Char trimChar) => MemoryExtensions.TrimEnd(new ReadOnlySpan<Char>(text, length), trimChar);
		#endregion

		#region TrimEnd(Text, Char[])
		/// <summary>
		/// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static String TrimEnd(this String text, params Char[] trimChars) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimChars).ToString();
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text, params Char[] trimChars) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimChars);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text, params Char[] trimChars) => TrimEnd((ReadOnlySpan<Char>)text, trimChars);

		/// <summary>
		/// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text, params Char[] trimChars) {
			if (trimChars is null || trimChars.Length == 0) {
				return text.TrimEnd();
			}
			Int32 end = 0;
			foreach (Char t in text) {
				if (!trimChars.Contains(t)) {
					goto Done;
				}
				end++;
			}
		Done:
			return text.Slice(end);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
		/// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length, params Char[] trimChars) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(new ReadOnlySpan<Char>(text, length), trimChars);
		}
		#endregion

		#region TrimEnd(Text, Rune)
		/// <summary>
		/// Removes all the trailing occurrences of a specified rune from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRune">The <see cref="Rune"/> to remove.</param>
		/// <returns>
		/// The string that remains after all occurrences of the <paramref name="trimRune"/> rune are removed from the end of the current string. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static String TrimEnd(this String text, Rune trimRune) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimRune).ToString();
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified rune from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRune">The <see cref="Rune"/> to remove.</param>
		/// <returns>
		/// The string that remains after all occurrences of the <paramref name="trimRune"/> rune are removed from the end of the current string. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text, Rune trimRune) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimRune);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified rune from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRune">The <see cref="Rune"/> to remove.</param>
		/// <returns>
		/// The string that remains after all occurrences of the <paramref name="trimRune"/> rune are removed from the end of the current string. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text, Rune trimRune) => TrimEnd((ReadOnlySpan<Char>)text, trimRune);

		/// <summary>
		/// Removes all the trailing occurrences of a specified rune from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRune">The <see cref="Rune"/> to remove.</param>
		/// <returns>
		/// The string that remains after all occurrences of the <paramref name="trimRune"/> rune are removed from the end of the current string. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text, Rune trimRune) {
			Int32 end = 0;
			Rune rune;
			while ((rune = text.GetRuneAt(end)) != trimRune) {
				end += rune.Utf16SequenceLength;
			}
			return text.Slice(0, end);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified rune from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="trimRune">The <see cref="Rune"/> to remove.</param>
		/// <returns>
		/// The string that remains after all occurrences of the <paramref name="trimRune"/> rune are removed from the end of the current string. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length, Rune trimRune) => TrimEnd(new ReadOnlySpan<Char>(text, length), trimRune);
		#endregion

		#region TrimEnd(Text, Rune[])
		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static String TrimEnd(this String text, params Rune[] trimRunes) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimRunes).ToString();
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text, params Rune[] trimRunes) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), trimRunes);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text, params Rune[] trimRunes) => TrimEnd((ReadOnlySpan<Char>)text, trimRunes);

		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text, params Rune[] trimRunes) {
			if (trimRunes is null || trimRunes.Length == 0) {
				return text.TrimEnd();
			}
			Int32 end = 0;
			foreach (Char t in text) {
				if (!trimRunes.Contains(t)) {
					goto Done;
				}
				end++;
			}
		Done:
			return text.Slice(end);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a set of runes specified in an array from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="trimRunes">An array of <see cref="Rune"/> to remove, or <see langword="null"/>.</param>
		/// <returns>
		/// The string that remains after all occurrences of the runes in the <paramref name="trimRunes"/> parameter are removed from the end of the current string. If <paramref name="trimRunes"/> is <see langword="null"/> or an empty array, Unicode white-space runes are removed instead. If no runes can be trimmed from the current instance, the method returns the current instance unchanged.
		/// </returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length, params Rune[] trimRunes) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(new ReadOnlySpan<Char>(text, length), trimRunes);
		}
		#endregion

		#region TrimEnd(Text, Category)
		/// <summary>
		/// Removes all the trailing occurrences of a specified UNICODE category from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The UNICODE category to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="category"/> are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static String TrimEnd(this String text, Category category) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), category).ToString();
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified UNICODE category from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The UNICODE category to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="category"/> are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Char[] text, Category category) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(text.AsSpan(), category);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified UNICODE category from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The UNICODE category to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="category"/> are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this Span<Char> text, Category category) => TrimEnd((ReadOnlySpan<Char>)text, category);

		/// <summary>
		/// Removes all the trailing occurrences of a specified UNICODE category from the current string.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="category">The UNICODE category to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="category"/> are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		public static ReadOnlySpan<Char> TrimEnd(this ReadOnlySpan<Char> text, Category category) {
			Int32 end = 0;
			if (category == Surrogate) {
				while (Surrogate.Contains(text[end])) {
					end++;
				}
			} else { 
				Rune rune;
				while (category.Contains(rune = text.GetRuneAt(end))) {
					end += rune.Utf16SequenceLength;
				}
			}
			return text.Slice(end);
		}

		/// <summary>
		/// Removes all the trailing occurrences of a specified UNICODE category from the current string.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="category">The UNICODE category to remove.</param>
		/// <returns>The string that remains after all occurrences of the <paramref name="category"/> are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> TrimEnd(Char* text, Int32 length, Category category) {
			Guard.NotNull(text, nameof(text));
			return TrimEnd(new ReadOnlySpan<Char>(text, length), category);
		}
		#endregion
	}
}
