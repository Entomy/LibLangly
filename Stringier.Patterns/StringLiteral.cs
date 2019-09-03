namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class StringLiteral : PrimativePattern, IEquatable<StringLiteral> {
		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		private readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		private readonly String String = "";

		internal StringLiteral(String String) : this(String, Stringier.DefaultComparisonType) { }

		internal StringLiteral(String String, StringComparison ComparisonType) {
			this.String = String;
			this.ComparisonType = ComparisonType;
		}

		protected internal override Int32 Length => String.Length;

		/// <summary>
		/// Check the first <see cref="Char"/> of the <paramref name="Source"/> against this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source"></param>
		/// <returns>True if a full parse would possibly match, false if definately not</returns>
		protected internal override Boolean CheckFirstChar(ref Source Source) => Stringier.Equals(String[0], Source.Peek());

		/// <summary>
		/// Attempt to consume the <see cref="ComplexPattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public override Result Consume(ref Source Source) => String.Consume(ref Source, ComparisonType);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case StringLiteral other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(String, other, ComparisonType);

		public override Boolean Equals(String other) => Stringier.Equals(String, other, ComparisonType);

		public Boolean Equals(StringLiteral other) => Stringier.Equals(String, other.String, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => String.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting the <see cref="ComplexPattern"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		protected internal override Result Neglect(ref Source Source) => String.Neglect(ref Source, ComparisonType);

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"{String}";
	}
}
