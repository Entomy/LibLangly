using System;
using System.Globalization;

namespace System {
	public static class CharExtensions {

		/// <summary>
		/// Categorizes a specified Unicode character into a group identified by one of the <see cref="UnicodeCategory"/> values.
		/// </summary>
		/// <param name="Char">The Unicode character to categorize.</param>
		/// <returns>A <see cref="UnicodeCategory"/> value that identifies the group that contains <paramref name="Char"/>.</returns>
		public static UnicodeCategory GetUnicodeCategory(this Char Char) => Char.GetUnicodeCategory(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a control character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a control character; otherwise, false.</returns>
		public static Boolean IsControl(this Char Char) => Char.IsControl(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a decimal digit.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a decimal digit; otherwise, false.</returns>
		public static Boolean IsDigit(this Char Char) => Char.IsDigit(Char);

		/// <summary>
		/// Indicates whether the specified Char object is a high surrogate.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if the numeric value of the <paramref name="Char"/> parameter ranges from U+D800 through U+DBFF; otherwise, false.</returns>
		public static Boolean IsHighSurrogate(this Char Char) => Char.IsHighSurrogate(Char);

		/// <summary>
		/// Indicates whether a Unicode character is categorized as a Unicode letter.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a letter; otherwise, false.</returns>
		public static Boolean IsLetter(this Char Char) => Char.IsLetter(Char);

		/// <summary>
		/// Indicates whether a Unicode character is categorized as a letter or a decimal digit.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a letter or a decimal digit; otherwise, false.</returns>
		public static Boolean IsLetterOrDigit(this Char Char) => Char.IsLetterOrDigit(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a lowercase letter.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a lowercase letter; otherwise, false.</returns>
		public static Boolean IsLower(this Char Char) => Char.IsLower(Char);

		/// <summary>
		/// Indicates whether the specified Char object is a low surrogate.
		/// </summary>
		/// <param name="Char">The character to evaluate.</param>
		/// <returns>true if the numeric value of the <paramref name="Char"/> parameter ranges from U+DC00 through U+DFFF; otherwise, false.</returns>
		public static Boolean IsLowSurrogate(this Char Char) => Char.IsLowSurrogate(Char);

		/// <summary>
		/// Indicates whether a Unicode character is categorized as a number.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a number; otherwise, false.</returns>
		public static Boolean IsNumber(this Char Char) => Char.IsNumber(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a punctuation mark.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a punctuation mark; otherwise, false.</returns>
		public static Boolean IsPunctuation(this Char Char) => Char.IsPunctuation(Char);

		/// <summary>
		/// Indicates whether a Unicode character is categorized as a separator character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a separator character; otherwise, false.</returns>
		public static Boolean IsSeparator(this Char Char) => Char.IsSeparator(Char);

		/// <summary>
		/// Indicates whether the specified character has a surrogate code unit.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is either a high surrogate or a low surrogate; otherwise, false.</returns>
		public static Boolean IsSurrogate(this Char Char) => Char.IsSurrogate(Char);

		/// <summary>
		/// Indicates whether two specified <see cref="Char"/> objects form a surrogate pair.
		/// </summary>
		/// <param name="Pair">The pair of characters to evaluate as a surrogate pair</param>
		/// <returns>true if the numeric value of the high and low parameters are their respective surrogate parts; otherwise false</returns>
		public static Boolean IsSurrogatePair(this (Char High, Char Low) Pair) => Char.IsSurrogatePair(Pair.High, Pair.Low);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a symbol character.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is a symbol character; otherwise, false.</returns>
		public static Boolean IsSymbol(this Char Char) => Char.IsSymbol(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as an uppercase letter.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is an uppercase letter; otherwise, false.</returns>
		public static Boolean IsUpper(this Char Char) => Char.IsUpper(Char);

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <param name="Char">The Unicode character to evaluate.</param>
		/// <returns>true if <paramref name="Char"/> is white space; otherwise, false.</returns>
		public static Boolean IsWhiteSpace(this Char Char) => Char.IsWhiteSpace(Char);

		/// <summary>
		/// Joins the <paramref name="Chars"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars) => new String(Chars);

		/// <summary>
		/// Joins the <paramref name="Chars"/> with <paramref name="Separator"/> into a string.
		/// </summary>
		/// <param name="Chars">The <see cref="Char[]"/> to join.</param>
		/// <param name="Separator">The <see cref="Char"/> to interleave.</param>
		/// <returns>The joined <see cref="String"/>.</returns>
		public static String Join(this Char[] Chars, Char Separator) {
			Char[] Result = new Char[Chars.Length * 2 - 1];
			for (int i = 0; i < Chars.Length * 2 - 1; i++) {
				if (i % 2 == 0) {
					Result[i] = Chars[i / 2];
				} else {
					Result[i] = Separator;
				}
			}
			return Result.Join();
		}

		/// <summary>
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int16 ParseInt16(this Char Char) => Char switch {
			'0' => (Int16)0,
			'1' => (Int16)1,
			'2' => (Int16)2,
			'3' => (Int16)3,
			'4' => (Int16)4,
			'5' => (Int16)5,
			'6' => (Int16)6,
			'7' => (Int16)7,
			'8' => (Int16)8,
			'9' => (Int16)9,
			_ => throw new FormatException("Char is not of the correct format."),
		};

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int32 ParseInt32(this Char Char) => Char switch {
			'0' => 0,
			'1' => 1,
			'2' => 2,
			'3' => 3,
			'4' => 4,
			'5' => 5,
			'6' => 6,
			'7' => 7,
			'8' => 8,
			'9' => 9,
			_ => throw new FormatException("Char is not of the correct format."),
		};

	}
}
