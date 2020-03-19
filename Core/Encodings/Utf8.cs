using System;

namespace Stringier.Encodings {
	/// <summary>
	/// Helper functions for working with UTF-8 data.
	/// </summary>
	/// <remarks>
	/// Most of these helpers assume working with a UTF-8 stream, not a buffer. This is important, because it enables us to more easily support stream decoding. Buffered data doesn't need special considerations, so this still work with buffers.
	/// </remarks>
	public static class Utf8 {
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
			if (@byte.Within(0x00, 0x7F)) {
				return 1;
			} else if (@byte.Within(0xC2, 0xDF)) {
				return 2;
			} else if (@byte.Within(0xE0, 0xEF)) {
				return 3;
			} else if (@byte.Within(0xF0, 0xF4)) {
				return 4;
			} else {
				return 0;
			}
		}
	}
}