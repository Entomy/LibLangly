namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class Literal : Primative, IEquatable<Literal> {
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

		public override Boolean Equals(String other) => Stringier.Equals(String, other, StringComparison.InvariantCulture);

		public Boolean Equals(Literal other) => Stringier.Equals(String, other.String, StringComparison.InvariantCulture);

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

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => String.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public override Result Neglect(ref Source Source) => String.Neglect(ref Source);

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => String;
	}
}
