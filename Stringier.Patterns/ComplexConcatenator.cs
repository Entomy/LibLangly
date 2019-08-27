namespace System.Text.Patterns {
	internal sealed class ComplexConcatenator : IComplexNode, IEquatable<ComplexConcatenator> {
		private readonly INode Left;

		private readonly INode Right;

		internal ComplexConcatenator(INode Left, INode Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal ComplexConcatenator(IComplexNode Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal ComplexConcatenator(Char Left, IComplexNode Right) : this(new CharLiteral(Left), Right) { }

		internal ComplexConcatenator(IComplexNode Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal ComplexConcatenator(String Left, IComplexNode Right) : this(new StringLiteral(Left), Right) { }

		public Result Consume(ref Source Source) {
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

		public Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(ComplexConcatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public Result Neglect(ref Source Source) {
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
