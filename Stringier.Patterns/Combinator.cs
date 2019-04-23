namespace System.Text.Patterns {
	/// <summary>
	/// Represents a combinator pattern
	/// </summary>
	public sealed class Combinator : Pattern, IEquatable<Combinator> {

		private readonly Pattern Left;

		private readonly Pattern Right;

		internal Combinator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		public override Result Consume(Result Candidate) => Right.Consume(Left.Consume(Candidate));

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Combinator Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => String.Equals(Left.Consume(other), Right);

		public Boolean Equals(Combinator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public override String ToString() => Left.ToString() + Right.ToString();
	}
}
