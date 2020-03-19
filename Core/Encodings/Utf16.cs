using System;

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
