using System;
using System.Globalization;

namespace System {
	public static class CharExtensions {

		/// <summary>
		/// Categorizes a specified Unicode character into a group identified by one of the <see cref="UnicodeCategory"/> values.
		/// </summary>
		/// <param name="Char">The Unicode character to categorize.</param>
		/// <returns>A <see cref="UnicodeCategory"/> value that identifies the group that contains <paramref name="Char"/>.</returns>
		public static UnicodeCategory GetUnicodeCategory(this Char Char) {
#if NETSTANDARD1_6
			return CharUnicodeInfo.GetUnicodeCategory(Char);
#else
			return Char.GetUnicodeCategory(Char);
#endif
		}

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

#if NETSTANDARD2_0 || NETSTANDARD2_1
		/// <summary>
		/// Indicates whether two specified <see cref="Char"/> objects form a surrogate pair.
		/// </summary>
		/// <param name="Pair">The pair of characters to evaluate as a surrogate pair</param>
		/// <returns>true if the numeric value of the high and low parameters are their respective surrogate parts; otherwise false</returns>
		public static Boolean IsSurrogatePair(this (Char High, Char Low) Pair) => Char.IsSurrogatePair(Pair.High, Pair.Low);
#endif

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
			for (Int32 i = 0; i < Chars.Length * 2 - 1; i++) {
				Result[i] = i % 2 == 0 ? Chars[i / 2] : Separator;
			}
			return Result.Join();
		}

		/// <summary>
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int16 ParseInt16(this Char Char) => Char switch
		{
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
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <param name="Style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="Char"/>. A typical value to specify is <see cref="NumberStyles.AllowHexSpecifier"/>.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int16 ParseInt16(this Char Char, NumberStyles Style) {
			if (Style.HasFlag(NumberStyles.AllowHexSpecifier)) {
				return Char switch
				{
					'0' => (Int16)0x0,
					'1' => (Int16)0x1,
					'2' => (Int16)0x2,
					'3' => (Int16)0x3,
					'4' => (Int16)0x4,
					'5' => (Int16)0x5,
					'6' => (Int16)0x6,
					'7' => (Int16)0x7,
					'8' => (Int16)0x8,
					'9' => (Int16)0x9,
					'a' => (Int16)0xA,
					'A' => (Int16)0xA,
					'b' => (Int16)0xB,
					'B' => (Int16)0xB,
					'c' => (Int16)0xC,
					'C' => (Int16)0xC,
					'd' => (Int16)0xD,
					'D' => (Int16)0xD,
					'e' => (Int16)0xE,
					'E' => (Int16)0xE,
					'f' => (Int16)0xF,
					'F' => (Int16)0xF,
					_ => throw new FormatException("Char is not of the correct format."),
				};
			} else {
				return Char.ParseInt16();
			}
		}

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int32 ParseInt32(this Char Char) => Char switch
		{
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

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <param name="Style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="Char"/>. A typical value to specify is <see cref="NumberStyles.AllowHexSpecifier"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int32 ParseInt32(this Char Char, NumberStyles Style) {
			if (Style.HasFlag(NumberStyles.AllowHexSpecifier)) {
				return Char switch
				{
					'0' => 0x0,
					'1' => 0x1,
					'2' => 0x2,
					'3' => 0x3,
					'4' => 0x4,
					'5' => 0x5,
					'6' => 0x6,
					'7' => 0x7,
					'8' => 0x8,
					'9' => 0x9,
					'a' => 0xA,
					'A' => 0xA,
					'b' => 0xB,
					'B' => 0xB,
					'c' => 0xC,
					'C' => 0xC,
					'd' => 0xD,
					'D' => 0xD,
					'e' => 0xE,
					'E' => 0xE,
					'f' => 0xF,
					'F' => 0xF,
					_ => throw new FormatException("Char is not of the correct format."),
				};
			} else {
				return Char.ParseInt32();
			}
		}

		/// <summary>
		/// Converts the string representation of a number to its 64-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <returns>A 64-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int64 ParseInt64(this Char Char) => Char switch
		{
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

		/// <summary>
		/// Converts the string representation of a number to its 64-bit signed integer equivalent.
		/// </summary>
		/// <param name="Char">A char containing a number to convert.</param>
		/// <param name="Style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="Char"/>. A typical value to specify is <see cref="NumberStyles.AllowHexSpecifier"/>.</param>
		/// <returns>A 64-bit signed integer equivalent to the number contained in <paramref name="Char"/>.</returns>
		public static Int64 ParseInt64(this Char Char, NumberStyles Style) {
			if (Style.HasFlag(NumberStyles.AllowHexSpecifier)) {
				return Char switch
				{
					'0' => 0x0,
					'1' => 0x1,
					'2' => 0x2,
					'3' => 0x3,
					'4' => 0x4,
					'5' => 0x5,
					'6' => 0x6,
					'7' => 0x7,
					'8' => 0x8,
					'9' => 0x9,
					'a' => 0xA,
					'A' => 0xA,
					'b' => 0xB,
					'B' => 0xB,
					'c' => 0xC,
					'C' => 0xC,
					'd' => 0xD,
					'D' => 0xD,
					'e' => 0xE,
					'E' => 0xE,
					'f' => 0xF,
					'F' => 0xF,
					_ => throw new FormatException("Char is not of the correct format."),
				};
			} else {
				return Char.ParseInt64();
			}
		}

		/// <summary>
		/// Repeat the <paramref name="Char"/> <paramref name="Count"/> times.
		/// </summary>
		/// <param name="Char">The <see cref="Char"/> to repeat.</param>
		/// <param name="Count">The amount of times to repeat the <paramref name="Char"/>.</param>
		/// <returns>A <see cref="String"/> containing the repeated <paramref name="Char"/>.</returns>
		public static String Repeat(this Char Char, Int32 Count) {
			if (Count <= 0) { throw new ArgumentOutOfRangeException(nameof(Count), "Count must be a positive integer"); }
			return new String(Char, Count);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="Char"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Char ToLower(this Char Char) => Char.ToLower(Char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <param name="Culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="Char"/>, modified according to <paramref name="Culture"/>, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLower(this Char Char, CultureInfo Culture) {
#if NETSTANDARD1_6
			//This was taken from CoreFX, and is the property of the .NET Foundation and contributors
			if (Culture is null) { throw new ArgumentNullException(nameof(Culture)); }
			return Culture.TextInfo.ToLower(Char);
#else
			return Char.ToLower(Char, Culture);
#endif
		}

		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of the <paramref name="Char"/> parameter, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLowerInvariant(this Char Char) => Char.ToLowerInvariant(Char);

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="Char"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char Char) => Char.ToUpper(Char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <param name="Culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="Char"/>, modified according to <paramref name="Culture"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char Char, CultureInfo Culture) {
#if NETSTANDARD1_6
			//This was taken from CoreFX, and is the property of the .NET Foundation and contributors
			if (Culture is null) { throw new ArgumentNullException(nameof(Culture)); }
			return Culture.TextInfo.ToLower(Char);
#else
			return Char.ToUpper(Char, Culture);
#endif
		}

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="Char"/> parameter, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already uppercase or not alphabetic.</returns>
		public static Char ToUpperInvariant(this Char Char) => Char.ToUpperInvariant(Char);
	}
}
