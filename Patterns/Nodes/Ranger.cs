using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Ranger"/>, a "range" of text between two <see cref="Pattern"/>.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal class Ranger : Combinator {
		/// <summary>
		/// The <see cref="Pattern"/> to start from.
		/// </summary>
		internal protected readonly Pattern From;

		/// <summary>
		/// The <see cref="Pattern"/> to read to.
		/// </summary>
		internal protected readonly Pattern To;

		/// <summary>
		/// Initialize a new <see cref="Ranger"/> with the given <paramref name="from"/> and <paramref name="to"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal protected Ranger(Pattern from, Pattern to) {
			From = from;
			To = to;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => From.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			From.Consume(ref source, ref result, trace);
			if (!result) {
				result.Error = Error.ConsumeFailed;
				return;
			}
			To.Consume(ref source, ref result, trace);
			while (!result) {
				if (source.EOF) {
					break; 
				}
				source.Position++;
				result.Length++;
				if (To.CheckHeader(ref source)) {
					To.Consume(ref source, ref result, trace);
				}
			}
			if (!result) {
				result.Error = Error.EndOfSource;
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => throw new NotSupportedException();

		#region Negator

		/// <summary>
		/// Negates this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		internal override Pattern Negate() => throw new PatternConstructionException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		#endregion
	}
}
