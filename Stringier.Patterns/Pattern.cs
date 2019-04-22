namespace System.Text.Patterns {
	public abstract class Pattern : IEquatable<String> {

		public static Combinator operator &(Pattern Left, Pattern Right) => new Combinator(Left, Right);

		public static Combinator operator &(Pattern Left, String Right) => new Combinator(Left, (Literal)Right);

		public static Combinator operator &(String Left, Pattern Right) => new Combinator((Literal)Left, Right);

		public static Alternator operator |(Pattern Left, Pattern Right) => new Alternator(Left, Right);

		public static Alternator operator |(Pattern Left, String Right) => new Alternator(Left, (Literal)Right);

		public static Alternator operator |(String Left, Pattern Right) => new Alternator((Literal)Left, Right);

		public static Repeater operator *(Pattern Left, Int32 Right) => new Repeater(Left, Right);

		public abstract Result Consume(String Candidate);

		public abstract override Boolean Equals(Object obj);

		public abstract Boolean Equals(String Other);

		public abstract override Int32 GetHashCode();

		public abstract override String ToString();
	}
}