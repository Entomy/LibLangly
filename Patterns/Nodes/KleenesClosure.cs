using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the Kleene's Closure (Kleene Star), who's content is optional and may repeat.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal class KleenesClosure : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="KleenesClosure"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal KleenesClosure(Pattern pattern) => Pattern = pattern;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Patterns.Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Pattern.CheckHeader(ref source); //This isn't supposed to work like an Kleene's Closure normally, as it's a performance optimization, not a parser

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			//Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 OriginalPosition;
			Int32 OriginalLength;
			//Consume as much as possible
			while (result) {
				//Update the positions so we can backtrack this unit
				OriginalPosition = source.Position;
				OriginalLength = result.Length;
				//Try consuming
				Pattern.Consume(ref source, ref result, trace);
				if (!result) {
					//Before we break out, backtrack
					source.Position = OriginalPosition;
					result.Length = OriginalLength;
				}
			}
			result.Error = Error.None; //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			//Consume as much as possible
			while (result) {
				Pattern.Neglect(ref source, ref result, trace);
			}
			result.Error = Error.None; //As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}
	}
}
