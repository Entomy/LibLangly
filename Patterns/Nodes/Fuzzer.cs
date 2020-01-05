using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;
using static Stringier.Metrics;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a fuzzy string pattern, a pattern which roughly matches within a tollerance.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Fuzzer : Modifier {
		/// <summary>
		/// The actual <see cref="System.String"/> being matched.
		/// </summary>
		internal readonly String String = "";

		/// <summary>
		/// The maximum allowed edits to still be considered a match.
		/// </summary>
		internal readonly Int32 MaxEdits = 1;

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		internal Fuzzer(String @string) : base() => String = @string;

		/// <summary>
		/// Initialize a new <see cref="Fuzzer"/> with the given <paramref name="string"/> and <paramref name="maxEdits"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		/// <param name="maxEdits">The maximum amount of edits allowed for a match.</param>
		internal Fuzzer(String @string, Int32 maxEdits) : this(@string) => MaxEdits = maxEdits;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => true; //The edit could be the first character, so a full check is always required.

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			if (source.EOF) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			}
			ReadOnlySpan<Char> Peek = source.Peek(String.Length);
			if (HammingDistance(String, Peek) <= MaxEdits) {
				trace?.Collect(Peek, source.Position);
				source.Position += String.Length;
				result.Length += String.Length;
				result.Error = Error.None;
			} else {
				result.Error = Error.ConsumeFailed;
				trace?.Collect(result.Error, source.Position);
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			if (source.EOF) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			}
			ReadOnlySpan<Char> Peek = source.Peek(String.Length);
			if (HammingDistance(String, Peek) > MaxEdits) {
				trace?.Collect(Peek, source.Position);
				source.Position += String.Length;
				result.Length += String.Length;
				result.Error = Error.None;
			} else {
				result.Error = Error.NeglectFailed;
				trace?.Collect(result.Error, source.Position);
			}
		}
	}
}
