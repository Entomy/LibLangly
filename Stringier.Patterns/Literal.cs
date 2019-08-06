namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class Literal : Node, IEquatable<Literal> {
		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = StringComparison.CurrentCulture;

		private readonly String String = "";

		internal Literal(String String) : this(String, StringComparison.CurrentCulture) { }

		internal Literal(String String, StringComparison ComparisonType) {
			this.String = String;
			this.ComparisonType = ComparisonType;
		}

		public static implicit operator Literal(String String) => new Literal(String);

		public static implicit operator Literal((String String, StringComparison ComparisonType) Pattern) => new Literal(Pattern.String, Pattern.ComparisonType);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) => String.Consume(ref Source, ComparisonType);

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
