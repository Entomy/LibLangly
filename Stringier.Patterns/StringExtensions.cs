namespace System.Text.Patterns {
	public static class StringExtensions {
		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source) => Pattern.Consume(Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Consume(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source) => Pattern.Consume(ref Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Consume(this String Pattern, ref Source Source, StringComparison ComparisonType) {
			if (Pattern.Length > Source.Length) { return new Result(); } //Prevents matching against sources shorter than the pattern.
			ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
			if (Stringier.Equals(Pattern, Peek.ToString(), ComparisonType)) {
				Source.Position += Peek.Length;
				return new Result(Peek, true);
			} else {
				return new Result("", false);
			}
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to neglect</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this String Pattern, String Source) => Pattern.Neglect(Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to neglect</param>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this String Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Neglect(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to neglect</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this String Pattern, ref Source Source) => Pattern.Neglect(ref Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <paramref name="Pattern"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to neglect</param>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public static Result Neglect(this String Pattern, ref Source Source, StringComparison ComparisonType) {
			if (Pattern.Length > Source.Length) { return new Result(); } //Prevents matching against sources shorter than the pattern.
			ReadOnlySpan<Char> Peek = Source.Peek(Pattern.Length);
			if (!Stringier.Equals(Pattern, Peek.ToString(), ComparisonType)) {
				Source.Position += Peek.Length;
				return new Result(Peek, true);
			} else {
				return new Result("", false);
			}
		}

		/// <summary>
		/// Attempt to span the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to span</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the spanned string</returns>
		public static Result Span(this String Pattern, String Source) => Pattern.Span(Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to span the <paramref name="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="String"/> to span</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the spanned string</returns>
		public static Result Span(this String Pattern, String Source, StringComparison ComparisonType) {
			Source source = new Source(Source);
			return Pattern.Span(ref source, ComparisonType);
		}

		/// <summary>
		/// Attempt to span the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to span</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the spanned string</returns>
		public static Result Span(this String Pattern, ref Source Source) => Pattern.Span(ref Source, StringComparison.CurrentCulture);

		/// <summary>
		/// Attempt to span the <paramref name="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Source">The <see cref="Source"/> to span</param>
		/// <param name="ComparisonType">The <see cref="StringComparison"/> to use for pattern matching</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the spanned string</returns>
		public static Result Span(this String Pattern, ref Source Source, StringComparison ComparisonType) {
			if ((Pattern.Length == 0) //Prevents infinite loops for null patterns
			|| (Pattern.Length > Source.Length)) //Prevents matching against sources shorter than the patterns
			{
				return new Result("", true);
			}
			Int32 OriginalPosition = Source.Position;
			ReadOnlySpan<Char> Peek;
			// We're going to manually break out of this loop
			while (true) {
				Peek = Source.Peek(Pattern.Length);
				if (Stringier.Equals(Pattern, Peek.ToString(), ComparisonType)) {
					Source.Position += Peek.Length;
				} else {
					goto Done;
				}
			}
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), true);
		}

	}
}
