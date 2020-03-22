using System;
using System.Text;

namespace Stringier.Encodings {
	/// <summary>
	/// Helper functions for working with UTF-16 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-16 stream, not a buffer. This is important, because it enables us to more easily support stream decoding. Buffered data doesn't need special considerations, so this still work with buffers.
	/// </remarks>
	[CLSCompliant(false)]
	public static class Utf16 {
		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> code unit.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(UInt16 unit) => unit < 0xDC00 ? new Rune(unit) : Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="unit">The <see cref="Char"/> code unit.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Char unit) => unit < 0xDC00 ? new Rune(unit) : Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="highSurrogate">The <see cref="UInt16"/> high surrogate.</param>
		/// <param name="lowSurrogate">The <see cref="UInt16"/> low surrogate.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(UInt16 highSurrogate, UInt16 lowSurrogate) =>
			Unsafe.IsHighSurrogate(highSurrogate) && Unsafe.IsLowSurrogate(lowSurrogate)
				? new Rune(Unsafe.Utf16Decode(highSurrogate, lowSurrogate))
				: Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="highSurrogate">The <see cref="Char"/> high surrogate.</param>
		/// <param name="lowSurrogate">The <see cref="Char"/> low surrogate.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Char highSurrogate, Char lowSurrogate) =>
			Unsafe.IsHighSurrogate(highSurrogate) && Unsafe.IsLowSurrogate(lowSurrogate)
				? new Rune(Unsafe.Utf16Decode(highSurrogate, lowSurrogate))
				: Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-16 sequence into an <see cref="Array"/> of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="Array"/> of <see cref="UInt16"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static Rune[] Decode(params UInt16[] units) {
			Int32 b = 0;
			Int32 u = 0;
			Rune[] buffer = new Rune[units.Length];
			while (u < units.Length) {
				switch (SequenceLength(units[u])) {
				case 1:
					buffer[b++] = Decode(units[u++]);
					break;
				case 2:
					buffer[b++] = Decode(units[u++], units[u++]);
					break;
				default:
					buffer[b++] = Rune.ReplacementChar;
					u++;
					break;
				}
			}
			Rune[] result = new Rune[b];
			Array.Copy(buffer, 0, result, 0, b);
			return result;
		}

		/// <summary>
		/// Decode the UTF-16 sequence into an <see cref="Array"/> of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="Array"/> of <see cref="Char"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static Rune[] Decode(params Char[] units) {
			Int32 b = 0;
			Int32 u = 0;
			Rune[] buffer = new Rune[units.Length];
			while (u < units.Length) {
				switch (SequenceLength(units[u])) {
				case 1:
					buffer[b++] = Decode(units[u++]);
					break;
				case 2:
					buffer[b++] = Decode(units[u++], units[u++]);
					break;
				default:
					buffer[b++] = Rune.ReplacementChar;
					u++;
					break;
				}
			}
			Rune[] result = new Rune[b];
			Array.Copy(buffer, 0, result, 0, b);
			return result;
		}

		/// <summary>
		/// Decode the UTF-16 sequence into an <see cref="Array"/> of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="String"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static Rune[] Decode(String units) {
			Int32 b = 0;
			Int32 u = 0;
			Rune[] buffer = new Rune[units.Length];
			while (u < units.Length) {
				switch (SequenceLength(units[u])) {
				case 1:
					buffer[b++] = Decode(units[u++]);
					break;
				case 2:
					buffer[b++] = Decode(units[u++], units[u++]);
					break;
				default:
					buffer[b++] = Rune.ReplacementChar;
					u++;
					break;
				}
			}
			Rune[] result = new Rune[b];
			Array.Copy(buffer, 0, result, 0, b);
			return result;
		}

		/// <summary>
		/// Is the <paramref name="unit"/> the first unit of a UTF-16 sequence?
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> to check.</param>
		/// <returns><see langword="true"/> if the first unit of a UTF-16 sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsFirstUnit(UInt16 unit) => unit.Within(0x0000, 0xDBFF) || unit.Within(0xE000, 0xFFFF);

		/// <summary>
		/// Get the valid range the next unit after <paramref name="unit"/> can be within.
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> to check.</param>
		/// <param name="lower">The lower bound of the next <see cref="UInt16"/>.</param>
		/// <param name="upper">The upper bound of the next <see cref="UInt16"/>.</param>
		/// <remarks>
		/// <para>This is meant to be similar in design to <see cref="Utf8.NextByteRange(Byte, out Byte, out Byte)"/> and so it works the same way, even though it could be made not to for UTF-16 specifically. This variant gets a specific range for the next code unit when possible, and otherwise returns the full range from 0x0000..0xFFFF.</para>
		/// </remarks>
		public static void NextUnitRange(UInt16 unit, out UInt16 lower, out UInt16 upper) {
			if (unit.Within(0xD800, 0xDBFF)) {
				lower = 0xDC00;
				upper = 0xDFFF;
			} else {
				lower = 0x0000;
				upper = 0xFFFF;
			}
		}

		/// <summary>
		/// What is the length of the UTF-16 sequence, assuming <paramref name="unit"/> is the first unit in the sequence?
		/// </summary>
		/// <param name="unit">The first byte in the sequence.</param>
		/// <returns>The length of the sequence, or 0 if <paramref name="unit"/> is not the first unit, or is an invalid byte.</returns>
		public static Int32 SequenceLength(UInt16 unit) {
			if (unit.Within(0xD800, 0xDBFF)) {
				return 2;
			} else if (unit.Within(0xDC00, 0xDFFF)) {
				return 0;
			} else {
				return 1;
			}
		}
	}
}
