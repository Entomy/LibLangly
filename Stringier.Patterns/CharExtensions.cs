namespace System.Text.Patterns {
	public static class CharExtensions {
		internal static Boolean CheckHeader(this Char Pattern, ref Source Source) => !Source.EOF && Pattern.Equals(Source.Peek());

		public static Pattern CaseSensitive(this Char Pattern) => new Pattern(new CharLiteral(Pattern, true));

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, String Source) {
			if (Source is null) {
				throw new ArgumentNullException(nameof(Source));
			}
			return Pattern.Consume(Source, true);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, String Source, Boolean CaseSensitive) {
			if (Source is null) {
				throw new ArgumentNullException(nameof(Source));
			}
			Source source = new Source(Source);
			return Pattern.Consume(ref source, CaseSensitive);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, ref Source Source) => Pattern.Consume(ref Source, true);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this Char Pattern, ref Source Source, Boolean CaseSensitive) {
			Result Result = new Result(ref Source);
			Pattern.Consume(ref Source, ref Result, CaseSensitive);
			return Result;
		}

		internal static void Consume(this Char Pattern, ref Source Source, ref Result Result) => Pattern.Consume(ref Source, ref Result, true);

		internal static void Consume(this Char Pattern, ref Source Source, ref Result Result, Boolean CaseSensitive) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				if (Stringier.Equals(Pattern, Source.Peek(), CaseSensitive)) {
					Source.Position++;
					Result.Length++;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.ConsumeFailed, Pattern);
				}
			}
		}

		internal static void Neglect(this Char Pattern, ref Source Source, ref Result Result) => Pattern.Neglect(ref Source, ref Result, true);

		internal static void Neglect(this Char Pattern, ref Source Source, ref Result Result, Boolean CaseSensitive) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, Pattern);
			} else {
				if (!Stringier.Equals(Pattern, Source.Peek(), CaseSensitive)) {
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
