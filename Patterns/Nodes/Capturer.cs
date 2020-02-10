using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a capturer <see cref="Patterns.Pattern"/>. That is, a <see cref="Patterns.Pattern"/> which captures its match into a <see cref="Patterns.Capture"/>.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Capturer : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed and captured.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// The <see cref="Patterns.Capture"/> object to capture into.
		/// </summary>
		private readonly Capture CapStore = new Capture();

		/// <summary>
		/// Initialize a new <see cref="Capturer"/> of the given <paramref name="pattern"/>, to be captured into <paramref name="capture"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed and captured.</param>
		/// <param name="capture">The <see cref="Patterns.Capture"/> object to capture into.</param>
		internal Capturer(Pattern pattern, out Capture capture) {
			Pattern = pattern;
			capture = CapStore;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><see langword="true"/> if this <see cref="Patterns.Pattern"/> may be present, <see langword="false"/> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Pattern.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			Int32 originalPosition = source.Position;
			Pattern.Consume(ref source, ref result, trace);
			CapStore.Value = source.Substring(originalPosition, source.Position - originalPosition).ToString();
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			Int32 originalPosition = source.Position;
			Pattern.Neglect(ref source, ref result, trace);
			CapStore.Value = source.Substring(originalPosition, source.Position - originalPosition).ToString();
		}
	}
}
