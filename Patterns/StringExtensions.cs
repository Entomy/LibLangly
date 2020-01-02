using System;
using System.Runtime.CompilerServices;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Errors;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public static class StringExtensions {
		/// <summary>
		/// Get the <paramref name="string"/> as a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> literal.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="string"/>.</returns>
		public static Pattern AsPattern(this String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return new StringLiteral(@string);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, String source) => pattern.Consume(source, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="String"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, String source, Compare comparisonType) {
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ReadOnlySpan<Char> source) => pattern.Consume(source, Compare.CaseSensitive);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ReadOnlySpan<Char> source, Compare comparisonType) {
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source) => pattern.Consume(ref source, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source, ITrace? trace) => pattern.Consume(ref source, Compare.CaseSensitive, trace);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source, Compare comparisonType) => Consume(pattern, ref source, comparisonType, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to match</param>
		/// <param name="source">The <see cref="Source"/> to consume</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String pattern, ref Source source, Compare comparisonType, ITrace? trace) {
			Result Result = new Result(ref source);
			pattern.Consume(ref source, ref Result, comparisonType, trace);
			return Result;
		}


		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="String"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="String"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="String"/> and <paramref name="other"/></returns>
		public static Pattern Or(this String @string, Pattern other) {
			if (@string is null || other is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(other));
			}
			return new StringLiteral(@string).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="String"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="String"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="String"/> and <paramref name="other"/></returns>
		public static Pattern Or(this String @string, String other) {
			if (@string is null || other is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(other));
			}
			return new StringLiteral(@string).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="String"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="String"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="String"/> and <paramref name="other"/></returns>
		public static Pattern Or(this String @string, Char other) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return new StringLiteral(@string).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="String"/>.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to check if this <see cref="String"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="String"/> and <paramref name="other"/></returns>
		public static Pattern Or(this String @string, Capture other) {
			if (@string is null || other is null) {
				throw new ArgumentNullException(@string is null ? nameof(@string) : nameof(other));
			}
			return new StringLiteral(@string).Alternate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Marks this <see cref="String"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeat(this String @string, Int32 count) => new StringLiteral(StringierExtensions.Repeat(@string, count));

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public static Pattern Then(this String @string, Pattern other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			}
			return new StringLiteral(@string).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public static Pattern Then(this String @string, String other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			}
			return new StringLiteral(@string).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public static Pattern Then(this String @string, Char other) => new StringLiteral(@string).Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public static Pattern Then(this String @string, Capture other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			}
			return new StringLiteral(@string).Concatenate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Compare this <paramref name="pattern"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> pattern.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="pattern"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this String pattern, Compare comparisonType) => new StringLiteral(pattern, comparisonType);

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the first character of this <see cref="String"/>.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against</param>
		/// <returns><c>Compare.CaseSensitive</c> if this <paramref name="pattern"/> may be present, <c>false</c> if definately not.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean CheckHeader(this String pattern, ref Source source) => pattern[0].CheckHeader(ref source);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Consume(this String pattern, ref Source source, ref Result result) => pattern.Consume(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Consume(this String pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (pattern.Length > source.Length) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
				trace?.Collect(result.Error);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Position);
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.ConsumeFailed, pattern);
					trace?.Collect(result.Error);
				}
			}
		}

		/// <summary>
		/// Determines whether this instance and the specified <see cref="String"/> have the same value.
		/// </summary>
		/// <param name="string">This <see cref="String"/> instance.</param>
		/// <param name="other">The <see cref="String"/> to compare to this instance.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns><c>Compare.CaseSensitive</c> if the value of the <paramref name="other"/> parameter is the same as this string; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Equals(this String @string, String other, Compare comparisonType) {
			switch (comparisonType) {
			case Compare.NoPreference:
			case Compare.CaseSensitive:
				return @string.Equals(other, StringComparison.Ordinal);
			case Compare.CaseInsensitive:
				return @string.Equals(other, StringComparison.OrdinalIgnoreCase);
			default:
				throw new ArgumentException($"{comparisonType} not handled", nameof(comparisonType));
			}
		}

		/// <summary>
		/// Determines whether this instance and the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> have the same value.
		/// </summary>
		/// <param name="string">This <see cref="String"/> instance.</param>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns><c>Compare.CaseSensitive</c> if the value of the <paramref name="other"/> parameter is the same as this string; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Equals(this String @string, ReadOnlySpan<Char> other, Compare comparisonType) {
			switch (comparisonType) {
			case Compare.NoPreference:
			case Compare.CaseSensitive:
				return @string.Equals(other, StringComparison.Ordinal);
			case Compare.CaseInsensitive:
				return @string.Equals(other, StringComparison.OrdinalIgnoreCase);
			default:
				throw new ArgumentException($"{comparisonType} not handled", nameof(comparisonType));
			}
		}

		/// <summary>
		/// Determines whether this instance and the specified <see cref="String"/> have the same value.
		/// </summary>
		/// <param name="span">This <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="String"/> to compare to this instance.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns><c>Compare.CaseSensitive</c> if the value of the <paramref name="other"/> parameter is the same as this string; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Equals(this ReadOnlySpan<Char> span, String other, Compare comparisonType) {
			switch (comparisonType) {
			case Compare.NoPreference:
			case Compare.CaseSensitive:
				return span.Equals(other, StringComparison.Ordinal);
			case Compare.CaseInsensitive:
				return span.Equals(other, StringComparison.OrdinalIgnoreCase);
			default:
				throw new ArgumentException($"{comparisonType} not handled", nameof(comparisonType));
			}
		}

		/// <summary>
		/// Determines whether this instance and the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> have the same value.
		/// </summary>
		/// <param name="span">This <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns><c>Compare.CaseSensitive</c> if the value of the <paramref name="other"/> parameter is the same as this string; otherwise, <c>false</c>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Equals(this ReadOnlySpan<Char> span, ReadOnlySpan<Char> other, Compare comparisonType) {
			switch (comparisonType) {
			case Compare.NoPreference:
			case Compare.CaseSensitive:
				return span.Equals(other, StringComparison.Ordinal);
			case Compare.CaseInsensitive:
				return span.Equals(other, StringComparison.OrdinalIgnoreCase);
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
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Neglect(this String pattern, ref Source source, ref Result result) => pattern.Neglect(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Neglect(this String pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (pattern.Length > source.Length) {
				result.Error.Set(ErrorType.EndOfSource, pattern);
				trace?.Collect(result.Error);
			} else {
				ReadOnlySpan<Char> Peek = source.Peek(pattern.Length);
				if (!pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Length);
					source.Position += Peek.Length;
					result.Length += Peek.Length;
					result.Error.Clear();
				} else {
					result.Error.Set(ErrorType.NeglectFailed, pattern);
					trace?.Collect(result.Error);
				}
			}
		}
	}
}
