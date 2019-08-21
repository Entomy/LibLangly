namespace System.Text.Patterns {
	public static class CharExtensions {
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
			if (Source.Length == 0) { return new Result(); } //Prevents matching against sources shorter than the pattern.
			if (Stringier.Equals(Pattern, Source.Peek(), ComparisonType)) {
				return new Result(Source.Read(), true);
			} else {
				return new Result("", false);
			}
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to neglect</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this Char Pattern, String Source) => Pattern.Neglect(Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to neglect</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this Char Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Neglect(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to neglect</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this Char Pattern, ref Source Source) => Pattern.Neglect(ref Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="Char"/> to neglect</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this Char Pattern, ref Source Source, StringComparison ComparisonType) {
			if (Source.Length == 0) { return new Result(); } //Prevents matching against sources shorter than the pattern.
			if (!Stringier.Equals(Pattern, Source.Peek(), ComparisonType)) {
				return new Result(Source.Read(), true);
			} else {
				return new Result("", false);
			}
		}
	}
}
