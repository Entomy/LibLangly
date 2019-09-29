namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class StringLiteral : Literal, IEquatable<StringLiteral> {
		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		internal readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		internal readonly String String = "";

		internal StringLiteral(String String) : this(String, Stringier.DefaultComparisonType) { }

		internal StringLiteral(String String, StringComparison ComparisonType) {
			this.String = String;
			this.ComparisonType = ComparisonType;
		}

		internal override Boolean CheckHeader(ref Source Source) => String.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => String.Consume(ref Source, ref Result, ComparisonType);

		internal override void Neglect(ref Source Source, ref Result Result) => String.Neglect(ref Source, ref Result, ComparisonType);

		public override Boolean Equals(Object? obj) {
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
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"{String}";

		#region Concatenator

		internal override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case StringLiteral right:
				if (ComparisonType != right.ComparisonType) { goto default; }
				return new StringLiteral(String + right.String);
			case CharLiteral right:
				if (ComparisonType != right.ComparisonType) { goto default; }
				return new StringLiteral(String + right.Char);
			default:
				return base.Concatenate(Right);
			}
		}

		internal override Pattern Concatenate(String Right) {
			if (ComparisonType == Stringier.DefaultComparisonType) {
				return new StringLiteral(String + Right);
			} else {
				return new Concatenator(this, Right);
			}
		}

		internal override Pattern Concatenate(Char Right) {
			if (ComparisonType == Stringier.DefaultComparisonType) {
				return new StringLiteral(String + Right);
			} else {
				return new Concatenator(this, Right);
			}
		}

		#endregion

		#region Repeater

		internal override Pattern Repeat(Int32 Count) => new StringLiteral(String.Repeat(Count));

		#endregion
	}
}
