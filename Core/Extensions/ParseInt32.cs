using System;
using System.Globalization;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="char">A char containing a number to convert.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="char"/>.</returns>
		public static Int32 ParseInt32(this Char @char) => @char switch
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
		/// <param name="char">A char containing a number to convert.</param>
		/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="char"/>. A typical value to specify is <see cref="NumberStyles.AllowHexSpecifier"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="char"/>.</returns>
		public static Int32 ParseInt32(this Char @char, NumberStyles style) {
			if (style.HasFlag(NumberStyles.AllowHexSpecifier)) {
				return @char switch
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
			}
			else {
				return @char.ParseInt32();
			}
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="string"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="string"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int32 ParseInt32(this String @string, NumberStyles style, IFormatProvider provider) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(provider, nameof(provider));
			return Int32.Parse(@string, style, provider);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="string"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int32 ParseInt32(this String @string, NumberStyles style) {
			Guard.NotNull(@string, nameof(@string));
			return Int32.Parse(@string, style);
		}

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="string"/>.</returns>
		public static Int32 ParseInt32(this String @string) {
			Guard.NotNull(@string, nameof(@string));
			return Int32.Parse(@string);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified culture-specific format to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="string">A string containing a number to convert.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="string"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="string"/>.</returns>
		public static Int32 ParseInt32(this String @string, IFormatProvider provider) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(provider, nameof(provider));
			return Int32.Parse(@string, provider);
		}
	}
}