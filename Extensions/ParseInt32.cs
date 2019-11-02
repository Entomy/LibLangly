using System.Globalization;

namespace System {
	public static partial class StringierExtensions {
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
			}
			else {
				return Char.ParseInt32();
			}
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="String">A string containing a number to convert.</param>
		/// <param name="Style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="String"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <param name="Provider">An object that supplies culture-specific information about the format of <paramref name="String"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="String"/>.</returns>
		public static Int32 ParseInt32(this String String, NumberStyles Style, IFormatProvider Provider) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return Int32.Parse(String, Style, Provider);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified style to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="String">A string containing a number to convert.</param>
		/// <param name="Style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="String"/>. A typical value to specify is <see cref="NumberStyles.Integer"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="String"/>.</returns>
		public static Int32 ParseInt32(this String String, NumberStyles Style) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return Int32.Parse(String, Style);
		}

		/// <summary>
		/// Converts the string representation of a number to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="String">A string containing a number to convert.</param>
		/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="String"/>.</returns>
		public static Int32 ParseInt32(this String String) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return Int32.Parse(String);
		}

		/// <summary>
		/// Converts the string representation of a number in a specified culture-specific format to its 32-bit signed integer equivalent.
		/// </summary>
		/// <param name="String">A string containing a number to convert.</param>
		/// <param name="Provider">An object that supplies culture-specific formatting information about <paramref name="String"/>.</param>
		/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="String"/>.</returns>
		public static Int32 ParseInt32(this String String, IFormatProvider Provider) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return Int32.Parse(String, Provider);
		}
	}
}