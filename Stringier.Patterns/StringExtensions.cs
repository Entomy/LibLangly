namespace System.Text.Patterns {
	public static class StringExtensions {
		#region Alternator

		internal static Pattern Alternate(this String Left, Pattern Right) => new Alternator(Left, Right);

		#endregion

		#region Concatenator

		internal static Pattern Concatenate(this String Left, Pattern Right) => new Concatenator(Left, Right);

		#endregion

		internal static Boolean CheckHeader(this String Pattern, ref Source Source) => Pattern[0].CheckHeader(ref Source);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source) => Pattern.Consume(Source, Stringier.DefaultComparisonType);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ReadOnlySpan<Char> Source) => Pattern.Consume(Source, Stringier.DefaultComparisonType);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ReadOnlySpan<Char> Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source) => Pattern.Consume(ref Source, Stringier.DefaultComparisonType);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source, StringComparison ComparisonType) {
			Result Result = new Result(ref Source);
			Pattern.Consume(ref Source, ref Result, ComparisonType);
			return Result;
		}

		internal static void Consume(this String Pattern, ref Source Source, ref Result Result) => Pattern.Consume(ref Source, ref Result, Stringier.DefaultComparisonType);

		internal static void Consume(this String Pattern, ref Source Source, ref Result Result, StringComparison ComparisonType) {
			if (Pattern.Length > Source.Length) {
				Result.Error = new EndOfSourceError(Expected: Pattern);
			} else {
				ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
				if (Stringier.Equals(Pattern, Peek, ComparisonType)) {
					Source.Position += Peek.Length;
					Result.Length += Peek.Length;
					Result.Error = null;
				} else {
					Result.Error = new ConsumeFailedError(Expected: Pattern);
				}
			}
		}

		internal static void Neglect(this String Pattern, ref Source Source, ref Result Result) => Pattern.Neglect(ref Source, ref Result, Stringier.DefaultComparisonType);

		internal static void Neglect(this String Pattern, ref Source Source, ref Result Result, StringComparison ComparisonType) {
			if (Pattern.Length > Source.Length) {
				Result.Error = new EndOfSourceError(Expected: Pattern);
			} else {
				ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
				if (!Stringier.Equals(Pattern, Peek, ComparisonType)) {
					Source.Position += Peek.Length;
					Result.Length += Peek.Length;
					Result.Error = null;
				} else {
					Result.Error = new NeglectFailedError(Neglected: Pattern);
				}
			}
		}
	}
}
