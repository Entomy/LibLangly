using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Patterns.Pattern"/> whos content is optional.
	/// </summary>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class Optor : Modifier {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> to be parsed.
		/// </summary>
		private readonly Pattern Pattern;

		/// <summary>
		/// Intialize a new <see cref="Optor"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Pattern"/> to be parsed.</param>
		internal Optor(Pattern pattern) => Pattern = pattern;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Patterns.Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Pattern.CheckHeader(ref source); //This isn't supposed to work like an optor normally, as it's a performance optimization, not a parser

		/// <summary>
		/// Call the Consume parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			Pattern.Consume(ref source, ref result, trace);
			result.Error = Error.None; //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Patterns.Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			Pattern.Neglect(ref source, ref result, trace);
			result.Error = Error.None; //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		#region Optor

		/// <summary>
		/// Marks this <see cref="Patterns.Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Patterns.Pattern"/> which is optional.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Patterns.Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal override Pattern Optional() => this;

		#endregion

		#region Spanner

		internal override Pattern Span() => throw new PatternConstructionException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		#endregion
	}
}
