using System;

namespace Stringier.Patterns {
	/// <summary>
	/// Internal shared random number generator.
	/// </summary>
	/// <remarks>
	/// This is used to generate hash codes (that won't be used anyways) for types that have equality defined, basically to shut up the compiler and analyzers about what would be an anti-pattern that can't possibly exist because ref structs cant be put in situations where hash codes would be used.
	/// </remarks>
	internal static class Rng {
		/// <summary>
		/// The actual <see cref="Random"/> instance.
		/// </summary>
		/// <remarks>
		/// This is shared and will eventually loop over previous values, but again, read the class remarks about why this isn't actually an issue.
		/// </remarks>
		private static readonly Random Random = new Random();

		/// <summary>
		/// Returns a non-negative random integer.
		/// </summary>
		/// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="Int32.MaxValue"/>.</returns>
		internal static Int32 Next() => Random.Next();
	}
}
