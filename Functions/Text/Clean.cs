using Defender;
using System;
using System.Text;

namespace Stringier {
	public static partial class Text {
		#region Clean(Text)
		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this String text) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan());
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Char[] text) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan());
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Span<Char> text) => Clean((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this ReadOnlySpan<Char> text) => text.Trim().Squeeze();

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Clean(Char* text, Int32 length) {
			Guard.NotNull(text, nameof(text));
			return Clean(new ReadOnlySpan<Char>(text, length));
		}
		#endregion

		#region Clean(Text, Char)
		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanChar">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanChar"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanChar"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this String text, Char cleanChar) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan(), cleanChar);
		}

		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanChar">The UNICODE character to clean.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Char[] text, Char cleanChar) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan(), cleanChar);
		}

		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanChar">The UNICODE character to clean.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Span<Char> text, Char cleanChar) => Clean((ReadOnlySpan<Char>)text, cleanChar);

		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanChar">The UNICODE character to clean.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this ReadOnlySpan<Char> text, Char cleanChar) => text.Trim(cleanChar).Squeeze(cleanChar);

		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="cleanChar">The UNICODE character to clean.</param>
		/// <returns>The string that remains after all white-space characters are removed from the start and end of the current string, and all consequtive white-space characters are reduced to single spaces. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Clean(Char* text, Int32 length, Char cleanChar) {
			Guard.NotNull(text, nameof(text));
			return Clean(new ReadOnlySpan<Char>(text, length), cleanChar);
		}
		#endregion

		#region Clean(Text, Char[])

		#endregion

		#region Clean(Text, Rune)
		/// <summary>
		/// Trim and replace multiple characters with a single character.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanRune">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanRune"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanRune"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this String text, Rune cleanRune) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan(), cleanRune);
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanRune">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanRune"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanRune"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Char[] text, Rune cleanRune) {
			Guard.NotNull(text, nameof(text));
			return Clean(text.AsSpan(), cleanRune);
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanRune">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanRune"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanRune"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this Span<Char> text, Rune cleanRune) => Clean((ReadOnlySpan<Char>)text, cleanRune);

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">The current string.</param>
		/// <param name="cleanRune">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanRune"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanRune"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		public static ReadOnlySpan<Char> Clean(this ReadOnlySpan<Char> text, Rune cleanRune) => text.Trim(cleanRune).Squeeze(cleanRune);

		/// <summary>
		/// Trim and replace multiple spaces with a single space.
		/// </summary>
		/// <param name="text">Pointer to the characters.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="cleanRune">The UNICODE character to clean.</param>
		/// <returns>The string that remains after <paramref name="cleanRune"/> are removed from the start and end of the current string, and all consequtive <paramref name="cleanRune"/> are reduced to single characters. If no characters can be trimmed and cleaned from the current instance, the method returns the current instance, unchanged.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Clean(Char* text, Int32 length, Rune cleanRune) {
			Guard.NotNull(text, nameof(text));
			return Clean(new ReadOnlySpan<Char>(text, length), cleanRune);
		}
		#endregion

		#region Clean(Text, Rune[])

		#endregion

		#region Clean(Text, Category)

		#endregion
	}
}
