using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return @string.AsSpan().Clean();
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="span"><see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this ReadOnlySpan<Char> span) { 
			StringBuilder Result = new StringBuilder();
			Boolean AtSpace = false;
			foreach (Char C in span) {
				if (Char.GetUnicodeCategory(C) == UnicodeCategory.SpaceSeparator) {
					if (!AtSpace) {
						AtSpace = true;
						_ = Result.Append(' ');
					}
				} else {
					AtSpace = false;
					_ = Result.Append(C);
				}
			}
			return Result.ToString().Trim();
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="char"/> with a single <paramref name="char"/>
		/// </summary>
		/// <param name="string">String to clean</param>
		/// <param name="char">The character to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String @string, Char @char) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return @string.AsSpan().Clean(@char);
		}

		/// <summary>
		/// Trim and replace multiple <paramref name="char"/> with a single <paramref name="char"/>
		/// </summary>
		/// <param name="span"><see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to clean</param>
		/// <param name="char">The character to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this ReadOnlySpan<Char> span, Char @char) {
			StringBuilder Result = new StringBuilder();
			Boolean AtChar = false;
			foreach (Char C in span) {
				if (C == @char) {
					if (!AtChar) {
						AtChar = true;
						_ = Result.Append(@char);
					}
				} else {
					AtChar = false;
					_ = Result.Append(C);
				}
			}
			return Result.ToString().Trim();
		}
	}
}
