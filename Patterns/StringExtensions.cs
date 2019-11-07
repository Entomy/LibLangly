using System;
using Stringier.Patterns.Errors;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public static class StringExtensions {
		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the first character of this <see cref="String"/>.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against</param>
		/// <returns><c>true</c> if this <paramref name="pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal static Boolean CheckHeader(this String pattern, ref Source source) => pattern[0].CheckHeader(ref source);

		/// <summary>
		/// Compare this <paramref name="pattern"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> pattern.</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to compare with.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="pattern"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this String pattern, StringComparison comparisonType) => new Pattern(new StringLiteral(pattern, comparisonType));

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, String source) => pattern.Consume(source, StringComparison.Ordinal);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use for pattern matching.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, String source, StringComparison comparisonType) {
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ReadOnlySpan<Char> source) => pattern.Consume(source, StringComparison.Ordinal);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use for pattern matching.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ReadOnlySpan<Char> source, StringComparison comparisonType) {
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source) => pattern.Consume(ref source, StringComparison.Ordinal);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="comparisonType">Whether comparison should be done with respect to casing; default is case-insensitive.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source, StringComparison comparisonType) {
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
		internal static void Consume(this String pattern, ref Source source, ref Result result) => pattern.Consume(ref source, ref result, StringComparison.Ordinal);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use when comparing.</param>
		internal static void Consume(this String pattern, ref Source source, ref Result result, StringComparison comparisonType) {
			if (pattern.Length > source.Length) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (pattern.Equals(Peek, comparisonType)) {
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.ConsumeFailed, pattern);
				}
			}
		}

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param
		internal static void Neglect(this String pattern, ref Source source, ref Result result) => pattern.Neglect(ref source, ref result, StringComparison.Ordinal);

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use when comparing.</param
		internal static void Neglect(this String pattern, ref Source source, ref Result result, StringComparison comparisonType) {
			if (pattern.Length > source.Length) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (!pattern.Equals(Peek, comparisonType)) {
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.NeglectFailed, pattern);
				}
			}
		}
	}
}
