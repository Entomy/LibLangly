namespace System.Text.Patterns {
	public class Pattern : IEquatable<String> {

		internal readonly Node Head;

		internal Pattern(Node Head) => this.Head = Head;

		public static implicit operator Pattern(String String) => new Pattern(new Literal(String));

		public static implicit operator Pattern((String String, StringComparison ComparisonType) Pattern) => new Pattern(new Literal(Pattern.String, Pattern.ComparisonType));

		public static explicit operator Pattern(Func<Char, Boolean> Check) => new Pattern(new Checker(Check));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, Pattern Right) => new Pattern(new Combinator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(Pattern Left, String Right) => new Pattern(new Combinator(Left, Right));

		/// <summary>
		/// Combine the two patterns, one after another
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator &(String Left, Pattern Right) => new Pattern(new Combinator(Left, Right));

		/// <summary>
		/// Repeats the pattern the specified number of times
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to repeat</param>
		/// <param name="Right">The number of repetitions</param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator *(Pattern Left, Int32 Right) => new Pattern(new Repeater(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Pattern Left, Pattern Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(Pattern Left, String Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Alternate the two patterns, accepting either
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Right"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator |(String Left, Pattern Right) => new Pattern(new Alternator(Left, Right));

		/// <summary>
		/// Makes the <paramref name="Pattern"/> span
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator +(Pattern Pattern) => new Pattern(new Spanner(Pattern));

		/// <summary>
		/// Makes the <paramref name="Pattern"/> optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Pattern operator ~(Pattern Pattern) => new Pattern(new Optor(Pattern));

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
		public Result Consume(ref Source Source) => Head.Consume(ref Source);

		public override Boolean Equals(Object obj) => Head.Equals(obj);

		public Boolean Equals(String other) => Head.Equals(other);

		public override Int32 GetHashCode() => Head.GetHashCode();

		public override String ToString() => Head.ToString();
	}
}