using System;
using System.Text;
using System.Globalization;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return @string.AsSpan().Clean();
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="span"><see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this ReadOnlySpan<Char> span) {
			Char[] result = new Char[span.Length];
			Int32 r = 0;
			Boolean AtSpace = false;
			foreach (Char C in span) {
				if (C.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator) {
					if (!AtSpace) {
						AtSpace = true;
						result[r++] = ' ';
					}
				} else {
					AtSpace = false;
					result[r++] = C;
				}
			}
			return new String(result, 0, r).Trim();
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="char"/> with a single <paramref name="char"/>
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <param name="char">The character to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string, Char @char) {
			Guard.NotNull(@string, nameof(@string));
			return @string.AsSpan().Clean(@char);
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="rune"/> with a single <paramref name="rune"/>
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <param name="rune">The rune to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string, Rune rune) {
			Guard.NotNull(@string, nameof(@string));
			return @string.AsSpan().Clean(rune);
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="char"/> with a single <paramref name="char"/>
		/// </summary>
		/// <param name="span"><see cref="Span{T}"/> of <see cref="Char"/> to clean</param>
		/// <param name="char">The character to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this Span<Char> span, Char @char) => ((ReadOnlySpan<Char>)span).Clean(@char);

		/// <summary>
		/// Trim and replace multiple <paramref name="char"/> with a single <paramref name="char"/>
		/// </summary>
		/// <param name="span"><see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to clean</param>
		/// <param name="char">The character to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this ReadOnlySpan<Char> span, Char @char) {
			Char[] result = new Char[span.Length];
			Int32 r = 0;
			Boolean AtChar = false;
			foreach (Char C in span) {
				if (C == @char) {
					if (!AtChar) {
						AtChar = true;
						result[r++] = @char;
					}
				} else {
					AtChar = false;
					result[r++] = C;
				}
			}
			return new String(result, 0, r);
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="rune"/> with a single <paramref name="rune"/>
		/// </summary>
		/// <param name="span"><see cref="Span{T}"/> of <see cref="Char"/> to clean</param>
		/// <param name="rune">The rune to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this Span<Char> span, Rune rune) => ((ReadOnlySpan<Char>)span).Clean(rune);

		/// <summary>
		/// Trim and replace multiple <paramref name="rune"/> with a single <paramref name="rune"/>
		/// </summary>
		/// <param name="span"><see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to clean</param>
		/// <param name="rune">The rune to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this ReadOnlySpan<Char> span, Rune rune) {
			Span<Rune> result = new Rune[span.Length]; //An array of runes can be shorter than the string it came from, but never longer, so this is safe
			Int32 r = 0;
			Boolean AtRune = false;
			foreach (Rune R in span.EnumerateRunes()) {
				if (R == rune) {
					if (!AtRune) {
						AtRune = true;
						result[r++] = rune;
					}
				} else {
					AtRune = false;
					result[r++] = R;
				}
			}
			return result.Slice(0, r).AsString();
		}
	}
}
