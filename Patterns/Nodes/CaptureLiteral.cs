using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a capture literal pattern, a pattern matching this exact capture.
	/// </summary>
	/// <remarks>
	/// This exists to get around visibility rules. <see cref="Patterns.Pattern"/> is <see langword="internal"/> and as a result can't have a public child. <see cref="Patterns.Capture"/> needs to be public because downstream needs to allocate and use captures.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class CaptureLiteral : Literal {
		/// <summary>
		/// The actual <see cref="Patterns.Capture"/> object.
		/// </summary>
		private readonly Capture CapStore;

		/// <summary>
		/// Initialize a new <see cref="CaptureLiteral"/> with the given <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Patterns.Capture"/> to parse.</param>
		internal CaptureLiteral(Capture capture) : base(Compare.CaseSensitive) => CapStore = capture;

		/// <summary>
		/// Initialize a new <see cref="CaptureLiteral"/> with the given <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Patterns.Capture"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		internal CaptureLiteral(Capture capture, Compare comparisonType) : base(comparisonType) => CapStore = capture;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => CapStore.Value.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) => CapStore.Value.Consume(ref source, ref result, ComparisonType, trace);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => CapStore.Value.Neglect(ref source, ref result, ComparisonType, trace);

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(Pattern right) {
			switch (right) {
			case ChainAlternator chain:
				return new ChainAlternator(this, chain.Patterns);
			default:
				return base.Alternate(right);
			}
		}

		#endregion
	}
}
