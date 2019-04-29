namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	public sealed class Literal : Pattern, IEquatable<Literal> {
		private readonly String String = "";

		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = StringComparison.CurrentCulture;

		internal Literal(String String) : this(String, StringComparison.CurrentCulture) { }

		internal Literal(String String, StringComparison ComparisonType) {
			this.String = String;
			this.ComparisonType = ComparisonType;
		}

		public static implicit operator Literal(String String) => new Literal(String);

		public static implicit operator Literal((String String, StringComparison ComparisonType) Pattern) => new Literal(Pattern.String, Pattern.ComparisonType);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <param name="Capture">The <see cref="String"/> that was consumed, empty if not matched</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate, out String Capture) => String.Consume(Candidate, ComparisonType, out Capture);

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
