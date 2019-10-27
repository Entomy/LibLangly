namespace System.Text.Patterns {
	/// <summary>	
	/// Represents a literal pattern
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.String"/> into something that we can treat as a part of a pattern
	/// </remarks>
	internal sealed class StringLiteral : Literal, IEquatable<StringLiteral> {
		internal readonly String String = "";

		internal StringLiteral(String String) : this(String, false) { }

		internal StringLiteral(String String, Boolean IsCaseSensitive) : base(IsCaseSensitive) => this.String = String;

		internal override Boolean CheckHeader(ref Source Source) => String.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => String.Consume(ref Source, ref Result, IsCaseSensitive);

		internal override void Neglect(ref Source Source, ref Result Result) => String.Neglect(ref Source, ref Result, IsCaseSensitive);

		public override Boolean Equals(Node node) {
			switch (node) {
			case StringLiteral other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(String, other, IsCaseSensitive);

		public override Boolean Equals(String other) {
			if (other is null) {
				return false;
			}
			return Stringier.Equals(String, other, IsCaseSensitive);
		}

		public Boolean Equals(StringLiteral other) => IsCaseSensitive.Equals(other.IsCaseSensitive) && Stringier.Equals(String, other.String, IsCaseSensitive);

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

		internal override Node Concatenate(Node Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			switch (Right) {
			case StringLiteral right:
				if (IsCaseSensitive.Equals(right.IsCaseSensitive)) {
					return new StringLiteral(String + right.String);
				} else {
					goto default;
				}
			case CharLiteral right:
				if (IsCaseSensitive.Equals(right.IsCaseSensitive)) {
					return new StringLiteral(String + right.Char);
				} else {
					goto default;
				}
			default:
				return base.Concatenate(Right);
			}
		}

		internal override Node Concatenate(String Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return new StringLiteral(String + Right);
		}

		internal override Node Concatenate(Char Right)=> new StringLiteral(String + Right);

		#endregion

		#region Repeater

		internal override Node Repeat(Int32 Count) => new StringLiteral(String.Repeat(Count));

		#endregion
	}
}
