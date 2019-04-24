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

		/// <summary>
		/// Combine two literals into another literal
		/// </summary>
		/// <param name="Left">The first <see cref="Literal"/></param>
		/// <param name="Right">The second <see cref="Literal"/></param>
		/// <returns>A new <see cref="Literal"/> combining <paramref name="Left"/> and <paramref name="Right"/></returns>
		public static Literal operator &(Literal Left, Literal Right) => new Literal(Left.String + Right.String);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <param name="Consumed">The <see cref="String"/> that was consumed, empty if not matched</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate, out String Capture) => String.Consume(Candidate, out Capture);

		public override Boolean Equals(String other) => String.Equals(String, other, StringComparison.InvariantCulture);

		public Boolean Equals(Literal other) => String.Equals(other.String, StringComparison.InvariantCulture);

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
