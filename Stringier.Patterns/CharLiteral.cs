namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class CharLiteral : Literal, IEquatable<Char>, IEquatable<CharLiteral> {
		internal readonly Char Char = '\u0000';

		/// <summary>
		/// The <see cref="StringComparison"/> to use during pattern matching
		/// </summary>
		internal readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		internal CharLiteral(Char Char) : this(Char, Stringier.DefaultComparisonType) { }

		internal CharLiteral(Char Char, StringComparison ComparisonType) {
			this.Char = Char;
			this.ComparisonType = ComparisonType;
		}

		internal override Boolean CheckHeader(ref Source Source) => Char.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => Char.Consume(ref Source, ref Result, ComparisonType);

		internal override void Neglect(ref Source Source, ref Result Result) => Char.Neglect(ref Source, ref Result, ComparisonType);

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case CharLiteral other:
				return Equals(other);
			case Char other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(Char.ToString(), other, ComparisonType);

		public override Boolean Equals(String other) => Stringier.Equals(Char.ToString(), other, ComparisonType);

		public Boolean Equals(Char other) => Stringier.Equals(Char, other, ComparisonType);

		public Boolean Equals(CharLiteral other) => Stringier.Equals(Char, other.Char, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		public override String ToString() => $"{Char}";

		#region Concatenator

		internal override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case StringLiteral right:
				if (ComparisonType != right.ComparisonType) { goto default; }
				return new StringLiteral(Char + right.String);
			case CharLiteral right:
				if (ComparisonType != right.ComparisonType) { goto default; }
				return new StringLiteral(Char.ToString() + right.Char.ToString());
			default:
				return base.Concatenate(Right);
			}
		}

		internal override Pattern Concatenate(String Right) {
			if (ComparisonType == Stringier.DefaultComparisonType) {
				return new StringLiteral(Char + Right);
			} else {
				return new Concatenator(this, Right);
			}
		}

		internal override Pattern Concatenate(Char Right) {
			if (ComparisonType == Stringier.DefaultComparisonType) {
				return new StringLiteral("" + Char + Right);
			} else {
				return new Concatenator(this, Right);
			}
		}

		#endregion

		#region Repeater

		internal override Pattern Repeat(Int32 Count) => new StringLiteral(Char.Repeat(Count));

		#endregion
	}
}
