using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> who's content can span. That is, as long as it is present once, can repeat multiple times past that point.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Spanner : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Spanner"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal Spanner(Pattern pattern) => Pattern = pattern;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Patterns.Pattern"/> may be present, <c>false</c> if definately not.</
		internal override Boolean CheckHeader(ref Source source) => Pattern.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			//Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 OriginalPosition = source.Position;
			Int32 OriginalLength = result.Length;
			//We need to confirm the pattern exists at least once
			Pattern.Consume(ref source, ref result, trace);
			if (!result) {
				//Backtrack
				source.Position = OriginalPosition;
				result.Length = OriginalLength;
				return;
			}
			//Now continue to consume as much as possible
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
			result.Error = Error.None; //As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			//We need to confirm the pattern exists at least once
			Pattern.Neglect(ref source, ref result, trace);
			if (!result) {
				return;
			}
			//Now continue to consume as much as possible
			while (result) {
				Pattern.Neglect(ref source, ref result, trace);
			}
			result.Error = Error.None; //As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		#region Optor

		/// <summary>
		/// Marks this <see cref="Patterns.Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Patterns.Pattern"/> which is optional.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Patterns.Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal override Pattern Optional() => new KleenesClosure(Pattern);

		#endregion

		#region Spanner

		/// <summary>
		/// Marks this <see cref="Patterns.Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Patterns.Pattern"/> which is spanning.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Patterns.Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks
		internal override Pattern Span() => this;

		#endregion
	}
}
