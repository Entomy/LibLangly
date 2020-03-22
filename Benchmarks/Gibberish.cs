using System;

namespace Benchmarks {
	/// <summary>
	/// Provides generators for gibberish.
	/// </summary>
	internal static class Gibberish {
		/// <summary>
		/// Generate gibberish.
		/// </summary>
		/// <param name="reductionFactor">The factor by which to reduce the total gibberish generated. Without a reduction factor it generates an <see cref="Array"/> of length <see cref="Int32.MaxValue"/>. The factor cuts this length down.</param>
		/// <returns>An <see cref="Array"/> of UTF-8 gibberish.</returns>
		public static Byte[] GenerateUtf8(Int32 reductionFactor) {
			Random random = new Random();
			Byte[] result = new Byte[Int32.MaxValue / reductionFactor];
			random.NextBytes(result);
			return result;
		}

		/// <summary>
		/// Generate gibberish.
		/// </summary>
		/// <param name="reductionFactor">The factor by which to reduce the total gibberish generated. Without a reduction factor it generates an <see cref="Array"/> of length <see cref="Int32.MaxValue"/>. The factor cuts this length down.</param>
		/// <returns>An <see cref="Array"/> of UTF-16 gibberish.</returns>
		public static Char[] GenerateUtf16(Int32 reductionFactor) {
			Random random = new Random();
			Char[] result = new Char[Int32.MaxValue / reductionFactor];
			for (Int32 i = 0; i < result.Length; i++) {
				result[i] = (Char)(random.Next() % UInt16.MaxValue);
			}
			return result;
		}
	}
}
