using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content should be neglected.
	/// </summary>
	/// <remarks>
	/// This is syntactic sugar around the Neglect parser, which parses anything that does not match the pattern, with some special semantics for certain patterns. It is basically saying "anything that isn't this, that is the same length".
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Negator : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Intialize a new <see cref="Negator"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal Negator(Pattern pattern) => Pattern = pattern;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><see langword="true"/> if this <see cref="Patterns.Pattern"/> may be present, <see langword="false"/> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => !Pattern.CheckHeader(ref source);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) => Pattern.Neglect(ref source, ref result, trace);

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => Pattern.Consume(ref source, ref result, trace);

		#region Negator

		/// <summary>
		/// Marks this <see cref="Patterns.Pattern"/> as negated.
		/// </summary>
		/// <returns>A new <see cref="Patterns.Pattern"/> which is negated.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Patterns.Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal override Pattern Negate() => Pattern;

		#endregion
	}
}
