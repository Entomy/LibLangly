namespace System.Text.Patterns {
	public static class StringExtensions {
		internal static Boolean CheckHeader(this String Pattern, ref Source Source) => Pattern[0].CheckHeader(ref Source);

		public static Pattern CaseSensitive(this String Pattern) => new Pattern(new StringLiteral(Pattern, true));

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source) => Pattern.Consume(Source, true);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <param name="CaseSensitive">Whether comparison should be done with respect to casing; default is case-insensitive.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source, Boolean CaseSensitive) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, CaseSensitive);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ReadOnlySpan<Char> Source) => Pattern.Consume(Source, true);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="ReadOnlySpan<Char>"/> to consume</param>
		/// <param name="CaseSensitive">Whether comparison should be done with respect to casing; default is case-insensitive.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ReadOnlySpan<Char> Source, Boolean CaseSensitive) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, CaseSensitive);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source) => Pattern.Consume(ref Source, true);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="CaseSensitive">Whether comparison should be done with respect to casing; default is case-insensitive.</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source, Boolean CaseSensitive) {
			Result Result = new Result(ref Source);
			Pattern.Consume(ref Source, ref Result, CaseSensitive);
			return Result;
		}

		internal static void Consume(this String Pattern, ref Source Source, ref Result Result) => Pattern.Consume(ref Source, ref Result, true);

		internal static void Consume(this String Pattern, ref Source Source, ref Result Result, Boolean CaseSensitive) {
			if (Pattern.Length > Source.Length) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
				if (Stringier.Equals(Pattern, Peek, CaseSensitive)) {
					Source.Position += Peek.Length;
					Result.Length += Peek.Length;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.ConsumeFailed, Pattern);
				}
			}
		}

		internal static void Neglect(this String Pattern, ref Source Source, ref Result Result) => Pattern.Neglect(ref Source, ref Result, true);

		internal static void Neglect(this String Pattern, ref Source Source, ref Result Result, Boolean CaseSensitive) {
			if (Pattern.Length > Source.Length) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
				if (!Stringier.Equals(Pattern, Peek, CaseSensitive)) {
					Source.Position += Peek.Length;
					Result.Length += Peek.Length;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.NeglectFailed, Pattern);
				}
			}
		}
	}
}
