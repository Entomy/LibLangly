namespace System.Text.Patterns {
	/// <summary>
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	public sealed class Literal : Pattern, IEquatable<Literal> {
		private readonly String String = "";

		internal Literal(String String) => this.String = String;

		public static implicit operator Literal(String String) => new Literal(String);

		public static Literal operator &(Literal Left, Literal Right) => new Literal(Left.String + Right.String);

		public override Result Consume(String Candidate) => String.Consume(Candidate);

		public override Boolean Equals(String Other) => String.Equals(String, Other);

		public Boolean Equals(Literal Other) => String.Equals(Other.String);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Literal Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Int32 GetHashCode() => String.GetHashCode();

		public override String ToString() => String;
	}
}
