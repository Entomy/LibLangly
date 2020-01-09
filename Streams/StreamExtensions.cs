using System;
using System.IO;
using System.Text;

namespace Stringier.Streams {
	public static class StreamExtensions {
		/// <summary>
		/// Reads the next, maximum of, <paramref name="count"/> characters from the input stream and advances the byte position by the amount read.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="count">The maximum of the characters to read.</param>
		/// <returns>An <see cref="Array"/> of <see cref="Byte"/> containing the read characters.</returns>
		public static Byte[] Read(this Stream stream, Int32 count) {
			Byte[] buf = new Byte[count];
			Int32 c = stream.Read(buf, 0, count);
			Byte[] res = new Byte[c];
			Array.Copy(buf, 0, res, 0, c);
			return res;
		}

		/// <summary>
		/// Reads a codepoint from the stream and advances the position within the stream by one character, or returns -1 if at the end of the stream, or -2 if an invalid sequence.
		/// </summary>
		/// <returns>The codepoint as a <see cref="Int32"/>, -1 if at the end of the stream, or -2 if an invalid sequence.</returns>
		/// <remarks>
		/// This method assumes UTF-8 encoding.
		/// </remarks>
		public static Int32 ReadCodepoint(this Stream stream) {
			Byte[] sequence = new Byte[4] { 0x00, 0x00, 0x00, 0x00 };
			Int32 bytes = 1;
			// The first byte in the sequence encodes the length of the sequence, so determine that, then read in the rest of the sequence.
			Int32 @byte = stream.ReadByte();
			switch (@byte) {
			case var b when (b - 0x00) * (0x7F - b) >= 0:
				sequence[0] = (Byte)@byte;
				break;
			case var b when (b - 0xC2) * (0xDF - b) >= 0:
				bytes = 2;
				sequence[0] = (Byte)@byte;
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[1] = (Byte)@byte;
				} else {
					return -1;
				}
				break;
			case var b when (b - 0xE0) * (0xEF - b) >= 0:
				bytes = 3;
				sequence[0] = (Byte)@byte;
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[1] = (Byte)@byte;
				} else {
					return -1;
				}
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[2] = (Byte)@byte;
				} else {
					return -1;
				}
				break;
			case var b when (b - 0xF0) * (0xF4 - b) >= 0:
				bytes = 4;
				sequence[0] = (Byte)@byte;
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[1] = (Byte)@byte;
				} else {
					return -1;
				}
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[2] = (Byte)@byte;
				} else {
					return -1;
				}
				if ((@byte = stream.ReadByte()) >= 0) {
					sequence[3] = (Byte)@byte;
				} else {
					return -1;
				}
				break;
			case -1:
				return -1;
			default:
				return -2;
			}
			// Now decode the sequence
			Decoder decoder = Encoding.UTF8.GetDecoder();
			Char[] chars = new Char[3];
			Int32 c = decoder.GetChars(sequence, 0, bytes, chars, 0);
			if (c > 0) {
				Int32 result = 0;
				for (Int32 i = 0; i < chars.Length; i++) {
					result += chars[i];
				}
				return result;
			} else {
				return -2;
			}
		}
	}
}
