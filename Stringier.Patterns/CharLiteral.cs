namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class CharLiteral : Literal, IEquatable<Char>, IEquatable<CharLiteral> {
		internal readonly Char Char;

		internal CharLiteral(Char Char) : this(Char, false) { }

		internal CharLiteral(Char Char, Boolean IsCaseSensitive) : base(IsCaseSensitive) => this.Char = Char;

		internal override Boolean CheckHeader(ref Source Source) => Char.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => Char.Consume(ref Source, ref Result, IsCaseSensitive);

		internal override void Neglect(ref Source Source, ref Result Result) => Char.Neglect(ref Source, ref Result, IsCaseSensitive);

		public override Boolean Equals(Node node) {
			switch (node) {
			case CharLiteral other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(Char.ToString(), other, IsCaseSensitive);

		public override Boolean Equals(String other) => Stringier.Equals(Char.ToString(), other, IsCaseSensitive);

		public Boolean Equals(Char other) => Stringier.Equals(Char, other, IsCaseSensitive);

		public Boolean Equals(CharLiteral other) => IsCaseSensitive.Equals(other.IsCaseSensitive) && Stringier.Equals(Char, other.Char);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		public override String ToString() => $"{Char}";

		#region Concatenator

		internal override Node Concatenate(Node Right) {
			switch (Right) {
			case StringLiteral right:
				if (IsCaseSensitive.Equals(right.IsCaseSensitive)) {
					return new StringLiteral(Char + right.String);
				} else {
					goto default;
				}
			case CharLiteral right:
				if (IsCaseSensitive.Equals(right.IsCaseSensitive)) {
					return new StringLiteral(Char.ToString() + right.Char.ToString());
				} else {
					goto default;
				}
			default:
				return base.Concatenate(Right);
			}
		}

		internal override Node Concatenate(String Right) => new StringLiteral(Char + Right);

		internal override Node Concatenate(Char Right) => new StringLiteral(Char.ToString() + Right);

		#endregion

		#region Repeater

		internal override Node Repeat(Int32 Count) => new StringLiteral(Char.Repeat(Count));

		#endregion
	}
}
