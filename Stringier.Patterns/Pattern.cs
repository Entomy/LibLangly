namespace System.Text.Patterns {
	public abstract class Pattern : IEquatable<String> {
		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Combinator operator &(Pattern Left, Pattern Right) => new Combinator(Left, Right);

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Combinator operator &(Pattern Left, String Right) => new Combinator(Left, (Literal)Right);

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Combinator operator &(String Left, Pattern Right) => new Combinator((Literal)Left, Right);

		/// <summary>
		/// Repeats the pattern the specified number of times
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to repeat</param>
		/// <param name="Right">The number of repetitions</param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Repeater operator *(Pattern Left, Int32 Right) => new Repeater(Left, Right);

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Alternator operator |(Pattern Left, Pattern Right) => new Alternator(Left, Right);

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Alternator operator |(Pattern Left, String Right) => new Alternator(Left, (Literal)Right);

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Alternator operator |(String Left, Pattern Right) => new Alternator((Literal)Left, Right);

		/// <summary>
		/// Makes the <paramref name="Pattern"/> span
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Spanner operator +(Pattern Pattern) => new Spanner(Pattern);

		/// <summary>
		/// Makes the <paramref name="Pattern"/> optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Optor operator ~(Pattern Pattern) => new Optor(Pattern);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public abstract Result Consume(ref Source Source);

		public abstract override Boolean Equals(Object obj);

		public abstract Boolean Equals(String other);

		public abstract override Int32 GetHashCode();

		public abstract override String ToString();
	}
}