﻿using System;
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
			IsHighSurrogate(highSurrogate) && IsLowSurrogate(lowSurrogate)
				? new Rune(Unsafe.Utf16Decode(highSurrogate, lowSurrogate))
				: Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="highSurrogate">The <see cref="Char"/> high surrogate.</param>
		/// <param name="lowSurrogate">The <see cref="Char"/> low surrogate.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Char highSurrogate, Char lowSurrogate) =>
			IsHighSurrogate(highSurrogate) && IsLowSurrogate(lowSurrogate)
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
		/// Encodes the <see cref="Rune"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-16 sequence as an <see cref="Array"/> of <see cref="Char"/>; <see langword="null"/> if <paramref name="rune"/> could not be encoded.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors.
		/// </remarks>
		public static Char[]? Encode(Rune rune) {
			Char[]? result = null;
			switch (rune.Utf16SequenceLength) {
			case 1:
				result = new Char[1] { (Char)rune.Value };
				break;
			case 2:
				result = new Char[2];
				Unsafe.Utf16Encode((UInt32)rune.Value, out result[0], out result[1]);
				break;
			default:
				throw new InvalidOperationException($"Somehow, {nameof(Encode)} thinks the encoded length should be different from anything possible. This means there may be a bug in {nameof(Rune.Utf16SequenceLength)}.");
			}
			return result;
		}

		/// <summary>
		/// Is the <paramref name="unit"/> the first unit of a UTF-16 sequence?
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> to check.</param>
		/// <returns><see langword="true"/> if the first unit of a UTF-16 sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsFirstUnit(UInt16 unit) => unit.Within(0x0000, 0xDBFF) || unit.Within(0xE000, 0xFFFF);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a high surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if high surrogate; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsHighSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xD800u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a low surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if low surrogate; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLowSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xDC00u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a surrogate value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a surrogate value; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSurrogate(UInt32 codePoint) => codePoint.Within(0xD800u, 0xDFFFu);

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
