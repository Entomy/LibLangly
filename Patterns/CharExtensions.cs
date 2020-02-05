using System;
using Stringier.Patterns.Debugging;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	public static class CharExtensions {
		/// <summary>
		/// Get the <paramref name="char"/> as a <see cref="Pattern"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> literal.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="char"/>.</returns>
		public static Pattern AsPattern(this Char @char) => new CharLiteral(@char);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="String"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source) {
			Guard.NotNull(source, nameof(source));
			return Consume(pattern, source, null);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="String"/> to consume.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source, ITrace? trace) {
			Guard.NotNull(source, nameof(source));
			return pattern.Consume(source, Compare.CaseSensitive, trace);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source, Compare comparisonType) {
			Guard.NotNull(source, nameof(source));
			return Consume(pattern, source, comparisonType, null);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, String source, Compare comparisonType, ITrace? trace) {
			Guard.NotNull(source, nameof(source));
			Source src = new Source(source);
			return pattern.Consume(ref src, comparisonType, trace);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source) => pattern.Consume(ref source, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source, ITrace? trace) => pattern.Consume(ref source, Compare.CaseSensitive, trace);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source, Compare comparisonType) => Consume(pattern, ref source, comparisonType, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern"/> from the <paramref name="source"/>, adjusting the position in the <paramref name="source"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to match.</param>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string.</returns>
		public static Result Consume(this Char pattern, ref Source source, Compare comparisonType, ITrace? trace) {
			Result result = new Result(ref source);
			pattern.Consume(ref source, ref result, comparisonType, trace);
			return result;
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Char"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Or(this Char @char, Pattern other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Char"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Or(this Char @char, String other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check if this <see cref="Char"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Or(this Char @char, ReadOnlySpan<Char> other) => new CharLiteral(@char).Alternate(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Char"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Or(this Char @char, Char other) => new CharLiteral(@char).Alternate(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to check if this <see cref="Char"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Or(this Char @char, Capture other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Alternate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Marks this <see cref="Char"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeat(this Char @char, Int32 count) => new StringLiteral(StringierExtensions.Repeat(@char, count));

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Char"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Then(this Char @char, Pattern other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Char"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Then(this Char @char, String other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Char"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Then(this Char @char, ReadOnlySpan<Char> other) => new CharLiteral(@char).Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Char"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Then(this Char @char, Char other) => new CharLiteral(@char).Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Char"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Capture"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Char"/> and <paramref name="other"/></returns>
		public static Pattern Then(this Char @char, Capture other) {
			Guard.NotNull(other, nameof(other));
			return new CharLiteral(@char).Concatenate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Compare this <paramref name="pattern"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <returns>A new <see cref="Pattern"/> representing the <paramref name="pattern"/> compared with <paramref name="comparisonType"/>.</returns>
		public static Pattern With(this Char pattern, Compare comparisonType) => new CharLiteral(pattern, comparisonType);

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
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		internal static void Consume(this Char pattern, ref Source source, ref Result result) => pattern.Consume(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to consume the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to consume from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal static void Consume(this Char pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (source.Length == 0) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				Char Peek = source.Peek();
				if (pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error = Error.None;
				} else {
					result.Error = Error.ConsumeFailed;
					trace?.Collect(result.Error, source.Position);
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
			case Compare.NoPreference:
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
		internal static void Neglect(this Char pattern, ref Source source, ref Result result) => pattern.Neglect(ref source, ref result, Compare.CaseSensitive, null);

		/// <summary>
		/// Attempt to neglect the <paramref name="pattern" />, adjusting the <paramref name="source"/> and <paramref name="result"/> as appropriate.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> pattern.</param>
		/// <param name="source">The <see cref="Source"/> to neglect from.</param>
		/// <param name="result">The <see cref="Result"/> to store the result into.</param>
		/// <param name="comparisonType">Whether the comparison is sensitive to casing.</param>
		/// <param name="trace">The <see cref="ITrace"/> to record steps in.</param>
		internal static void Neglect(this Char pattern, ref Source source, ref Result result, Compare comparisonType, ITrace? trace) {
			if (source.Length == 0) {
				result.Error = Error.EndOfSource;
				trace?.Collect(result.Error, source.Position);
			} else {
				Char Peek = source.Peek();
				if (!pattern.Equals(Peek, comparisonType)) {
					trace?.Collect(Peek, source.Position);
					source.Position++;
					result.Length++;
					result.Error = Error.None;
				} else {
					result.Error = Error.NeglectFailed;
					trace?.Collect(result.Error, source.Position);
				}
			}
		}
	}
}
