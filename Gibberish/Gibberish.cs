using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier {
	/// <summary>
	/// Provides generators for gibberish.
	/// </summary>
	/// <remarks>
	/// This is used for testing and benchmarking purposes, specifically for stress testing.
	/// </remarks>
	public static class Gibberish {
		/// <summary>
		/// Generate gibberish.
		/// </summary>
		/// <param name="reductionFactor">The factor by which to reduce the total gibberish generated. Without a reduction factor it generates a string of length <see cref="Int32.MaxValue"/>. The factor cuts this length down.</param>
		/// <param name="bad">Whether to insert a bad character into the string.</param>
		/// <returns>A string of gibberish.</returns>
		[SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "This is just a text generator for tests and benchmarks, it doesn't need to be cryptographically secure")]
		[SuppressMessage("Security", "SCS0005:Weak random generator", Justification = "This is just a text generator for tests and benchmarks, it doesn't need to be cryptographically secure")]
		public static String Generate(Int32 reductionFactor, Boolean bad = false) {
			Random random = new Random();
			Char[] pool = new[] { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			StringBuilder builder = new StringBuilder();
			for (Int32 i = 0; i < Int32.MaxValue / reductionFactor; i++) {
				_ = bad && i == (Int32.MaxValue / reductionFactor) - 2 ? builder.Append('/') : builder.Append(pool[random.Next() % pool.Length]);
			}
			return builder.ToString();
		}
	}
}
