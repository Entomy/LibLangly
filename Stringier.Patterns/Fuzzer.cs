using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	/// <summary>
	/// Represents a fuzzy string pattern, a pattern which roughly matches within a tollerance.
	/// </summary>
	internal sealed class Fuzzer : Modifier {
		/// <summary>
		/// The actual text being matched.
		/// </summary>
		internal readonly ReadOnlyMemory<Char> String;

		/// <summary>
		/// The maximum allowed edits to still be considered a match.
		/// </summary>
		internal readonly Int32 MaxEdits;

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/> and <paramref name="maxEdits"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="maxEdits">The maximum amount of edits allowed for a match.</param>
		internal Fuzzer([DisallowNull] String @string, Int32 maxEdits) : this(@string.AsMemory(), maxEdits) { }

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/> and <paramref name="maxEdits"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="maxEdits">The maximum amount of edits allowed for a match.</param>
		internal Fuzzer(ReadOnlyMemory<Char> @string, Int32 maxEdits) {
			String = @string;
			MaxEdits = maxEdits;
		}
	}
}
