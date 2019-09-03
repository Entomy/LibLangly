namespace System.Text.Patterns {
	internal sealed class ComplexConcatenator : ComplexPattern, IEquatable<ComplexConcatenator> {
		private readonly Pattern Left;

		private readonly Pattern Right;

		internal ComplexConcatenator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal ComplexConcatenator(Pattern Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal ComplexConcatenator(Char Left, Pattern Right) : this(new CharLiteral(Left), Right) { }

		internal ComplexConcatenator(Pattern Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal ComplexConcatenator(String Left, Pattern Right) : this(new StringLiteral(Left), Right) { }

		protected internal override Boolean CheckFirstChar(ref Source Source) => Left.CheckFirstChar(ref Source);

		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result;
			// Try consuming the left side
			Result = Left.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			// Try consuming the right side
			Result = Right.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ComplexConcatenator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			if (!Left.Consume(ref Source)) { return false; }
			if (!Right.Consume(ref Source)) { return false; }
			return Source.Length != 0;
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			if (!Left.Consume(ref Source)) { return false; }
			if (!Right.Consume(ref Source)) { return false; }
			return Source.Length != 0;
		}

		public Boolean Equals(ComplexConcatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result;
			// Try consuming the left side
			Result = Left.Neglect(ref Source);
			if (!Result) { goto Cleanup; }
			// Try consuming the right side
			Result = Right.Neglect(ref Source);
			if (!Result) { goto Cleanup; }
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		public override String ToString() => $"{Left}{Right}";
	}
}
