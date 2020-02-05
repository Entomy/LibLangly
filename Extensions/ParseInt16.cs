using System;
using System.Globalization;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="char">A char containing a number to convert.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="char"/>.</returns>
		public static Int16 ParseInt16(this Char @char) => @char switch
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
		/// <param name="char">A char containing a number to convert.</param>
		/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="char"/>. A typical value to specify is <see cref="NumberStyles.AllowHexSpecifier"/>.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="char"/>.</returns>
		public static Int16 ParseInt16(this Char @char, NumberStyles style) {
			if (style.HasFlag(NumberStyles.AllowHexSpecifier)) {
				return @char switch
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
			}
			else {
				return @char.ParseInt16();
			}
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style and culture-specific format to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="string"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="string"/>.</param>
		/// <returns>A 16-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int16 ParseInt16(this String @string, NumberStyles style, IFormatProvider provider) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(provider, nameof(provider));
			return Int16.Parse(@string, style, provider);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="string"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <returns>A 16-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int16 ParseInt16(this String @string, NumberStyles style) {
			Guard.NotNull(@string, nameof(@string));
			return Int16.Parse(@string, style);
		}

		/// <summary>
		/// Converts the string representation of a number to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <returns>A 16-bit signed integer equivalent to the number contained in <paramref name="string"/>.</returns>
		public static Int16 ParseInt16(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return Int16.Parse(@string);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified culture-specific format to its 16-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="string"/>.</param>
		/// <returns>A 16-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int16 ParseInt16(this String @string, IFormatProvider provider) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(provider, nameof(provider));
			return Int16.Parse(@string, provider);
		}
	}
}
