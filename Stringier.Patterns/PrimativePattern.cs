namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	internal class PrimativePattern : Pattern, IPrimative, IEquatable<PrimativePattern>, IEquatable<String> {
		/// <summary>
		/// The head node of the pattern
		/// </summary>
		/// <remarks>
		/// Any pattern itself is essentially an unballanced binary tree; this is the starting point
		/// </remarks>
		internal readonly IPrimativeNode Head;

		Int32 IPrimative.Length => Head.Length;

		/// <summary>
		/// Construct a new <see cref="PrimativePattern"/> with the specified <paramref name="Head"/>
		/// </summary>
		/// <param name="Head">The <see cref="IPrimativeNode"/> to set as the head of this pattern</param>
		internal PrimativePattern(IPrimativeNode Head) => this.Head = Head;

		public static explicit operator PrimativePattern(Func<Char, Boolean> Check) => new PrimativePattern(new Checker(Check));

		public static implicit operator PrimativePattern(Char Char) => new PrimativePattern(new CharLiteral(Char));

		public static implicit operator PrimativePattern((Char Char, StringComparison ComparisonType) Pattern) => new PrimativePattern(new CharLiteral(Pattern.Char, Pattern.ComparisonType));

		public static implicit operator PrimativePattern(String String) => new PrimativePattern(new StringLiteral(String));

		public static implicit operator PrimativePattern((String String, StringComparison ComparisonType) Pattern) => new PrimativePattern(new StringLiteral(Pattern.String, Pattern.ComparisonType));

		#region Alternator

		public override Pattern Alternate(Pattern Right) {
			switch (Right) {
			case ComplexPattern right:
				return new ComplexPattern(new Alternator(Head, right.Head));
			case PrimativePattern right:
				return new ComplexPattern(new Alternator(Head, right.Head));
			default:
				throw new ArgumentException("Pattern type wasn't handled", nameof(Right));
			}
		}

		public override Pattern Alternate(Char Right) => new ComplexPattern(new Alternator(Head, Right));

		public override Pattern Alternate(String Right) => new ComplexPattern(new Alternator(Head, Right));

		#endregion

		#region Capturer

		public override Pattern Capture(out Capture Capture) => new PrimativePattern(new PrimativeCapturer(Head, out Capture));

		#endregion

		#region Concatenator

		public override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case ComplexPattern right:
				return new ComplexPattern(new ComplexConcatenator(Head, right.Head));
			case PrimativePattern right:
				return new PrimativePattern(new PrimativeConcatenator(Head, right.Head));
			default:
				throw new ArgumentException("Pattern type wasn't handled", nameof(Right));
			}
		}

		public override Pattern Concatenate(Char Right) => new PrimativePattern(new PrimativeConcatenator(Head, Right));

		public override Pattern Concatenate(String Right) => new PrimativePattern(new PrimativeConcatenator(Head, Right));

		#endregion

		#region Negator

		public override Pattern Negate() => new PrimativePattern(new PrimativeNegator(Head));

		#endregion

		#region Optor

		public override Pattern Optional() => new ComplexPattern(new Optor(Head));

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 Count) => new PrimativePattern(new PrimativeRepeater(Head, Count));

		#endregion

		#region Spanner

		public override Pattern Span() => new ComplexPattern(new Spanner(Head));

		#endregion

		public override Result Consume(ref Source Source) => Head.Consume(ref Source);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case PrimativePattern other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(PrimativePattern other) => Head.Equals(other.Head);

		public Boolean Equals(String other) => Head.Equals(other);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Head.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Head.ToString();
	}
}
