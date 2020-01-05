using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Adapts <see cref="System.Text.RegularExpressions.Regex"/> to work with <see cref="Pattern"/>.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class RegexAdapter : Pattern {
		/// <summary>
		/// The actual <see cref="System.Text.RegularExpressions.Regex"/>.
		/// </summary>
		private readonly Regex Regex;

		/// <summary>
		/// Initializes a new <see cref="RegexAdapter"/> from the given <paramref name="regex"/>.
		/// </summary>
		/// <param name="regex">The actual <see cref="System.Text.RegularExpressions.Regex"/>.</param>
		internal RegexAdapter(Regex regex) => Regex = regex;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => true; //This is true because it represents "the pattern may possibly be here", and we have no way of extracting the header from a Regex, so just don't use this optimization.

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			Match Match = Regex.Match(source.ToString());
			if (Match.Success) {
				source.Position += Match.Length;
				result.Length += Match.Length;
			} else {
				result.Error = Error.ConsumeFailed;
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => throw new InvalidOperationException("Regex can not be negated");

		#region Negator

		/// <summary>
		/// Negates this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		internal override Pattern Negate() => throw new PatternConstructionException("Regex can not be negated");

		#endregion
	}
}
