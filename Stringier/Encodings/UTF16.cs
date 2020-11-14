using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Defender;

namespace Stringier.Encodings {
	/// <summary>
	/// Helper functions for working with UTF-16 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-16 stream, not a buffer.
	/// </remarks>
	public static class UTF16 {
		/// <summary>
		/// Decode the UTF-16 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> code unit.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		[CLSCompliant(false)]
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
		[CLSCompliant(false)]
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
		/// Decode the UTF-16 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="String"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(String units) {
			Guard.NotNull(units, nameof(units));
			return Decode(units.AsSpan());
		}

		/// <summary>
		/// Decode the UTF-16 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="Array"/> of <see cref="Char"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(params Char[] units) {
			Guard.NotNull(units, nameof(units));
			return Decode(units.AsSpan());
		}

		/// <summary>
		/// Decode the UTF-16 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="Array"/> of <see cref="UInt16"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		[CLSCompliant(false)]
		public static ReadOnlySpan<Rune> Decode(params UInt16[] units) {
			Guard.NotNull(units, nameof(units));
			return Decode(units.AsSpan());
		}

		/// <summary>
		/// Decode the UTF-16 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(ReadOnlySpan<Char> units) {
			Int32 b = 0;
			Int32 u = 0;
			Span<Rune> buffer = new Rune[units.Length];
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
			return buffer.Slice(0, b);
		}

		/// <summary>
		/// Decode the UTF-16 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="units">The <see cref="ReadOnlySpan{T}"/> of <see cref="UInt16"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		[CLSCompliant(false)]
		public static ReadOnlySpan<Rune> Decode(ReadOnlySpan<UInt16> units) {
			Int32 b = 0;
			Int32 u = 0;
			Span<Rune> buffer = new Rune[units.Length];
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
			return buffer.Slice(0, b);
		}

		/// <summary>
		/// Encodes the <paramref name="rune"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-16 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Char> Encode(Rune rune) {
			Span<Char> result = new Char[2];
			Int32 length = 0;
			Encode(rune, result, ref length);
			return result.Slice(0, length);
		}

		/// <summary>
		/// Encodes the <paramref name="rune"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <param name="high">The high surrogate, or single code unit.</param>
		/// <param name="low">The low surrogate, or U+0000 if not needed.</param>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static void Encode(Rune rune, out Char high, out Char low) {
			switch (rune.Utf16SequenceLength) {
			case 1:
				high = unchecked((Char)rune.Value);
				low = '\0';
				break;
			case 2:
				Unsafe.Utf16Encode(unchecked((UInt16)rune.Value), out high, out low);
				break;
			default:
				high = '\uFFFD';
				low = '\uFFFD';
				break;
			}
		}

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-16 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Char> Encode(Rune[] runes) {
			Guard.NotNull(runes, nameof(runes));
			return Encode(runes.AsSpan());
		}

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-16 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Char> Encode(ReadOnlySpan<Rune> runes) {
			Span<Char> result = new Char[runes.Length * 2];
			Int32 length = 0;
			foreach (Rune rune in runes) {
				Encode(rune, result, ref length);
			}
			return result.Slice(0, length);
		}

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-16 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <param name="length">The length of the <paramref name="runes"/> sequence.</param>
		/// <returns>The UTF-16 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Char> Encode(Rune* runes, Int32 length) {
			Guard.NotNull(runes, nameof(runes));
			return Encode(new ReadOnlySpan<Rune>(runes, length));
		}

		/// <summary>
		/// Is the <paramref name="unit"/> the first unit of a UTF-16 sequence?
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> to check.</param>
		/// <returns><see langword="true"/> if the first unit of a UTF-16 sequence; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static Boolean IsFirstUnit(UInt16 unit) => Check.Within(unit, (UInt16)0x0000, (UInt16)0xDBFF) || Check.Within(unit, (UInt16)0xE000, (UInt16)0xFFFF);

		/// <summary>
		/// Is the <paramref name="char"/> the first unit of a UTF-16 sequence?
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to check.</param>
		/// <returns><see langword="true"/> if the first unit of a UTF-16 sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsFirstUnit(Char @char) => IsFirstUnit((UInt16)@char);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a high surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if high surrogate; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static Boolean IsHighSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xD800u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="char"/> a high surrogate?
		/// </summary>
		/// <param name="char">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if high surrogate; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsHighSurrogate(Char @char) => IsHighSurrogate((UInt32)@char);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a low surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if low surrogate; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static Boolean IsLowSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xDC00u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="char"/> a low surrogate?
		/// </summary>
		/// <param name="char">The <see cref="Char"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if low surrogate; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLowSurrogate(Char @char) => IsLowSurrogate((UInt32)@char);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a surrogate value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a surrogate value; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public static Boolean IsSurrogate(UInt32 codePoint) => Check.Within(codePoint, 0xD800u, 0xDFFFu);

		/// <summary>
		/// Is the <paramref name="char"/> a surrogate value?
		/// </summary>
		/// <param name="char">The <see cref="Char"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a surrogate value; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSurrogate(Char @char) => IsSurrogate((UInt32)@char);

		/// <summary>
		/// Get the valid range the next unit after <paramref name="unit"/> can be within.
		/// </summary>
		/// <param name="unit">The <see cref="UInt16"/> to check.</param>
		/// <param name="lower">The lower bound of the next <see cref="UInt16"/>.</param>
		/// <param name="upper">The upper bound of the next <see cref="UInt16"/>.</param>
		/// <remarks>
		/// <para>This is meant to be similar in design to <see cref="UTF8.NextByteRange(Byte, out Byte, out Byte)"/> and so it works the same way, even though it could be made not to for UTF-16 specifically. This variant gets a specific range for the next code unit when possible, and otherwise returns the full range from 0x0000..0xFFFF.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static void NextUnitRange(UInt16 unit, out UInt16 lower, out UInt16 upper) {
			if (Check.Within(unit, (UInt16)0xD800, (UInt16)0xDBFF)) {
				lower = 0xDC00;
				upper = 0xDFFF;
			} else {
				lower = 0x0000;
				upper = 0xFFFF;
			}
		}

		/// <summary>
		/// Get the valid range the next unit after <paramref name="char"/> can be within.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to check.</param>
		/// <param name="lower">The lower bound of the next <see cref="Char"/>.</param>
		/// <param name="upper">The upper bound of the next <see cref="Char"/>.</param>
		/// <remarks>
		/// <para>This is meant to be similar in design to <see cref="UTF8.NextByteRange(Byte, out Byte, out Byte)"/> and so it works the same way, even though it could be made not to for UTF-16 specifically. This variant gets a specific range for the next code unit when possible, and otherwise returns the full range from 0x0000..0xFFFF.</para>
		/// </remarks>
		public static void NextUnitRange(Char @char, out Char lower, out Char upper) {
			NextUnitRange(@char, out UInt16 l, out UInt16 u);
			lower = (Char)l;
			upper = (Char)u;
		}

		/// <summary>
		/// What is the length of the UTF-16 sequence, assuming <paramref name="unit"/> is the first unit in the sequence?
		/// </summary>
		/// <param name="unit">The first code unit in the sequence.</param>
		/// <returns>The length of the sequence, or 0 if <paramref name="unit"/> is not the first unit, or is an invalid unit.</returns>
		[CLSCompliant(false)]
		public static Int32 SequenceLength(UInt16 unit) {
			if (Check.Within(unit, (UInt16)0xD800, (UInt16)0xDBFF)) {
				return 2;
			} else if (Check.Within(unit, (UInt16)0xDC00, (UInt16)0xDFFF)) {
				return 0;
			} else {
				return 1;
			}
		}


		/// <summary>
		/// What is the length of the UTF-16 sequence, assuming <paramref name="char"/> is the first unit in the sequence?
		/// </summary>
		/// <param name="char">The first code unit in the sequence.</param>
		/// <returns>The length of the sequence, or 0 if <paramref name="char"/> is not the first unit, or is an invalid unit.</returns>
		public static Int32 SequenceLength(Char @char) => SequenceLength((UInt16)@char);

		private static void Encode(Rune rune, Span<Char> result, ref Int32 index) {
			switch (rune.Utf16SequenceLength) {
			case 1:
				result[index++] = (Char)rune.Value;
				break;
			case 2:
				Unsafe.Utf16Encode((UInt32)rune.Value, out result[index++], out result[index++]);
				break;
			}
		}

		/// <summary>
		/// Big-Endian.
		/// </summary>
		[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Nesting actually creates the proper structure, especially as endian variants unnested lose all context.")]
		public static class BE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			public static IReadOnlyList<Byte> BOM { get; } = new Byte[] { 0xFE, 0xFF };
		}

		/// <summary>
		/// Little-Endian.
		/// </summary>
		[SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "Nesting actually creates the proper structure, especially as endian variants unnested lose all context.")]
		public static class LE {
			/// <summary>
			/// The Byte-Order-Mark of this encoding.
			/// </summary>
			public static IReadOnlyList<Byte> BOM { get; } = new Byte[] { 0xFF, 0xFE };
		}
	}
}
