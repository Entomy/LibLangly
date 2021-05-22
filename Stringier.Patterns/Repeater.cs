using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Stringier.Patterns.Pattern"/> whos content repeats a given number of times.
	/// </summary>
	internal sealed class Repeater : Modifier {
		/// <summary>
		/// The amount of times to be parsed.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// The <see cref="Stringier.Patterns.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Repeater"/> from the given <paramref name="pattern"/> and <paramref name="count"/>
		/// </summary>
		/// <param name="pattern">The <see cref="Stringier.Patterns.Pattern"/> to be parsed.</param>
		/// <param name="count">The amount of times to be parsed.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> must be a positive integer.</exception>
		internal Repeater([DisallowNull] Pattern pattern, Int32 count) {
			Pattern = pattern;
			if (count <= 0) {
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive");
			}
			Count = count;
		}
	}
}
