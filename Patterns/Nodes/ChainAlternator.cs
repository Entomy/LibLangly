using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the alternation of more than two <see cref="Pattern"/>. That is, one of many <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization around cases of alternating alternators; there's much less indirection and other issues when flattening that portion of the graph. It also causes better syntax when written to a string.
	/// </remarks>
	[SuppressMessage("Minor Bug", "S1206:\"Equals(Object)\" and \"GetHashCode()\" should be overridden in pairs", Justification = "It already is overriden, Sonar just doesn't understand this pattern.")]
	internal sealed class ChainAlternator : Combinator {
		/// <summary>
		/// The possible <see cref="Pattern"/> matches.
		/// </summary>
		internal readonly Pattern[] Patterns;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="patterns"/>.
		/// </summary>
		/// <param name="patterns">The possible <see cref="Pattern"/> matches.</param>
		internal ChainAlternator(params Pattern[] patterns) => Patterns = patterns;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstPattern"/> and <paramref name="otherPatterns"/>.
		/// </summary>
		/// <param name="firstPattern">The very first <see cref="Pattern"/> to check.</param>
		/// <param name="otherPatterns">The other possible <see cref="Pattern"/> matches.</param>
		internal ChainAlternator(Pattern firstPattern, Pattern[] otherPatterns) {
			Patterns = new Pattern[otherPatterns.Length + 1];
			Patterns[0] = firstPattern;
			otherPatterns.CopyTo(Patterns, 1);
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="otherPatterns"/> and <paramref name="lastPattern"/>.
		/// </summary>
		/// <param name="otherPatterns">All but the very last possible <see cref="Pattern"/> to check.</param>
		/// <param name="lastPattern">The very last <see cref="Pattern"/> to check.</param>
		internal ChainAlternator(Pattern[] otherPatterns, Pattern lastPattern) {
			Patterns = new Pattern[otherPatterns.Length + 1];
			otherPatterns.CopyTo(Patterns, 0);
			Patterns[Patterns.Length - 1] = lastPattern;
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstPatterns"/> and <paramref name="lastPatterns"/>.
		/// </summary>
		/// <param name="firstPatterns">The first set of <see cref="Pattern"/> to check.</param>
		/// <param name="lastPatterns">The last set of <see cref="Pattern"/> to check.</param>
		internal ChainAlternator(Pattern[] firstPatterns, Pattern[] lastPatterns) {
			Patterns = new Pattern[firstPatterns.Length + lastPatterns.Length];
			firstPatterns.CopyTo(Patterns, 0);
			lastPatterns.CopyTo(Patterns, firstPatterns.Length);
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><see langword="true"/> if this <see cref="Pattern"/> may be present, <see langword="false"/> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern.CheckHeader(ref source)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Call the Consume parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Consume(ref Source source, ref Result result, ITrace? trace) {
			foreach (Pattern Pattern in Patterns) {
				Pattern.Consume(ref source, ref result, trace);
				if (result) {
					return;
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Pattern"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal override void Neglect(ref Source source, ref Result result, ITrace? trace) {
			Int32 OriginalPosition = source.Position;
			Int32 OriginalLength = result.Length;
			Int32 ShortestPattern = Int32.MaxValue;
			for (Int32 i = Patterns.Length - 1; i >= 0; i--) {
				Patterns[i].Neglect(ref source, ref result, trace);
				if (result.Length < ShortestPattern) {
					ShortestPattern = result.Length - OriginalLength;
				}
				if (result) {
					source.Position = OriginalPosition;
					result.Length = OriginalLength;
				} else {
					break;
				}
			}
			source.Position += ShortestPattern;
			result.Length += ShortestPattern;
		}

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(Char right) => new ChainAlternator(Patterns, new CharLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(String right) => new ChainAlternator(Patterns, new StringLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal override Pattern Alternate(Pattern right) {
			switch (right) {
			case ChainAlternator chain:
				return new ChainAlternator(Patterns, chain.Patterns);
			default:
				return base.Alternate(right);
			}
		}

		#endregion

		#region Spanner

		/// <summary>
		/// Makes this <see cref="Pattern"/> spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which spans.</returns>
		internal override Pattern Span() {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern is Optor) {
					throw new PatternConstructionException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error.");
				}
			}
			return base.Span();
		}

		#endregion
	}
}
