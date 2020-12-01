using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly {
	/// <summary>
	/// Helper functions for working with UTF-8 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-8 stream, not a buffer. This is important, because it enables us to more easily support stream decoding. Buffered data doesn't need special considerations, so this still work with buffers.
	/// </remarks>
	public static class UTF8 {
		/// <summary>
		/// The Byte-Order-Mark of this encoding.
		/// </summary>
		public static IReadOnlyList<Byte> BOM { get; } = new Byte[] { 0xEF, 0xBB, 0xBF };

		/// <summary>
		/// Decode the UTF-8 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="first">The first <see cref="Byte"/> of the sequence.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Byte first) => Check.Within(first, (Byte)0x00, (Byte)0x7F) ? new Rune(first) : Rune.ReplacementChar;

		/// <summary>
		/// Decode the UTF-8 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="first">The first <see cref="Byte"/> of the sequence.</param>
		/// <param name="second">The second <see cref="Byte"/> of the sequence.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Byte first, Byte second) {
			if (!IsFirstByte(first)) {
				goto ReplacementChar;
			}
			NextByteRange(first, out Byte lower, out Byte upper);
			if (!Check.Within(second, lower, upper)) {
				goto ReplacementChar;
			}
			UInt32 codePoint = 0;
			codePoint |= ((UInt32)first & 0x1F) << 6;
			codePoint |= (UInt32)second & 0x3F;
			return new Rune(codePoint);
		ReplacementChar:
			return Rune.ReplacementChar;
		}

		/// <summary>
		/// Decode the UTF-8 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="first">The first <see cref="Byte"/> of the sequence.</param>
		/// <param name="second">The second <see cref="Byte"/> of the sequence.</param>
		/// <param name="third">The third <see cref="Byte"/> of the sequence.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Byte first, Byte second, Byte third) {
			if (!IsFirstByte(first)) {
				goto ReplacementChar;
			}
			NextByteRange(first, out Byte lower, out Byte upper);
			if (!Check.Within(second, lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(third, out lower, out upper);
			if (!Check.Within(third, lower, upper)) {
				goto ReplacementChar;
			}
			UInt32 codePoint = 0;
			codePoint |= ((UInt32)first & 0x0F) << 12;
			codePoint |= ((UInt32)second & 0x3F) << 6;
			codePoint |= (UInt32)third & 0x3F;
			return new Rune(codePoint);
		ReplacementChar:
			return Rune.ReplacementChar;
		}

		/// <summary>
		/// Decode the UTF-8 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="first">The first <see cref="Byte"/> of the sequence.</param>
		/// <param name="second">The second <see cref="Byte"/> of the sequence.</param>
		/// <param name="third">The third <see cref="Byte"/> of the sequence.</param>
		/// <param name="fourth">The fourth <see cref="Byte"/> of the sequence.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Byte first, Byte second, Byte third, Byte fourth) {
			if (!IsFirstByte(first)) {
				goto ReplacementChar;
			}
			NextByteRange(first, out Byte lower, out Byte upper);
			if (!Check.Within(second, lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(second, out lower, out upper);
			if (!Check.Within(third, lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(third, out lower, out upper);
			if (!Check.Within(fourth, lower, upper)) {
				goto ReplacementChar;
			}
			UInt32 codePoint = 0;
			codePoint |= ((UInt32)first & 0x07) << 18;
			codePoint |= ((UInt32)second & 0x3F) << 12;
			codePoint |= ((UInt32)third & 0x3F) << 6;
			codePoint |= (UInt32)fourth & 0x3F;
			return new Rune(codePoint);
		ReplacementChar:
			return Rune.ReplacementChar;
		}

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode([AllowNull] params Byte[] bytes) => bytes is not null ? Decode(bytes.AsSpan()) : ReadOnlySpan<Rune>.Empty;

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(Memory<Byte> bytes) => Decode(bytes.Span);

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(ReadOnlyMemory<Byte> bytes) => Decode(bytes.Span);

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(Span<Byte> bytes) => Decode((ReadOnlySpan<Byte>)bytes);

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static ReadOnlySpan<Rune> Decode(ReadOnlySpan<Byte> bytes) {
			Int32 b = 0;
			Int32 y = 0;
			Span<Rune> buffer = new Rune[bytes.Length];
			while (y < bytes.Length) {
				buffer[b++] = Decode(bytes, ref y);
			}
			return buffer.Slice(0, b);
		}

		/// <summary>
		/// Decode the UTF-8 sequence into a sequence of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The bytes to decode.</param>
		/// <param name="length">The length of the <paramref name="bytes"/>.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Rune> Decode([AllowNull] Byte* bytes, Int32 length) => bytes is not null ? Decode(new ReadOnlySpan<Byte>(bytes, length)) : ReadOnlySpan<Rune>.Empty;

		/// <summary>
		/// Encodes the <see cref="Rune"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="Array"/> of <see cref="Byte"/>; <see langword="null"/> if <paramref name="rune"/> could not be encoded.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode(Rune rune) {
			Span<Byte> result = new Byte[4];
			Int32 length = 0;
			Encode(rune, result, ref length);
			return result.Slice(0, length);
		}

		/// <summary>
		/// Encodes the <see cref="Rune"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <param name="first">The first byte.</param>
		/// <param name="second">The second byte, or U+0000 if not needed.</param>
		/// <param name="third">The third byte, or U+0000 if not needed.</param>
		/// <param name="fourth">The fourth byte, or U+0000 if not needed.</param>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors.
		/// </remarks>
		public static void Encode(Rune rune, out Byte first, out Byte second, out Byte third, out Byte fourth) {
			switch (rune.Utf8SequenceLength) {
			case 1:
				first = (Byte)rune.Value;
				second = 0;
				third = 0;
				fourth = 0;
				break;
			case 2:
				first = (Byte)(rune.Value >> 6 | 0b1100_0000);
				second = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				third = 0;
				fourth = 0;
				break;
			case 3:
				first = (Byte)(rune.Value >> 12 | 0b1110_0000);
				second = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				third = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				fourth = 0;
				break;
			case 4:
				first = (Byte)(rune.Value >> 18 | 0b1111_0000);
				second = (Byte)(rune.Value >> 12 & 0b0011_1111 | 0b1000_0000);
				third = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				fourth = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			default:
				first = 0xEF;
				second = 0xBF;
				third = 0xBD;
				fourth = 0;
				break;
			}
		}

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode([AllowNull] Rune[] runes) => runes is not null ? Encode(runes.AsSpan()) : ReadOnlySpan<Byte>.Empty;

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode(Memory<Rune> runes) => Encode(runes.Span);

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode(ReadOnlyMemory<Rune> runes) => Encode(runes.Span);

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode(Span<Rune> runes) => Encode((ReadOnlySpan<Rune>)runes);

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		public static ReadOnlySpan<Byte> Encode(ReadOnlySpan<Rune> runes) {
			Span<Byte> result = new Byte[runes.Length * 4];
			Int32 length = 0;
			foreach (Rune rune in runes) {
				Encode(rune, result, ref length);
			}
			return result.Slice(0, length);
		}

		/// <summary>
		/// Encodes the <paramref name="runes"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="runes">The sequence of <see cref="Rune"/> to encode.</param>
		/// <param name="length">The length of the <paramref name="runes"/> sequence.</param>
		/// <returns>The UTF-8 sequence as an <see cref="ReadOnlySpan{T}"/> of <see cref="Byte"/>.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors. However there are cases where, inside of the .NET runtime, Rune is created without validation, so, it's possible in theory.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe ReadOnlySpan<Byte> Encode([AllowNull] Rune* runes, Int32 length) => runes is not null ? Encode(new ReadOnlySpan<Rune>(runes, length)) : ReadOnlySpan<Byte>.Empty;

		/// <summary>
		/// Is the <paramref name="byte"/> the first byte of a UTF-8 sequence?
		/// </summary>
		/// <param name="byte">The <see cref="Byte"/> to check.</param>
		/// <returns><see langword="true"/> if the first byte of a UTF-8 sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsFirstByte(Byte @byte) => Check.Within(@byte, (Byte)0x00, (Byte)0x7F) || Check.Within(@byte, (Byte)0xC2, (Byte)0xF4);

		/// <summary>
		/// Gets the valid range the next byte after <paramref name="byte"/> can be within.
		/// </summary>
		/// <param name="byte">The <see cref="Byte"/> to check.</param>
		/// <param name="lower">The lower bound of the next <see cref="Byte"/>.</param>
		/// <param name="upper">The upper bound of the next <see cref="Byte"/>.</param>
		/// <remarks>
		/// <para>This can't possibly know when we are at the end of a sequence, so with the exception of special cases, it always outputs the range for a UTF-8 "tail". You need to use this together with <see cref="SequenceLength(Byte)"/> to know how long the sequence actually is. Because of how this is meant to be used, the range 0x00..0x7F does not return itself. When you have that, <see cref="SequenceLength(Byte)"/> will return 1 and you have no business using this method, so it's optimized to not even handle that case.</para>
		/// </remarks>
		public static void NextByteRange(Byte @byte, out Byte lower, out Byte upper) {
			if (@byte == 0xE0) {
				lower = 0xA0;
				upper = 0xBF;
			} else if (@byte == 0xED) {
				lower = 0x80;
				upper = 0x9F;
			} else if (@byte == 0xF0) {
				lower = 0x90;
				upper = 0xBF;
			} else if (@byte == 0xF4) {
				lower = 0x80;
				upper = 0x8F;
			} else {
				lower = 0x80;
				upper = 0xBF;
			}
		}

		/// <summary>
		/// What is the length of the UTF-8 sequence, assuming <paramref name="byte"/> is the first in the sequence?
		/// </summary>
		/// <param name="byte">The first byte in the sequence.</param>
		/// <returns>The length of the sequence, or 0 if <paramref name="byte"/> is not the first byte, or is an invalid byte.</returns>
		public static Int32 SequenceLength(Byte @byte) {
			if (@byte <= 0x7F) {
				return 1;
			} else if (@byte <= 0xC1) {
				return 0;
			} else if (@byte <= 0xDF) {
				return 2;
			} else if (@byte <= 0xEF) {
				return 3;
			} else if (@byte <= 0xF4) {
				return 4;
			} else {
				return 0;
			}
		}

		internal static Rune Decode(ReadOnlySpan<Byte> buffer, ref Int32 index) {
			switch (SequenceLength(buffer[index])) {
			case 1:
				if (index >= buffer.Length) {
					goto default;
				}
				return Decode(buffer[index++]);
			case 2:
				if (index + 1 >= buffer.Length) {
					goto default;
				}
				return Decode(buffer[index++], buffer[index++]);
			case 3:
				if (index + 2 >= buffer.Length) {
					goto default;
				}
				return Decode(buffer[index++], buffer[index++], buffer[index++]);
			case 4:
				if (index + 3 >= buffer.Length) {
					goto default;
				}
				return Decode(buffer[index++], buffer[index++], buffer[index++], buffer[index++]);
			default:
				index++;
				return Rune.ReplacementChar;
			}
		}

		internal static void Encode(Rune rune, Span<Byte> result, ref Int32 index) {
			switch (rune.Utf8SequenceLength) {
			case 1:
				result[index++] = (Byte)rune.Value;
				break;
			case 2:
				result[index++] = (Byte)(rune.Value >> 6 | 0b1100_0000);
				result[index++] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			case 3:
				result[index++] = (Byte)(rune.Value >> 12 | 0b1110_0000);
				result[index++] = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				result[index++] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			case 4:
				result[index++] = (Byte)(rune.Value >> 18 | 0b1111_0000);
				result[index++] = (Byte)(rune.Value >> 12 & 0b0011_1111 | 0b1000_0000);
				result[index++] = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				result[index++] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			default:
				throw new InvalidOperationException("A rune was somehow created that is invalid; this is a bug in the runtime.");
			}
		}
	}
}
