using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>	
	/// Represents a string literal pattern, a pattern matching this exact string.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class StringLiteral : Literal {
		/// <summary>
		/// The actual <see cref="System.String"/> being matched.
		/// </summary>
		internal readonly String String = "";

		/// <summary>
		/// Initialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		internal StringLiteral(String @string) : base(Compare.NoPreference) => String = @string;

		/// <summary>
		/// Intialize a new <see cref="StringLiteral"/> with the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="System.String"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		internal StringLiteral(String @string, Compare comparisonType) : base(comparisonType) => String = @string;

		/// <summary>
		/// Initialize a new <see cref="StringLiteral"/> with the given <paramref name="span"/>.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to parse.</param>
		internal StringLiteral(ReadOnlySpan<Char> span) : base(Compare.NoPreference) => String = span.ToString();

		/// <summary>
		/// Intialize a new <see cref="StringLiteral"/> with the given <paramref name="span"/>.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		internal StringLiteral(ReadOnlySpan<Char> span, Compare comparisonType) : base(comparisonType) => String = span.ToString();

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => String.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) => String.Consume(ref source, ref result, ComparisonType, trace);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="System.String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) => String.Neglect(ref source, ref result, ComparisonType, trace);

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

		#region Concatenator

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Pattern right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			switch (right) {
			case StringLiteral @string:
				if (ComparisonType.Equals(@string.ComparisonType)) {
					return new StringLiteral(String + @string.String, ComparisonType);
				} else {
					goto default;
				}
			case CharLiteral @char:
				if (ComparisonType.Equals(@char.ComparisonType)) {
					return new StringLiteral(String + @char.Char, ComparisonType);
				} else {
					goto default;
				}
			default:
				return base.Concatenate(right);
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Concatenate(Char right) {
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(String + right.ToString());
			default:
				return new Concatenator(this, new CharLiteral(right));
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="System.String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="System.String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal override Pattern Concatenate(String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			switch (ComparisonType) {
			case Compare.NoPreference:
				return new StringLiteral(String + right);
			default:
				return new Concatenator(this, new StringLiteral(right));
			}
		}

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 count) => new StringLiteral(StringierExtensions.Repeat(String, count), ComparisonType);

		#endregion
	}
}