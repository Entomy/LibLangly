using System;
using System.Text;

namespace Stringier.Encodings {
	/// <summary>
	/// Helper functions for working with UTF-8 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-8 stream, not a buffer. This is important, because it enables us to more easily support stream decoding. Buffered data doesn't need special considerations, so this still work with buffers.
	/// </remarks>
	public static class Utf8 {
		/// <summary>
		/// Decode the UTF-8 sequence into a <see cref="Rune"/>.
		/// </summary>
		/// <param name="first">The first <see cref="Byte"/> of the sequence.</param>
		/// <returns>The decoded <see cref="Rune"/>.</returns>
		public static Rune Decode(Byte first) => first.Within(0x00, 0x7F) ? new Rune(first) : Rune.ReplacementChar;

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
			if (!second.Within(lower, upper)) {
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
			if (!second.Within(lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(third, out lower, out upper);
			if (!third.Within(lower, upper)) {
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
			if (!second.Within(lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(second, out lower, out upper);
			if (!third.Within(lower, upper)) {
				goto ReplacementChar;
			}
			NextByteRange(third, out lower, out upper);
			if (!fourth.Within(lower, upper)) {
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
		/// Decode the UTF-8 sequence into an <see cref="Array"/> of <see cref="Rune"/>.
		/// </summary>
		/// <param name="bytes">The <see cref="Array"/> of <see cref="Byte"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		public static Rune[] Decode(params Byte[] bytes) {
			Int32 b = 0;
			Int32 y = 0;
			Rune[] buffer = new Rune[bytes.Length];
			while (y < bytes.Length) {
				switch (SequenceLength(bytes[y])) {
				case 1:
					buffer[b++] = Decode(bytes[y++]);
					break;
				case 2:
					buffer[b++] = Decode(bytes[y++], bytes[y++]);
					break;
				case 3:
					buffer[b++] = Decode(bytes[y++], bytes[y++], bytes[y++]);
					break;
				case 4:
					buffer[b++] = Decode(bytes[y++], bytes[y++], bytes[y++], bytes[y++]);
					break;
				default:
					buffer[b++] = Rune.ReplacementChar;
					y++;
					break;
				}
			}
			Rune[] result = new Rune[b];
			Array.Copy(buffer, 0, result, 0, b);
			return result;
		}

		/// <summary>
		/// Decode the UTF-8 sequence into an <see cref="Array"/> of <see cref="Rune"/>.
		/// </summary>
		/// <param name="useStack"><see langword="true"/> to force usage of the stack instead of the heap.</param>
		/// <param name="bytes">The <see cref="Array"/> of <see cref="Byte"/> to decode.</param>
		/// <returns>The decoded <see cref="Rune"/>s.</returns>
		/// <remarks>
		/// This allows calling a very optimized variant of the algorithm. This can blow up the stack however, which is an unhandleable exception.
		/// </remarks>
		public static Rune[] Decode(Boolean useStack, params Byte[] bytes) => useStack ? Decode_Stack(bytes) : Decode(bytes);

		/// <summary>
		/// Encodes the <see cref="Rune"/> into a UTF-8 sequence.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to encode.</param>
		/// <returns>The UTF-8 sequence as an <see cref="Array"/> of <see cref="Byte"/>; <see langword="null"/> if <paramref name="rune"/> could not be encoded.</returns>
		/// <remarks>
		/// Assuming both myself and Microsoft don't have any bugs in our code, this should always succeed, because <see cref="Rune"/> uses validating constructors.
		/// </remarks>
		public static Byte[]? Encode(Rune rune) {
			Byte[]? result = null;
			switch (rune.Utf8SequenceLength) {
			case 1:
				result = new Byte[] { (Byte)rune.Value };
				break;
			case 2:
				result = new Byte[2];
				result[0] = (Byte)(rune.Value >> 6 | 0b1100_0000);
				result[1] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			case 3:
				result = new Byte[3];
				result[0] = (Byte)(rune.Value >> 12 | 0b1110_0000);
				result[1] = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				result[2] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			case 4:
				result = new Byte[4];
				result[0] = (Byte)(rune.Value >> 18 | 0b1111_0000);
				result[1] = (Byte)(rune.Value >> 12 & 0b0011_1111 | 0b1000_0000);
				result[2] = (Byte)(rune.Value >> 6 & 0b0011_1111 | 0b1000_0000);
				result[3] = (Byte)(rune.Value & 0b0011_1111 | 0b1000_0000);
				break;
			default:
				throw new InvalidOperationException($"Somehow, {nameof(Encode)} thinks the encoded length should be different from anything possible. This means there may be a bug in {nameof(Rune.Utf8SequenceLength)}.");
			}
			return result;
		}

		/// <summary>
		/// Is the <paramref name="byte"/> the first byte of a UTF-8 sequence?
		/// </summary>
		/// <param name="byte">The <see cref="Byte"/> to check.</param>
		/// <returns><see langword="true"/> if the first byte of a UTF-8 sequence; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsFirstByte(Byte @byte) => @byte.Within(0x00, 0x7F) || @byte.Within(0xC2, 0xF4);

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

		private static unsafe Rune[] Decode_Stack(params Byte[] bytes) {
			Int32 b = 0;
			Int32 y = 0;
			Rune* buffer = stackalloc Rune[bytes.Length];
			while (y < bytes.Length) {
				switch (SequenceLength(bytes[y])) {
				case 1:
					buffer[b++] = Decode(bytes[y++]);
					break;
				case 2:
					buffer[b++] = Decode(bytes[y++], bytes[y++]);
					break;
				case 3:
					buffer[b++] = Decode(bytes[y++], bytes[y++], bytes[y++]);
					break;
				case 4:
					buffer[b++] = Decode(bytes[y++], bytes[y++], bytes[y++], bytes[y++]);
					break;
				default:
					buffer[b++] = Rune.ReplacementChar;
					y++;
					break;
				}
			}
			Rune[] result = new Rune[b];
			fixed (Rune* pRes = result) {
				for (Int32 i = 0; i < b; i++) {
					pRes[i] = buffer[i];
				}
			}
			return result;
		}
	}
}