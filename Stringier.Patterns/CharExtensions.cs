namespace System.Text.Patterns {
	public static class CharExtensions {
		#region Alternator

		internal static Pattern Alternate(this Char Left, Pattern Right) {
			switch (Right) {
			case ChainAlternator chain:
				return new ChainAlternator(Left, chain.Patterns);
			default:
				return new Alternator(Left, Right);
			}
		}

		#endregion

		#region Concatenator

		internal static Pattern Concatenate(this Char Left, Pattern Right) => new Concatenator(Left, Right);

		#endregion

		internal static Boolean CheckHeader(this Char Pattern, ref Source Source) => Source.EOF ? false : Pattern.Equals(Source.Peek());

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, String Source) => Pattern.Consume(Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, ref Source Source) => Pattern.Consume(ref Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, ref Source Source, StringComparison ComparisonType) {
			Result Result = new Result(ref Source);
			Pattern.Consume(ref Source, ref Result, ComparisonType);
			return Result;
		}

		internal static void Consume(this Char Pattern, ref Source Source, ref Result Result) => Pattern.Consume(ref Source, ref Result, Stringier.DefaultComparisonType);

		internal static void Consume(this Char Pattern, ref Source Source, ref Result Result, StringComparison ComparisonType) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				if (Stringier.Equals(Pattern, Source.Peek(), ComparisonType)) {
					Source.Position++;
					Result.Length++;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.ConsumeFailed, Pattern);
				}
			}
		}

		internal static void Neglect(this Char Pattern, ref Source Source, ref Result Result) => Pattern.Neglect(ref Source, ref Result, Stringier.DefaultComparisonType);

		internal static void Neglect(this Char Pattern, ref Source Source, ref Result Result, StringComparison ComparisonType) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				if (!Stringier.Equals(Pattern, Source.Peek(), ComparisonType)) {
					Source.Position++;
					Result.Length++;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.NeglectFailed, Pattern);
				}
			}
		}

	}
}
