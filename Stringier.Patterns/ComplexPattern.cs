namespace System.Text.Patterns {
	internal class ComplexPattern : Pattern, IComplex, IEquatable<ComplexPattern>, IEquatable<String> {
		internal readonly IComplexNode Head;

		internal ComplexPattern(IComplexNode Head) => this.Head = Head;

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

		public override Pattern Capture(out Capture Capture) => new ComplexPattern(new ComplexCapturer(Head, out Capture));

		#endregion

		#region Concatenator

		public override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case ComplexPattern right:
				return new ComplexPattern(new ComplexConcatenator(Head, right.Head));
			case PrimativePattern right:
				return new ComplexPattern(new ComplexConcatenator(Head, right.Head));
			default:
				throw new ArgumentException("Pattern type wasn't handled", nameof(Right));
			}
		}

		public override Pattern Concatenate(Char Right) => new ComplexPattern(new ComplexConcatenator(Head, Right));

		public override Pattern Concatenate(String Right) => new ComplexPattern(new ComplexConcatenator(Head, Right));

		#endregion

		#region Negator

		public override Pattern Negate() => new ComplexPattern(new ComplexNegator(Head));

		#endregion

		#region Optor

		public override Pattern Optional() => new ComplexPattern(new Optor(Head));

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 Count) => new ComplexPattern(new ComplexRepeater(Head, Count));

		#endregion

		#region Spanner

		public override Pattern Span() => new ComplexPattern(new Spanner(Head));

		#endregion

		public override Result Consume(ref Source Source) => Head.Consume(ref Source);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ComplexPattern other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(ComplexPattern other) => Head.Equals(other.Head);

		public Boolean Equals(String other) => Head.Equals(other);

		public override Int32 GetHashCode() => Head.GetHashCode();

		public override String ToString() => Head.ToString();
	}
}
