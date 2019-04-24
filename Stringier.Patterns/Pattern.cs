namespace System.Text.Patterns {
	public abstract class Pattern : IEquatable<String> {
		/// <summary>
		/// All control characters
		/// </summary>
		public static readonly Pattern ControlCharacter = (Literal)"\u0000" | "\u0001" | "\u0002" | "\u0003" | "\u0004" | "\u0005" | "\u0006" | "\u0007" | "\u0008" | "\u0009" | "\u000A" | "\u000B" | "\u000C" | "\u000D" | "\u000E" | "\u000F" | "\u0010" | "\u0011" | "\u0012" | "\u0013" | "\u0014" | "\u0015" | "\u0016" | "\u0017" | "\u0018" | "\u0019" | "\u001A" | "\u001B" | "\u001C" | "\u001D" | "\u001D" | "\u001F" | "\u007F" | "\u0080" | "\u0081" | "\u0082" | "\u0083" | "\u0084" | "\u0085" | "\u0086" | "\u0087" | "\u0088" | "\u0089" | "\u008A" | "\u008B" | "\u008C" | "\u008D" | "\u008E" | "\u008F" | "\u0090" | "\u0091" | "\u0092" | "\u0093" | "\u0094" | "\u0095" | "\u0096" | "\u0097" | "\u0098" | "\u0099" | "\u009A" | "\u009B" | "\u009C" | "\u009D" | "\u009E" | "\u009F";

		/// <summary>
		/// All line separator characters
		/// </summary>
		public static readonly Pattern LineSeparator = (Literal)"\u2028";

		/// <summary>
		/// All paragraph separator characters
		/// </summary>
		public static readonly Pattern ParagraphSeparator = (Literal)"\u2029";

		/// <summary>
		/// All space separator characters
		/// </summary>
		public static readonly Pattern SpaceSeparator = (Literal)"\u0020" | "\u00A0" | "\u1680" | "\u2000" | "\u2001" | "\u2002" | "\u2003" | "\u2004" | "\u2005" | "\u2006" | "\u2007" | "\u2008" | "\u2009" | "\u200A" | "\u202F" | "\u205F" | "\u3000";

		/// <summary>
		/// All whitespace characters
		/// </summary>
		//TODO: This should include format characters as well
		public static readonly Pattern Whitespace = ControlCharacter | LineSeparator | ParagraphSeparator | SpaceSeparator;

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
		/// Makes the <paramref name="Pattern"/> optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns>The new <see cref="Pattern"/></returns>
		public static Optor operator ~(Pattern Pattern) => new Optor(Pattern);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public abstract Result Consume(Result Candidate);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <param name="Capture">The <see cref="String"/> that was consumed, empty if not matched</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public abstract Result Consume(Result Candidate, out String Capture);

		public abstract override Boolean Equals(Object obj);

		public abstract Boolean Equals(String other);

		public abstract override Int32 GetHashCode();

		public Spanner Span() => new Spanner(this);

		public abstract override String ToString();
	}
}