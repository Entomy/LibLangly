using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a fuzzy string pattern, a pattern which roughly matches within a tollerance.
	/// </summary>
	internal sealed class Fuzzer : Modifier {
		/// <summary>
		/// The actual text being matched.
		/// </summary>
		private readonly ReadOnlyMemory<Char> String;

		/// <summary>
		/// The maximum allowed edits to still be considered a match.
		/// </summary>
		private readonly Int32 MaxEdits;

		/// <summary>
		/// The <see cref="Case"/> to use when parsing.
		/// </summary>
		private readonly Case Casing;

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/> and <paramref name="maxEdits"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="maxEdits">The maximum amount of edits allowed for a match.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal Fuzzer([DisallowNull] String @string, Int32 maxEdits, Case casing) : this(@string.AsMemory(), maxEdits, casing) { }

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/> and <paramref name="maxEdits"/>.
		/// </summary>
		/// <param name="string">The text to parse.</param>
		/// <param name="maxEdits">The maximum amount of edits allowed for a match.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal Fuzzer(ReadOnlyMemory<Char> @string, Int32 maxEdits, Case casing) {
			String = @string;
			MaxEdits = maxEdits;
			Casing = casing;
		}

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location + String.Length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (EditDistance.Hamming(String, source.Slice(location, String.Length), Casing) <= MaxEdits) {
				trace?.Add(source.Slice(location, String.Length), location);
				location += String.Length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			if (location + String.Length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (EditDistance.Hamming(String, source.Slice(location, String.Length), Casing) > MaxEdits) {
				trace?.Add(source.Slice(location, String.Length), location);
				location += String.Length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}
	}
}
