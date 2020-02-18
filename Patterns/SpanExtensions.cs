using System;
using System.Runtime.CompilerServices;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	public static class SpanExtensions {
		/// <summary>
		/// Get the <paramref name="span"/> as a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="span"/>.</returns>
		public static Pattern AsPattern(this ReadOnlySpan<Char> span) => new StringLiteral(span);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, String source) {
			Guard.NotNull(source, nameof(source));
			return pattern.Consume(source, Compare.CaseSensitive);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, String source, Compare comparisonType) {
			Guard.NotNull(source, nameof(source));
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ReadOnlySpan<Char> source) => pattern.Consume(source, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ReadOnlySpan<Char> source, Compare comparisonType) {
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ref Source source) => pattern.Consume(ref source, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ref Source source, ITrace? trace) => pattern.Consume(ref source, Compare.CaseSensitive, trace);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ref Source source, Compare comparisonType) => Consume(pattern, ref source, comparisonType, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this ReadOnlySpan<Char> pattern, ref Source source, Compare comparisonType, ITrace? trace) {
			Result Result = new Result(ref source);
			pattern.Consume(ref source, ref Result, comparisonType, trace);
			return Result;
		}

		/// <summary>
		/// Compare this <paramref name="pattern"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> pattern.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="pattern"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this ReadOnlySpan<Char> pattern, Compare comparisonType) => new StringLiteral(pattern, comparisonType);

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the first character of this <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against</param>
		/// <returns><c>Compare.CaseSensitive</c> if this <paramref name="pattern"/> may be present, <c>false</c> if definately not.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean CheckHeader(this ReadOnlySpan<Char> pattern, ref Source source) => pattern[0].CheckHeader(ref source);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Consume(this ReadOnlySpan<Char> pattern, ref Source source, ref Result result) => pattern.Consume(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Consume(this ReadOnlySpan<Char> pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (pattern.Length > source.Length) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Position);
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error = Error.None;
				} else {
					result.Error = Error.ConsumeFailed;
					trace?.Collect(result.Error, source.Position);
				}
			}
		}

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Neglect(this ReadOnlySpan<Char> pattern, ref Source source, ref Result result) => pattern.Neglect(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Neglect(this ReadOnlySpan<Char> pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (pattern.Length > source.Length) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (!pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Length);
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error = Error.None;
				} else {
					result.Error = Error.NeglectFailed;
					trace?.Collect(result.Error, source.Position);
				}
			}
		}
	}
}
