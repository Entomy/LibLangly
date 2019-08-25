namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class StringLiteral : IPrimativeNode, IEquatable<StringLiteral> {
		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		private readonly String String = "";

		Int32 IPrimative.Length => String.Length;

		internal StringLiteral(String String) : this(String, StringComparison.CurrentCulture) { }

		internal StringLiteral(String String, StringComparison ComparisonType) {
			this.String = String;
			this.ComparisonType = ComparisonType;
		}

		public static implicit operator StringLiteral(String String) => new StringLiteral(String);

		public static implicit operator StringLiteral((String String, StringComparison ComparisonType) Pattern) => new StringLiteral(Pattern.String, Pattern.ComparisonType);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(ref Source Source) => String.Consume(ref Source, ComparisonType);

		public Boolean Equals(String other) => Stringier.Equals(String, other, ComparisonType);

		public Boolean Equals(StringLiteral other) => Stringier.Equals(String, other.String, ComparisonType);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case StringLiteral Other:
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
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see name="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Neglect(String Source) {
			Source source = new Source(Source);
			return Neglect(ref source);
		}

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="Pattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Neglect(ref Source Source) => String.Neglect(ref Source, ComparisonType);

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => String;
	}
}
