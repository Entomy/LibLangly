using Defender;
using Stringier.Categories;
using System;
using System.Globalization;

namespace Stringier {
	public static partial class Text {
		#region IsPalindrome(Text)
		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Boolean IsPalindrome(this String text) {
			Guard.NotNull(text, nameof(text));
			return IsPalindrome(text.AsSpan(), CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Boolean IsPalindrome(this Char[] text) {
			Guard.NotNull(text, nameof(text));
			return IsPalindrome(text.AsSpan(), CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Boolean IsPalindrome(this Span<Char> text) => IsPalindrome((ReadOnlySpan<Char>)text, CultureInfo.CurrentCulture);

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Boolean IsPalindrome(this ReadOnlySpan<Char> text) => IsPalindrome(text, CultureInfo.CurrentCulture);

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[CLSCompliant(false)]
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static unsafe Boolean IsPalindrome(Char* text, Int32 length) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return IsPalindrome(new ReadOnlySpan<Char>(text, length), CultureInfo.CurrentCulture);
		}
		#endregion

		#region IsPalindrome(Text, CultureInfo)
		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this String text, CultureInfo culture) {
			Guard.NotNull(text, nameof(text));
			return IsPalindrome(text.AsSpan(), culture);
		}

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this Char[] text, CultureInfo culture) {
			Guard.NotNull(text, nameof(text));
			return IsPalindrome(text.AsSpan(), culture);
		}

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this Span<Char> text, CultureInfo culture) => IsPalindrome((ReadOnlySpan<Char>)text, culture);

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this ReadOnlySpan<Char> text, CultureInfo culture) {
			ReadOnlySpan<Char> prepped = PalindromeStrip(text);
			String reversed = Glyph.Reverse(prepped);
			SpanGlyphEnumerator prep = prepped.EnumerateGlyphs();
			StringGlyphEnumerator revr = reversed.EnumerateGlyphs();
			// Now actually check it's a palindrome
			while (prep.MoveNext() && revr.MoveNext()) {
				if (prep.Current.ToUpper(culture) != revr.Current.ToUpper(culture)) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Checks if the <paramref name="text"/> is a palindrome, glyph-wise.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns><see langword="true"/> if <paramref name="text"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static unsafe Boolean IsPalindrome(Char* text, Int32 length, CultureInfo culture) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return IsPalindrome(new ReadOnlySpan<Char>(text, length), culture);
		}
		#endregion

		private static ReadOnlySpan<Char> PalindromeStrip(ReadOnlySpan<Char> text) {
			// First we need to build the string without any punctuation or whitespace or any other unrelated-to-reading characters
			Char[] builder = new Char[text.Length];
			Int32 b = 0;
			Span<Char> glyphChars = new Char[4];
			foreach (Glyph s in text.EnumerateGlyphs()) {
				if (new Letter().Contains(s)) {
					Int32 l = s.EncodeToUtf16(glyphChars);
					while (l > 0) {
						builder[b++] = glyphChars[--l];
					}
				}
			}
			return builder.AsSpan().Slice(0, b);
		}
	}
}
