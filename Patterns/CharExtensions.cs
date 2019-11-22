using System;
using Stringier.Patterns.Errors;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public static class CharExtensions {
		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against this character.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against</param>
		/// <returns><c>Compare.CaseSensitive</c> if this <paramref name="pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal static Boolean CheckHeader(this Char pattern, ref Source source) => !source.EOF && pattern.Equals(source.Peek());

		/// <summary>
		/// Compare this <paramref name="pattern"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="pattern"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this Char pattern, Compare comparisonType) => new Pattern(new CharLiteral(pattern, comparisonType));

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="String"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source) {
			if (source is null) {
				throw new ArgumentNullException(nameof(source));
			}
			return pattern.Consume(source, Compare.CaseSensitive);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source, Compare comparisonType) {
			if (source is null) {
				throw new ArgumentNullException(nameof(source));
			}
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source) => pattern.Consume(ref source, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source, Compare comparisonType) {
			Result Result = new Result(ref source);
			pattern.Consume(ref source, ref Result, comparisonType);
			return Result;
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		internal static void Consume(this Char pattern, ref Source source, ref Result result) => pattern.Consume(ref source, ref result, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		internal static void Consume(this Char pattern, ref Source source, ref Result result, Compare comparisonType) {
			if (source.Length == 0) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
			} else {
				if (pattern.Equals(source.Peek(), comparisonType)) {
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.ConsumeFailed, pattern);
				}
			}
		}

		/// <summary>
		/// Determines whether this instance and the specified <see cref="Char"/> have the same value.
		/// </summary>
		/// <param name="char">This <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns><c>Compare.CaseSensitive</c> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <c>false</c>.</returns>
		internal static Boolean Equals(this Char @char, Char other, Compare comparisonType) {
			switch (comparisonType) {
			case Compare.CaseSensitive:
				return @char.Equals(other, StringComparison.Ordinal);
			case Compare.CaseInsensitive:
				return @char.Equals(other, StringComparison.OrdinalIgnoreCase);
			default:
				throw new ArgumentException($"{comparisonType} not handled", nameof(comparisonType));
			}
		}

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		internal static void Neglect(this Char pattern, ref Source source, ref Result result) => pattern.Neglect(ref source, ref result, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		internal static void Neglect(this Char pattern, ref Source source, ref Result result, Compare comparisonType) {
			if (source.Length == 0) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
			} else {
				if (!pattern.Equals(source.Peek(), comparisonType)) {
					source.Position++;
					result.Length++;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.NeglectFailed, pattern);
				}
			}
		}
	}
}
